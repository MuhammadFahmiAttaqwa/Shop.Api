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
    [Table("SystemConfig")]
    public class SystemConfig : BaseEntity<string>, ISoftDelete, ICreateData
    {
        public string Name { get; set; }

        public string Value1 { get; set; }
        public int? Value2 { get; set; }

        public bool? Value3 { get; set; }

        public DateTime? Value4 { get; set; }

        public decimal? Value5 { get; set; }

        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
