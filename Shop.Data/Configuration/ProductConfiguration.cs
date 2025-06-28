using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Common.Constant;
using Shop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(Constant.MaxLength256);

            builder.Property(x => x.Image).HasMaxLength(Constant.MaxLength256);



            builder.Property(x => x.Price).HasColumnType(Constant.DecimalType).HasDefaultValue(0);
            builder.Property(x => x.PromotionPrice).HasColumnType(Constant.DecimalType);
            builder.Property(x => x.OriginalPrice).HasColumnType(Constant.DecimalType);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.Tags).HasMaxLength(Constant.MaxLength256);

            builder.Property(x => x.Unit).HasMaxLength(Constant.MaxLength256);

            builder.Property(x => x.SeoKeywords).HasMaxLength(Constant.MaxLength256);

            builder.Property(x => x.SeoAlias).HasMaxLength(Constant.MaxLength256);

            builder.Property(x => x.SeoDescription).HasMaxLength(Constant.MaxLength256);

            builder.HasOne(x => x.ProductCategory)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
