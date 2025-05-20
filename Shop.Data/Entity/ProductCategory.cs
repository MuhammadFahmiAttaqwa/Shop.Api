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
    [Table("ProductCategory")]
    public class ProductCategory : BaseEntity<int>, IHasSeoMetaData, ISort, IDate, ICreateData, ISoftDelete
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }


        public int SortOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public List<Product> Product {  get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
