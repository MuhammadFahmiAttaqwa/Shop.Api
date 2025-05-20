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
    [Table("Slide")]
    public class Slide : BaseEntity<int>, ISoftDelete, ICreateData
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public string Image { set; get; }

        public string Url { set; get; }

        public int? DisplayOrder { set; get; }

        public bool Status { set; get; }

        public string Content { set; get; }

        public string GroupAlias { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
