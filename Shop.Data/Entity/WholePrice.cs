using Shop.Data.Base;
using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("WholePrice")]
    public class WholePrice : BaseEntity<int>, ISoftDelete, ICreateData
    {
        public int ProductId { get; set; }

        public int FromQuantity { get; set; }

        public int ToQuantity { get; set; }

        public decimal Price { get; set; }

        public Product Product { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
