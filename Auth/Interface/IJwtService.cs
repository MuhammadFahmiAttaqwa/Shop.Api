using Shop.Application.DTO.Auth.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Auth.Interface
{
    public interface IJwtService
    {
        string GenerateAccessToken(AccessTokenRequest request);

        ClaimsPrincipal ValidateToken(string token, bool validateLifetime = true);

        string GenerateRefreshToken();
    }
}
