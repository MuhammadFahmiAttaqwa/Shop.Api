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
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerMessage).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.CustomerMobile).HasMaxLength(Constant.MaxLength20);

            builder.Property(x => x.CustomerAddress).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.CustomerName).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.UserId);



        }
    }
}
