using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("RefreshToken")]
    public class RefreshToken : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string ClientIp { get; set; } = string.Empty;
        public bool IsRevoked { get; set; }
        public AppUser User { get; set; } = null!;
    }
}
