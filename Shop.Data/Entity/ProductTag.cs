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
    [Table("ProductTag")]
    public class ProductTag : BaseEntity<int>, IDate, ICreateData, ISoftDelete
    {
        public int ProductId { get; set; }

        public string TagId { set; get; }

        public Product Product { get; set; }

        public  Tag Tag { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
