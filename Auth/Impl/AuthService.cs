using Microsoft.Extensions.Configuration;
using Shop.Application.DTO.Auth.Request;
using Shop.Application.DTO.Auth.Response;
using Shop.Application.Repository.User;
using Shop.Auth.Interface;
using Shop.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Auth.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;

        private readonly IJwtService _jwtService;

        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository repository, IJwtService jwtService, IConfiguration configuration)
        {
            _repository = repository;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        public async Task<TokenResponse> Authenticate(LoginRequest req, string clientIp)
        {
            if (string.IsNullOrEmpty(req.Username) || string.IsNullOrEmpty(req.Password))
            {
                throw new UnauthorizedAccessException("Invalid Credential");
            }
            var user = await _repository.FindByUserName(req.Username);

            if (user == null || user.IsDeleted || !await _repository.CheckPassword(user, req.Password))
            {
                await _repository.IncreamentAccessFailed(user);
                throw new UnauthorizedAccessException("Invalid Credetial");
            }
            if (user.LockoutEnabled && user.LockoutEnd > DateTimeOffset.UtcNow)
            {
                throw new UnauthorizedAccessException("Account is Locked");
            }
            await _repository.ResetAccessFailed(user);
            await _repository.Update(user);

            var role = await _repository.GetRole(user);
            var tokenClaim = new List<Claim>();

            tokenClaim.AddRange(role.Select(c => new Claim(ClaimTypes.Role, c)));

            var tokenAccessRequest = new AccessTokenRequest
            {
                FullName = user.FullName,
                Avatar = user.Avatar,
                Id = user.Id,
                Roles = role,
                Claims = tokenClaim,
            };
            var accessToken = _jwtService.GenerateAccessToken(tokenAccessRequest);
            var refreshToken = _jwtService.GenerateRefreshToken();

            await _repository.AddRefreshToken(user, refreshToken, clientIp);

            return new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration[Constant.AccessTokenExpiry])),
                RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration[Constant.RefreshTokenExpiry])),
                FullName = user.FullName,
                Avatar = user.Avatar,
                Roles = role.ToList(),

            };




        }
        public Task InitiatePasswordReset(string userName)
        {
            throw new NotImplementedException();
        }

       
    }
}
