using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClothingStore.Infrastructure.Data.Entities;

namespace ClothingStore.Core.Models.Product
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(SeedColors());
        }

        private List<Color> SeedColors()
        {
            return new List<Color>
            {
                new Color { Id = 1, Code = "white",      Name = "Бял",       Hex = "#FFFFFF" },
                new Color { Id = 2, Code = "black",      Name = "Черен",     Hex = "#000000" },
                new Color { Id = 3, Code = "gray",       Name = "Сив",       Hex = "#808080" },
                new Color { Id = 4, Code = "navy",       Name = "Тъмносин",  Hex = "#001F3F" },
                new Color { Id = 5, Code = "dark-blue",  Name = "Тъмно син", Hex = "#00008B" },
                new Color { Id = 6, Code = "light-blue", Name = "Светло син",Hex = "#ADD8E6" },
                new Color { Id = 7, Code = "olive",      Name = "Маслинен",  Hex = "#808000" },
                new Color { Id = 8, Code = "white-gray", Name = "Бяло/сиво", Hex = "#D3D3D3" }
            };
        }
    }
}
