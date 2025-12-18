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

        private static List<Category> SeedCategories()
        {
            return new List<Category>
            {
                new() { Id = 1,  Name = "T-Shirts",        Description = "Everyday t-shirts in different fits, colors, and styles." },
                new() { Id = 2,  Name = "Hoodies",         Description = "Warm hoodies for casual wear and layering." },
                new() { Id = 3,  Name = "Jeans",           Description = "Denim jeans in slim, straight, and relaxed fits." },
                new() { Id = 4,  Name = "Jackets",         Description = "Outerwear for all seasons: bombers, puffers, and more." },
                new() { Id = 5,  Name = "Shoes",           Description = "Sneakers and casual shoes for everyday comfort and style." },
                new() { Id = 6,  Name = "Sweatpants",      Description = "Comfort-first pants for lounging, training, and daily wear." },
                new() { Id = 7,  Name = "Shorts",          Description = "Lightweight shorts for summer, sport, and casual outfits." },
                new() { Id = 8,  Name = "Shirts",          Description = "Button-up shirts: casual, smart-casual, and essentials." },
                new() { Id = 9,  Name = "Knitwear",        Description = "Sweaters, cardigans, and knitted essentials." },
                new() { Id = 10, Name = "Coats",           Description = "Winter and transitional coats with modern silhouettes." },
                new() { Id = 11, Name = "Activewear",      Description = "Performance clothing for running, gym and outdoor." },
                new() { Id = 12, Name = "Underwear",       Description = "Everyday underwear basics with comfort materials." },
                new() { Id = 13, Name = "Socks",           Description = "Crew, ankle and sport socks in multipacks." },
                new() { Id = 14, Name = "Accessories",     Description = "Belts, wallets, sunglasses and small essentials." },
                new() { Id = 15, Name = "Bags",            Description = "Backpacks, crossbody bags and travel-ready options." },
                new() { Id = 16, Name = "Hats",            Description = "Caps, beanies and seasonal headwear." },
                new() { Id = 17, Name = "Dresses",         Description = "Casual and smart dresses for different occasions." },
                new() { Id = 18, Name = "Skirts",          Description = "Mini, midi and maxi skirts with versatile styling." },
                new() { Id = 19, Name = "Kids",            Description = "Kidswear essentials: comfy, durable, easy-care." },
                new() { Id = 20, Name = "Sale",            Description = "Discounted items and last sizes. Limited availability." }
            };
        }
    }
}