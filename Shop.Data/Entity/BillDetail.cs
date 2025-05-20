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
    [Table("BillDetail")]
    public class BillDetail : BaseEntity<int> , ISoftDelete, ICreateData, IDate
    {   
        public int BillId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        public Bill Bill { get; set; }  

        public Product Product { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
