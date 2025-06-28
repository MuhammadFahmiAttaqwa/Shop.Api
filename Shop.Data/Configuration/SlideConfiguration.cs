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
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Image).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Url).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Description).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.GroupAlias).HasMaxLength(Constant.MaxLength250);


        }
    }
}
