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
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Tag)
                .WithMany()
                .HasForeignKey(x => x.TagId);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogTag)
                .HasForeignKey(x => x.BlogId);
        }
    }
}
