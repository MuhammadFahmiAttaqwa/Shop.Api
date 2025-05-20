using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuration
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(x => x.Bill)
                .WithMany(x => x.BillDetail)
                .HasForeignKey(x => x.BillId);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Color)
                .WithMany()
                .HasForeignKey(x => x.ColorId);

            builder.HasOne(x => x.Size)
                .WithMany()
                .HasForeignKey(x => x.SizeId);


        }
    }
}
