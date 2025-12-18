//using ClothingStore.Infrastructure.Data.Entities;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;

//namespace ClothingStore.Infrastructure.Data.Configuration
//{
//    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
//    {
//        public void Configure(EntityTypeBuilder<ProductVariant> builder)
//        {
//            builder.HasData(SeedVariants());
//        }

//        private List<ProductVariant> SeedVariants()
//        {
//            return new List<ProductVariant>
//            {
//                new ProductVariant
//                {
//                    Id = 1,
//                    ProductId = 1,   // Classic Cotton T-Shirt
//                    ColorId = 1,     // White
//                    Size = "M",
//                    Stock = 120,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 2,
//                    ProductId = 2,   // Oversized Graphic Tee
//                    ColorId = 2,     // Black
//                    Size = "L",
//                    Stock = 80,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 3,
//                    ProductId = 3,   // Premium Hoodie
//                    ColorId = 3,     // Gray
//                    Size = "M",
//                    Stock = 60,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 4,
//                    ProductId = 4,   // Zip-Up Hoodie
//                    ColorId = 4,     // Navy
//                    Size = "S",
//                    Stock = 45,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 5,
//                    ProductId = 5,   // Slim Fit Jeans
//                    ColorId = 5,     // Dark Blue
//                    Size = "32",
//                    Stock = 70,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 6,
//                    ProductId = 6,   // Straight Fit Jeans
//                    ColorId = 6,     // Light Blue
//                    Size = "34",
//                    Stock = 55,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 7,
//                    ProductId = 7,   // Lightweight Bomber Jacket
//                    ColorId = 7,     // Olive
//                    Size = "L",
//                    Stock = 30,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 8,
//                    ProductId = 8,   // Puffer Jacket
//                    ColorId = 2,     // Black
//                    Size = "M",
//                    Stock = 25,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 9,
//                    ProductId = 9,   // Running Sneakers
//                    ColorId = 8,     // White/Gray
//                    Size = "42",
//                    Stock = 40,
//                    IsActive = true
//                },
//                new ProductVariant
//                {
//                    Id = 10,
//                    ProductId = 10,  // Casual Leather Sneakers
//                    ColorId = 1,     // White
//                    Size = "43",
//                    Stock = 35,
//                    IsActive = true
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
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasData(SeedVariants());
        }

        private static List<ProductVariant> SeedVariants()
        {
            const int colorCount = 30;

            var apparelSizes = new[] { "XS", "S", "M", "L", "XL" };
            var kidsSizes = new[] { "98", "104", "110", "116", "122", "128", "134", "140" };
            var jeansSizes = new[] { "30", "31", "32", "33", "34", "36" };
            var shoeSizes = new[] { "40", "41", "42", "43", "44", "45" };

            var variants = new List<ProductVariant>(capacity: 400);
            int variantId = 1;

            for (int productId = 1; productId <= 200; productId++)
            {
                var color1 = ((productId * 3) % colorCount) + 1;
                var color2 = ((productId * 7) % colorCount) + 1;
                if (color2 == color1) color2 = (color2 % colorCount) + 1;

                var categoryId = ((productId - 1) % 20) + 1;

                string PickSize(int p, int c, int offset)
                {
                    if (c == 5) return shoeSizes[(p + offset) % shoeSizes.Length];
                    if (c == 3) return jeansSizes[(p + offset) % jeansSizes.Length];
                    if (c == 19) return kidsSizes[(p + offset) % kidsSizes.Length];
                    return apparelSizes[(p + offset) % apparelSizes.Length];
                }

                var sizeA = PickSize(productId, categoryId, 0);
                var sizeB = PickSize(productId, categoryId, 2);

                int StockFor(int p, int mult) => 10 + ((p * mult) % 120);

                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = productId,
                    ColorId = color1,
                    Size = sizeA,
                    Stock = StockFor(productId, 5),
                    IsActive = true
                });

                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = productId,
                    ColorId = color2,
                    Size = sizeB,
                    Stock = StockFor(productId, 9),
                    IsActive = true
                });
            }

            return variants;
        }
    }
}

