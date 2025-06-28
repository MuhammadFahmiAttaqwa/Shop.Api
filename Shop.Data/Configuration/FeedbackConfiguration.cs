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
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(Constant.MaxLength250).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(Constant.MaxLength250);

            builder.Property(x => x.Message).HasMaxLength(Constant.MaxLength500);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);




        }
    }
}
