using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("Permission")]
    public class Permission : BaseEntity<int>
    {
        public Guid RoleId { get; set; }

        public string FunctionId { get; set; }

        public bool CanCreate { get; set; }

        public bool CanRead { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public AppRole AppRole { get; set; }

        public Function Function { get; set; } 
    }
}
