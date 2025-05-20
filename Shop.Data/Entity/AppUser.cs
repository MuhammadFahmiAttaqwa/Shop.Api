using Microsoft.AspNetCore.Identity;
using Shop.Common.Enums;
using Shop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("AppUser")]
    public class AppUser : IdentityUser<Guid>, IDate, ISoftDelete, ICreateData
    {

        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }

        public decimal Balance { get; set; }

        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
