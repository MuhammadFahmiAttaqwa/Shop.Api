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
    public class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.URL).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Name).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.ParentId).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}
