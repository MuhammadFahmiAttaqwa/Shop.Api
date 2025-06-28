using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entity;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Shop.Application.Repository.User.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Task AddPasswordResetToken(AppUser user, string token)
        {
            throw new NotImplementedException();
        }

        public async Task AddRefreshToken(AppUser user, string token, string clienIp)
        {
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Token = token,
                IssuedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshTokenExpiryDays"])),
                ClientIp = clienIp,
                IsRevoked = false,

            };
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckPassword(AppUser user, string password)
        {
            return await Task.FromResult(BCrypt.Net.BCrypt.Verify(password, user.PasswordHash));
        }

        public Task<AppUser> FindByExternalLogin()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByExternalLogin(string req)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> FindById(Guid id)
        {
            return await _context.AppUser.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            return await _context.AppUser.AsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedUserName == userName.ToUpper() && !u.IsDeleted);
        }

        public async Task<RefreshToken> FindRefreshToken(string token)
        {
            return await _context.RefreshTokens.Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.Token == token && !rt.IsRevoked);
        }

        public async Task<IEnumerable<string>> GetRole(AppUser user)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Join(_context.AppRoles,
                    ur => ur.RoleId,
                    r => r.Id,
                    (ur, r) => r.Name)
                .ToListAsync();
        }

        public Task<IEnumerable<IdentityRoleClaim<Guid>>> GetRoleClaim(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityUserClaim<Guid>>> GetUserClaims(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async Task IncreamentAccessFailed(AppUser user)
        {
            if (user == null) return;
            user.AccessFailedCount++;
            if(user.LockoutEnabled && user.AccessFailedCount >= 5)
            {
                user.LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(15);
            }
           await Update(user);
        }

        public Task RemovePasswordResetToken(AppUser user, string token)
        {
            throw new NotImplementedException();
        }

        public async Task ResetAccessFailed(AppUser user)
        {
            if (user == null) return;
            user.AccessFailedCount = 0;
            user.LockoutEnd = null;
            await Update(user); 
        }

        public async Task RevokeRefreshToken(RefreshToken refreshToken)
        {
            refreshToken.IsRevoked = true;
            _context.RefreshTokens.Update(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task Update(AppUser user)
        {
            user.ConcurrencyStamp = Guid.NewGuid().ToString();
            _context.AppUser.Update(user);
            await _context.SaveChangesAsync();
        }

        public Task<bool> ValidatePasswordResetToken(AppUser user, string token)
        {
            throw new NotImplementedException();
        }
    }
}
