using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Auth.Request
{
    public class AccessTokenRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<Claim> Claims { get; set; } = Enumerable.Empty<Claim>();
    }
}
