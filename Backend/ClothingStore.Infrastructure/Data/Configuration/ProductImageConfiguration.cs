using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Infrastructure.Data.Configuration
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(SeedProductImages());
        }

        private static List<ProductImage> SeedProductImages()
        {
            var images = new List<ProductImage>(capacity: 200);

            for (int productId = 1; productId <= 200; productId++)
            {
                var categoryId = GetCategoryId(productId);
                var keyword = CategoryKeyword(categoryId);

                images.Add(new ProductImage
                {
                    Id = productId,
                    ProductId = productId,
                    Url = BuildImageUrl(keyword, productId),
                    PublicId = $"seed/{keyword}-{productId:D3}",
                    IsMain = true,
                    SortOrder = 0
                });
            }

            return images;
        }

        // ВАЖНО: да е същата логика като при ProductConfiguration, за да "познаваме" категорията по productId
        private static int GetCategoryId(int productId) => ((productId - 1) % 20) + 1;

        private static string CategoryKeyword(int categoryId) => categoryId switch
        {
            1 => "tshirt",
            2 => "hoodie",
            3 => "jeans",
            4 => "jacket",
            5 => "sneakers",
            6 => "sweatpants",
            7 => "shorts",
            8 => "shirt",
            9 => "knitwear",
            10 => "coat",
            11 => "activewear",
            12 => "underwear",
            13 => "socks",
            14 => "accessories",
            15 => "bag",
            16 => "hat",
            17 => "dress",
            18 => "skirt",
            19 => "kids-clothing",
            20 => "clothing",
            _ => "clothing"
        };

        private static string BuildImageUrl(string keyword, int productId)
        {
            // lock прави снимката стабилна за този продукт (не се сменя при refresh)
            return $"https://loremflickr.com/800/1000/{keyword}?lock={productId}";
        }
    }
}
