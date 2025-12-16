using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            var seedDate = new DateTime(2025, 12, 16, 0, 0, 0, DateTimeKind.Utc);

            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Classic Cotton T-Shirt",
                    Description = "Soft 100% cotton t-shirt with a regular fit. Easy to pair with jeans or shorts.",
                    Price = 24.99m,
                    Brand = "UrbanBasics",
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 2,
                    Name = "Oversized Graphic Tee",
                    Description = "Oversized fit t-shirt with a minimal front print and bold back graphic.",
                    Price = 29.99m,
                    Brand = "StreetLab",
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 3,
                    Name = "Premium Hoodie",
                    Description = "Warm fleece-lined hoodie with a kangaroo pocket and adjustable drawstrings.",
                    Price = 59.90m,
                    Brand = "NorthWear",
                    CategoryId = 2,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 4,
                    Name = "Zip-Up Hoodie",
                    Description = "Everyday zip-up hoodie with soft interior, perfect for layering.",
                    Price = 54.50m,
                    Brand = "NorthWear",
                    CategoryId = 2,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 5,
                    Name = "Slim Fit Jeans",
                    Description = "Slim fit jeans with a comfortable stretch. Clean look for casual or smart outfits.",
                    Price = 79.00m,
                    Brand = "DenimCo",
                    CategoryId = 3,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 6,
                    Name = "Straight Fit Jeans",
                    Description = "Classic straight fit denim with durable stitching and mid-rise waist.",
                    Price = 74.00m,
                    Brand = "DenimCo",
                    CategoryId = 3,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 7,
                    Name = "Lightweight Bomber Jacket",
                    Description = "Light bomber jacket with a smooth finish and ribbed cuffs. Great for spring/fall.",
                    Price = 99.99m,
                    Brand = "AeroStyle",
                    CategoryId = 4,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 8,
                    Name = "Puffer Jacket",
                    Description = "Insulated puffer jacket designed for cold days. Water-resistant outer layer.",
                    Price = 149.99m,
                    Brand = "AeroStyle",
                    CategoryId = 4,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 9,
                    Name = "Running Sneakers",
                    Description = "Comfortable lightweight sneakers with cushioned sole and breathable mesh upper.",
                    Price = 89.90m,
                    Brand = "MoveX",
                    CategoryId = 5,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                },
                new Product
                {
                    Id = 10,
                    Name = "Casual Leather Sneakers",
                    Description = "Minimal leather sneakers for everyday wear. Clean look and durable outsole.",
                    Price = 119.00m,
                    Brand = "MoveX",
                    CategoryId = 5,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                }
            };
        }
    }
}
