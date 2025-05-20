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
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Image).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Name).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.SeoKeywords).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.SeoPageTitle).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.SeoDescription).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Description).HasMaxLength(Constant.MaxLength250);


        }
    }
}
