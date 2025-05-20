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
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.Title).HasMaxLength(Constant.MaxLength250).IsRequired();

            builder.Property(x => x.Content).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.UserId);

        }
    }
}
