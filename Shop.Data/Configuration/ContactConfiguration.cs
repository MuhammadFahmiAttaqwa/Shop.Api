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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Phone).HasMaxLength(Constant.MaxLength20);

            builder.Property(x => x.Address).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Website).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Email).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
