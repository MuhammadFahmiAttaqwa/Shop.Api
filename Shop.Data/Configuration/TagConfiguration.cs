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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(Constant.MaxLength20);

            builder.Property(x => x.Name).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.Type).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);


        }
    }
}
