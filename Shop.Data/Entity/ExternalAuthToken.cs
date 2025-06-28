using Shop.Data.Base;
using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("ExternalAuthToken")]
    public class ExternalAuthToken : BaseEntity<Guid>, IDate
    {
        public Guid UserId { get; set; }
        public string Provider { get; set; }
        public string TokenType { get; set; }
        public string TokenValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public AppUser User { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
