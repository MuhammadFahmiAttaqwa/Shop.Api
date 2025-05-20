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
    public class AnnouncementUserConfiguration : IEntityTypeConfiguration<AnnouncementUser>
    {
        public void Configure(EntityTypeBuilder<AnnouncementUser> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.AnnouncementId).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(x => x.Announcement)
                .WithMany(x => x.AnnouncementUser)
                .HasForeignKey(x => x.AnnouncementId);

            builder.HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
                
        }
    }
}
