using Microsoft.AspNetCore.Identity;
using Shop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Repository.User
{
    public interface IUserRepository
    {
        Task<AppUser> FindByUserName(string userName);

        Task<AppUser> FindById(Guid id);

        Task<AppUser> FindByExternalLogin(string req);

        Task<bool> CheckPassword(AppUser user, string password);

        Task Update(AppUser user);

        Task<IEnumerable<string>> GetRole(AppUser user);

        Task<IEnumerable<IdentityUserClaim<Guid>>> GetUserClaims(AppUser user);

        Task<IEnumerable<IdentityRoleClaim<Guid>>> GetRoleClaim (AppUser user);

        Task IncreamentAccessFailed(AppUser user);

        Task ResetAccessFailed (AppUser user);

        Task AddPasswordResetToken(AppUser user, string token);

        Task<bool> ValidatePasswordResetToken(AppUser user, string token);

        Task RemovePasswordResetToken(AppUser user, string token);

        Task AddRefreshToken(AppUser user, string token, string clienIp);

        Task<RefreshToken> FindRefreshToken(string token);

        Task RevokeRefreshToken(RefreshToken refreshToken);



    }
}
