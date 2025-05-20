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
    [Table("Product")]
    public class Product : BaseEntity<int>, IDate, IHasSeoMetaData, ISoftDelete, ICreateData
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        public string Unit { get; set; }


        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public List<ProductTag> ProductTag {  get; set; } = new List<ProductTag>();
        public bool IsDeleted { get; set; }

        public string CreateBy { get; set; }

        public string? UpadatedBy { get; set; }
    }
}
