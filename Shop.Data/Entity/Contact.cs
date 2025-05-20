using Shop.Common.Enums;
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
    [Table("Contact")]
    public class Contact : BaseEntity<string>, ISoftDelete, ICreateData
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Other { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
