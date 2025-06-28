using Microsoft.AspNetCore.Identity;
using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("AppRole")]
    public class AppRole : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;

    }
}
