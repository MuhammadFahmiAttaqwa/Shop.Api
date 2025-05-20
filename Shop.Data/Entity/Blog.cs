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
    [Table("Blog")]
    public class Blog : BaseEntity<int>, IDate, IHasSeoMetaData, ISoftDelete, ICreateData
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Description { set; get; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public List<BlogTag> BlogTag { get; set; } = new List<BlogTag>();
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
