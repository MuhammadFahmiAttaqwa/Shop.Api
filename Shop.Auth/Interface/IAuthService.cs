using Shop.Application.DTO.Auth.Request;
using Shop.Application.DTO.Auth.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Auth.Interface
{
    public interface IAuthService
    {
        Task<TokenResponse> Authenticate(LoginRequest req, string clientIp);


      
    }
}
