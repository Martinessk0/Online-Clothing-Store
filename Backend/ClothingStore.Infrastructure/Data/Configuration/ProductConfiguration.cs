//using ClothingStore.Infrastructure.Data.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace ClothingStore.Infrastructure.Data.Configuration
//{
//    public class ProductConfiguration : IEntityTypeConfiguration<Product>
//    {
//        public void Configure(EntityTypeBuilder<Product> builder)
//        {
//            builder.HasData(SeedProducts());
//        }

//        private List<Product> SeedProducts()
//        {
//            var seedDate = new DateTime(2025, 12, 16, 0, 0, 0, DateTimeKind.Utc);

//            return new List<Product>
//            {
//                new Product
//                {
//                    Id = 1,
//                    Name = "Classic Cotton T-Shirt",
//                    Description = "Soft 100% cotton t-shirt with a regular fit. Easy to pair with jeans or shorts.",
//                    Price = 24.99m,
//                    Brand = "UrbanBasics",
//                    CategoryId = 1,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 2,
//                    Name = "Oversized Graphic Tee",
//                    Description = "Oversized fit t-shirt with a minimal front print and bold back graphic.",
//                    Price = 29.99m,
//                    Brand = "StreetLab",
//                    CategoryId = 1,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 3,
//                    Name = "Premium Hoodie",
//                    Description = "Warm fleece-lined hoodie with a kangaroo pocket and adjustable drawstrings.",
//                    Price = 59.90m,
//                    Brand = "NorthWear",
//                    CategoryId = 2,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 4,
//                    Name = "Zip-Up Hoodie",
//                    Description = "Everyday zip-up hoodie with soft interior, perfect for layering.",
//                    Price = 54.50m,
//                    Brand = "NorthWear",
//                    CategoryId = 2,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 5,
//                    Name = "Slim Fit Jeans",
//                    Description = "Slim fit jeans with a comfortable stretch. Clean look for casual or smart outfits.",
//                    Price = 79.00m,
//                    Brand = "DenimCo",
//                    CategoryId = 3,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 6,
//                    Name = "Straight Fit Jeans",
//                    Description = "Classic straight fit denim with durable stitching and mid-rise waist.",
//                    Price = 74.00m,
//                    Brand = "DenimCo",
//                    CategoryId = 3,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 7,
//                    Name = "Lightweight Bomber Jacket",
//                    Description = "Light bomber jacket with a smooth finish and ribbed cuffs. Great for spring/fall.",
//                    Price = 99.99m,
//                    Brand = "AeroStyle",
//                    CategoryId = 4,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 8,
//                    Name = "Puffer Jacket",
//                    Description = "Insulated puffer jacket designed for cold days. Water-resistant outer layer.",
//                    Price = 149.99m,
//                    Brand = "AeroStyle",
//                    CategoryId = 4,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 9,
//                    Name = "Running Sneakers",
//                    Description = "Comfortable lightweight sneakers with cushioned sole and breathable mesh upper.",
//                    Price = 89.90m,
//                    Brand = "MoveX",
//                    CategoryId = 5,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                },
//                new Product
//                {
//                    Id = 10,
//                    Name = "Casual Leather Sneakers",
//                    Description = "Minimal leather sneakers for everyday wear. Clean look and durable outsole.",
//                    Price = 119.00m,
//                    Brand = "MoveX",
//                    CategoryId = 5,
//                    IsActive = true,
//                    CreatedAt = seedDate,
//                    ModifiedAt = seedDate
//                }
//            };
//        }
//    }
//}


