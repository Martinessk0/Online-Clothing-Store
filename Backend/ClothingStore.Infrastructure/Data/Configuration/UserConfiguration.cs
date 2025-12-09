using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore.Infrastructure.Data.Entities;

namespace ClothingStore.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<ApplicationUser> SeedUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                FirstName = "Martin",
                LastName = "Grahovski",
                UserName = "admin@test.bg",
                NormalizedUserName = "ADMIN@TEST.BG",
                Email = "admin@test.bg",
                NormalizedEmail = "ADMIN@TEST.BG",
                EmailConfirmed = true,
                SecurityStamp = "YIXYIXE6GJSSN4KVYJROXMJQKQ2EVPJT",
                ConcurrencyStamp = "f81c19fd-26e6-4bf4-b0d5-9fe7b6ab964e",
                PasswordHash = "AQAAAAIAAYagAAAAELsHLYJ3ohlX9t3pZfMqITIGBk0HCxoM7DgBvgJ4riXCt+YmwIuSdrY+Llv3lhURHg==",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            //user.PasswordHash =
            //     hasher.HashPassword(user, "Test123/");

            users.Add(user);


            return users;
        }
    }
}
