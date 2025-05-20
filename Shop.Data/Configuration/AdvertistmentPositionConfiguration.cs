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
    public class AdvertistmentPositionConfiguration : IEntityTypeConfiguration<AdvertistmentPosition>
    {
        public void Configure(EntityTypeBuilder<AdvertistmentPosition> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(Constant.MaxLength20);

            builder.Property(x => x.Name).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.PageId).HasMaxLength(Constant.MaxLength20);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);


            builder.HasOne(x => x.AdvertistmentPage)
                .WithMany(x => x.AdvertistmentPosition)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
