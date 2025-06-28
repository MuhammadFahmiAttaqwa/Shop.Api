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
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CanCreate).HasDefaultValue(false);

            builder.Property(x => x.CanDelete).HasDefaultValue(false);

            builder.Property(x => x.CanRead).HasDefaultValue(false);

            builder.Property(x => x.CanUpdate).HasDefaultValue(false);

            builder.Property(x => x.FunctionId).HasMaxLength(Constant.MaxLength100);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasOne(x => x.Function)
                .WithMany()
                .HasForeignKey(x => x.FunctionId);

            builder.HasOne(x => x.AppRole)
                .WithMany()
                .HasForeignKey(x => x.RoleId);
        }
    }
}
