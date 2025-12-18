using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Infrastructure.Data.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(SeedColors());
        }

        private static List<Color> SeedColors()
        {
            return new List<Color>
            {
                new() { Id = 1,  Code = "white",       Name = "Бял",           Hex = "#FFFFFF" },
                new() { Id = 2,  Code = "black",       Name = "Черен",         Hex = "#000000" },
                new() { Id = 3,  Code = "gray",        Name = "Сив",           Hex = "#808080" },
                new() { Id = 4,  Code = "navy",        Name = "Тъмносин",      Hex = "#001F3F" },
                new() { Id = 5,  Code = "blue",        Name = "Син",           Hex = "#1E90FF" },
                new() { Id = 6,  Code = "light-blue",  Name = "Светлосин",     Hex = "#ADD8E6" },
                new() { Id = 7,  Code = "red",         Name = "Червен",        Hex = "#E53935" },
                new() { Id = 8,  Code = "burgundy",    Name = "Бордо",         Hex = "#800020" },
                new() { Id = 9,  Code = "green",       Name = "Зелен",         Hex = "#2E7D32" },
                new() { Id = 10, Code = "olive",       Name = "Маслинен",      Hex = "#808000" },
                new() { Id = 11, Code = "mint",        Name = "Ментов",        Hex = "#98FF98" },
                new() { Id = 12, Code = "yellow",      Name = "Жълт",          Hex = "#FDD835" },
                new() { Id = 13, Code = "mustard",     Name = "Горчица",       Hex = "#D4A017" },
                new() { Id = 14, Code = "orange",      Name = "Оранжев",       Hex = "#FB8C00" },
                new() { Id = 15, Code = "pink",        Name = "Розов",         Hex = "#EC407A" },
                new() { Id = 16, Code = "purple",      Name = "Лилав",         Hex = "#8E24AA" },
                new() { Id = 17, Code = "beige",       Name = "Бежов",         Hex = "#F5F5DC" },
                new() { Id = 18, Code = "cream",       Name = "Крем",          Hex = "#FFFDD0" },
                new() { Id = 19, Code = "brown",       Name = "Кафяв",         Hex = "#6D4C41" },
                new() { Id = 20, Code = "tan",         Name = "Тен",           Hex = "#D2B48C" },
                new() { Id = 21, Code = "khaki",       Name = "Каки",          Hex = "#C3B091" },
                new() { Id = 22, Code = "teal",        Name = "Тийл",          Hex = "#008080" },
                new() { Id = 23, Code = "cyan",        Name = "Циан",          Hex = "#00BCD4" },
                new() { Id = 24, Code = "lime",        Name = "Лайм",          Hex = "#CDDC39" },
                new() { Id = 25, Code = "charcoal",    Name = "Графит",        Hex = "#36454F" },
                new() { Id = 26, Code = "off-white",   Name = "Екрю",          Hex = "#FAF9F6" },
                new() { Id = 27, Code = "silver",      Name = "Сребрист",      Hex = "#C0C0C0" },
                new() { Id = 28, Code = "gold",        Name = "Златист",       Hex = "#D4AF37" },
                new() { Id = 29, Code = "lavender",    Name = "Лавандула",     Hex = "#B39DDB" },
                new() { Id = 30, Code = "peach",       Name = "Праскова",      Hex = "#FFCCBC" },
            };
        }
    }
}
