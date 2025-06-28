using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuration
{
    public class ExternalAuthConfiguration : IEntityTypeConfiguration<ExternalAuthToken>
    {
        public void Configure(EntityTypeBuilder<ExternalAuthToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(rt => rt.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
