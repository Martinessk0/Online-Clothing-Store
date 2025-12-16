using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Data.Configuration
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasData(SeedVariants());
        }

        private List<ProductVariant> SeedVariants()
        {
            return new List<ProductVariant>
            {
                new ProductVariant
                {
                    Id = 1,
                    ProductId = 1,   // Classic Cotton T-Shirt
                    ColorId = 1,     // White
                    Size = "M",
                    Stock = 120,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 2,
                    ProductId = 2,   // Oversized Graphic Tee
                    ColorId = 2,     // Black
                    Size = "L",
                    Stock = 80,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 3,
                    ProductId = 3,   // Premium Hoodie
                    ColorId = 3,     // Gray
                    Size = "M",
                    Stock = 60,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 4,
                    ProductId = 4,   // Zip-Up Hoodie
                    ColorId = 4,     // Navy
                    Size = "S",
                    Stock = 45,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 5,
                    ProductId = 5,   // Slim Fit Jeans
                    ColorId = 5,     // Dark Blue
                    Size = "32",
                    Stock = 70,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 6,
                    ProductId = 6,   // Straight Fit Jeans
                    ColorId = 6,     // Light Blue
                    Size = "34",
                    Stock = 55,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 7,
                    ProductId = 7,   // Lightweight Bomber Jacket
                    ColorId = 7,     // Olive
                    Size = "L",
                    Stock = 30,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 8,
                    ProductId = 8,   // Puffer Jacket
                    ColorId = 2,     // Black
                    Size = "M",
                    Stock = 25,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 9,
                    ProductId = 9,   // Running Sneakers
                    ColorId = 8,     // White/Gray
                    Size = "42",
                    Stock = 40,
                    IsActive = true
                },
                new ProductVariant
                {
                    Id = 10,
                    ProductId = 10,  // Casual Leather Sneakers
                    ColorId = 1,     // White
                    Size = "43",
                    Stock = 35,
                    IsActive = true
                }
            };
        }
    }
}
