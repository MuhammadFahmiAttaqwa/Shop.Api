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
    public class AdvertistmentConfiguration : IEntityTypeConfiguration<Advertistment>
    {
        public void Configure(EntityTypeBuilder<Advertistment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(Constant.MaxLength250);

            builder.Property(x=> x.Image).IsRequired().HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Url).IsRequired().HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.PositionId).IsRequired().HasMaxLength(Constant.MaxLength20);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(x => x.AdvertistmentPosition)
                .WithMany(x => x.Advertistment)
                .HasForeignKey(x => x.PositionId);

        }
    }
}
