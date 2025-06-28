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
    public class WholePricesConfiguration : IEntityTypeConfiguration<WholePrice>
    {
        public void Configure(EntityTypeBuilder<WholePrice> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price).HasColumnType(Constant.DecimalType);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
