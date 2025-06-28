using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.DTO.Auth.Request;
using Shop.Auth.Configuration;
using Shop.Auth.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Auth.Impl
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly JwtConfiguration _jwtConfiguration;

        public JwtService(IConfiguration configuration, JwtConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;
            _configuration = configuration;
        }

        public string GenerateAccessToken(AccessTokenRequest request)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenClaims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, request.UserName ?? string.Empty),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new ("UserId", request.Id.ToString()),
                new ("FullName", request.FullName),
                new ("Avatar", request.Avatar)
            };

            tokenClaims.AddRange(request.Roles.Select(x => new Claim(ClaimTypes.Role, x)));
            tokenClaims.AddRange(request.Claims);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: tokenClaims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:AccessTokenExpireMinutes"])),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal ValidateToken(string token, bool validateLifetime = true)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException("Token cannot be null or empty");

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var parameters = _jwtConfiguration.ToTokenValidationParameter();
                if (!validateLifetime)
                {
                    parameters.ValidateLifetime = false;
                }
                return tokenHandler.ValidateToken(token, parameters, out _);
            }
            catch (SecurityTokenExpiredException ex)
            {
                Console.WriteLine($"Token expired: {ex.Message}");
                throw new SecurityTokenException("Token has expired.", ex);

            }

        }
    }
}
