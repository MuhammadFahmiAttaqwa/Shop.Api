using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shop.Data.Base;
using Shop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        #region DBSET
        public DbSet<Advertistment> Advertistment { get; set;}

        public DbSet<AdvertistmentPage> AdvertistmentPage { get; set; }

        public DbSet<AdvertistmentPosition> AdvertistmentPosition { get; set; }

        public DbSet<Announcement> Announcement { get; set; }

        public DbSet<AnnouncementUser> AnnouncementUser { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Bill> Bill { get; set; }

        public DbSet<BillDetail> BillDetail { get; set; }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<BlogTag> BlogTag { get; set; }

        public DbSet<Color> Color { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<Footer> Footer { get; set; }

        public DbSet<Function> Function { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<Page> Page { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<ProductImage> ProductImage { get; set; }

        public DbSet<ProductQuantity> ProductQuantity { get; set; }

        public DbSet<ProductTag> ProductTag { get; set; }

        public DbSet<Size> Size { get; set; }

        public DbSet<Slide> Slide { get; set; }

        public DbSet<SystemConfig> SystemConfig { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<WholePrice> WholePrice { get; set; }

        public DbSet<IdentityUserRole<Guid>> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<ExternalAuthToken> ExternalAuthTokens { get; set; }    
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Ignore<IdentityUserClaim<Guid>>();

            builder.Ignore<IdentityRoleClaim<Guid>>();

            builder.Ignore<IdentityUserLogin<Guid>>();

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            builder.Ignore<IdentityUserToken<Guid>>();  

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //private void SaveDate()
        //{
        //    var entries = ChangeTracker.Entries<IDate>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

        //    var date = DateTime.Now;

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added) entry.Entity.DateCreated = date;

        //        if (entry.State == EntityState.Modified) entry.Entity.DateUpdated = date;
        //    }
        //}
        
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    SaveDate();
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var basePath = Directory.GetCurrentDirectory();

                var configuration = new ConfigurationBuilder()
               .SetBasePath(basePath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

                var builder = new DbContextOptionsBuilder<AppDbContext>();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                builder.UseSqlServer(connectionString);
                return new AppDbContext(builder.Options);
            }
        }

    }
}
