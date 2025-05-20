using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("BlogTag")]
    public class BlogTag : BaseEntity<int>
    {
        public int BlogId { get; set; }

        public string TagId { get; set; }

        public Blog Blog { get; set; }

        public Tag Tag { get; set; }

    }
}