using ClothingStore.Infrastructure.Data.Entities;
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

        private static List<Product> SeedProducts()
        {
            var seedDate = new DateTime(2025, 12, 16, 0, 0, 0, DateTimeKind.Utc);

            var categoryIds = Enumerable.Range(1, 20).ToArray();

            var brands = new[]
            {
                "UrbanBasics", "StreetLab", "NorthWear", "DenimCo", "AeroStyle",
                "MoveX", "CoreLine", "PulseActive", "MinimalForm", "StudioKnit",
                "CityTailor", "DailyCraft", "NovaFit", "Heritage", "MonoWear"
            };

            var adjectives = new[]
            {
                "Classic", "Premium", "Essential", "Oversized", "Relaxed",
                "Slim", "Regular", "Vintage", "Modern", "Lightweight",
                "Heavyweight", "Soft", "Technical", "Water-Resistant", "Cozy"
            };

            var baseNamesByCategory = new Dictionary<int, string[]>
            {
                [1] = new[] { "Cotton T-Shirt", "Graphic Tee", "Rib T-Shirt", "Boxy Tee" },
                [2] = new[] { "Hoodie", "Zip Hoodie", "Fleece Hoodie", "Pullover Hoodie" },
                [3] = new[] { "Jeans", "Denim Jeans", "Stretch Jeans", "Straight Jeans" },
                [4] = new[] { "Bomber Jacket", "Puffer Jacket", "Windbreaker", "Denim Jacket" },
                [5] = new[] { "Sneakers", "Leather Sneakers", "Running Shoes", "Slip-On Shoes" },
                [6] = new[] { "Sweatpants", "Joggers", "Fleece Pants", "Track Pants" },
                [7] = new[] { "Shorts", "Cargo Shorts", "Sport Shorts", "Denim Shorts" },
                [8] = new[] { "Oxford Shirt", "Flannel Shirt", "Linen Shirt", "Casual Shirt" },
                [9] = new[] { "Sweater", "Cardigan", "Knit Pullover", "Turtleneck" },
                [10] = new[] { "Wool Coat", "Parka", "Trench Coat", "Puffer Coat" },
                [11] = new[] { "Training Tee", "Gym Shorts", "Performance Hoodie", "Running Jacket" },
                [12] = new[] { "Boxers", "Briefs", "Bralette", "Sports Bra" },
                [13] = new[] { "Crew Socks", "Ankle Socks", "Sport Socks", "Wool Socks" },
                [14] = new[] { "Belt", "Sunglasses", "Wallet", "Scarf" },
                [15] = new[] { "Backpack", "Crossbody Bag", "Duffel Bag", "Tote Bag" },
                [16] = new[] { "Cap", "Beanie", "Bucket Hat", "Visor" },
                [17] = new[] { "Day Dress", "Midi Dress", "Slip Dress", "Knit Dress" },
                [18] = new[] { "Mini Skirt", "Midi Skirt", "Denim Skirt", "Pleated Skirt" },
                [19] = new[] { "Kids Tee", "Kids Hoodie", "Kids Pants", "Kids Jacket" },
                [20] = new[] { "Sale Item", "Outlet Piece", "Last Size", "Final Stock" },
            };

            var basePriceByCategory = new Dictionary<int, decimal>
            {
                [1] = 22m,
                [2] = 55m,
                [3] = 70m,
                [4] = 95m,
                [5] = 85m,
                [6] = 45m,
                [7] = 28m,
                [8] = 49m,
                [9] = 60m,
                [10] = 120m,
                [11] = 40m,
                [12] = 18m,
                [13] = 9m,
                [14] = 15m,
                [15] = 35m,
                [16] = 14m,
                [17] = 75m,
                [18] = 45m,
                [19] = 20m,
                [20] = 25m
            };

            var list = new List<Product>(capacity: 200);

            for (int id = 1; id <= 200; id++)
            {
                var categoryId = categoryIds[(id - 1) % categoryIds.Length];

                var adjective = adjectives[id % adjectives.Length];
                var brand = brands[id % brands.Length];

                var baseNames = baseNamesByCategory[categoryId];
                var baseName = baseNames[id % baseNames.Length];

                var name = $"{adjective} {baseName} #{id:D3}";

                var description =
                    $"High-quality {baseName.ToLowerInvariant()} designed for comfort and daily wear. " +
                    $"Balanced fit, durable stitching, and easy styling for multiple outfits. " +
                    $"Model: {id:D3}.";

                var basePrice = basePriceByCategory[categoryId];
                var price = basePrice + (id % 15) * 1.25m;

                list.Add(new Product
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Price = decimal.Round(price, 2),
                    Brand = brand,
                    CategoryId = categoryId,
                    IsActive = true,
                    CreatedAt = seedDate,
                    ModifiedAt = seedDate
                });
            }

            return list;
        }
    }
}

