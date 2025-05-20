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
    public class ProductTag : BaseEntity<int>
    {
        public int ProductId { get; set; }

        public string TagId { set; get; }

        public Product Product { get; set; }

        public  Tag Tag { get; set; }


    }
}
