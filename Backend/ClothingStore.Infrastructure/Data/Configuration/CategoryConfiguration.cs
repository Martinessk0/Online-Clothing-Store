using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<Category> SeedCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "T-Shirts",
                    Description = "Everyday t-shirts in different fits, colors, and styles.",
                },
                new Category
                {
                    Id = 2,
                    Name = "Hoodies",
                    Description = "Warm and comfortable hoodies for casual wear and layering.",
                },
                new Category
                {
                    Id = 3,
                    Name = "Jeans",
                    Description = "Denim jeans in slim, straight, and relaxed fits.",
                },
                new Category
                {
                    Id = 4,
                    Name = "Jackets",
                    Description = "Outerwear for all seasons: bombers, puffers, and more.",
                },
                new Category
                {
                    Id = 5,
                    Name = "Shoes",
                    Description = "Sneakers and casual shoes for everyday comfort and style.",
                }
            };
        }
    }
}