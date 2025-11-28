using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed данни - първоначални записи
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Мъжки дрехи", ParentID = null, IsActive = true },
                new Category { CategoryID = 2, Name = "Дамски дрехи", ParentID = null, IsActive = true },
                new Category { CategoryID = 3, Name = "Тениски", ParentID = 1, IsActive = true }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    Name = "Черна тениска",
                    Description = "Памучна тениска в черен цвят",
                    Price = 29.99m,
                    ImageUrl = "/images/tshirt.jpg",
                    CategoryID = 3,
                    Size = "M",
                    Color = "Черен",
                    Material = "Памук",
                    StockQuantity = 50,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Синя риза",
                    Description = "Елегантна риза за офис",
                    Price = 49.99m,
                    ImageUrl = "/images/shirt.jpg",
                    CategoryID = 1,
                    Size = "L",
                    Color = "Син",
                    Material = "Памук",
                    StockQuantity = 30,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}