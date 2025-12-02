using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        //public DbSet<Entity> TableName { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Adding Configuration (seeding)
            //builder.ApplyConfiguration(new UserConfiguration());


            base.OnModelCreating(builder);
        }
    }
}
