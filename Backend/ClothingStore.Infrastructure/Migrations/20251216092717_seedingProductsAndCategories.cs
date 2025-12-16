using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Everyday t-shirts in different fits, colors, and styles.", true, "T-Shirts" },
                    { 2, "Warm and comfortable hoodies for casual wear and layering.", true, "Hoodies" },
                    { 3, "Denim jeans in slim, straight, and relaxed fits.", true, "Jeans" },
                    { 4, "Outerwear for all seasons: bombers, puffers, and more.", true, "Jackets" },
                    { 5, "Sneakers and casual shoes for everyday comfort and style.", true, "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Color", "CreatedAt", "Description", "IsActive", "ModifiedAt", "Name", "Price", "Size", "Stock" },
                values: new object[,]
                {
                    { 1, "UrbanBasics", 1, "White", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft 100% cotton t-shirt with a regular fit. Easy to pair with jeans or shorts.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Cotton T-Shirt", 24.99m, "M", 120 },
                    { 2, "StreetLab", 1, "Black", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized fit t-shirt with a minimal front print and bold back graphic.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Graphic Tee", 29.99m, "L", 80 },
                    { 3, "NorthWear", 2, "Gray", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Warm fleece-lined hoodie with a kangaroo pocket and adjustable drawstrings.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Hoodie", 59.90m, "M", 60 },
                    { 4, "NorthWear", 2, "Navy", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Everyday zip-up hoodie with soft interior, perfect for layering.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Zip-Up Hoodie", 54.50m, "S", 45 },
                    { 5, "DenimCo", 3, "Dark Blue", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim fit jeans with a comfortable stretch. Clean look for casual or smart outfits.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Fit Jeans", 79.00m, "32", 70 },
                    { 6, "DenimCo", 3, "Light Blue", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic straight fit denim with durable stitching and mid-rise waist.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Straight Fit Jeans", 74.00m, "34", 55 },
                    { 7, "AeroStyle", 4, "Olive", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Light bomber jacket with a smooth finish and ribbed cuffs. Great for spring/fall.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Bomber Jacket", 99.99m, "L", 30 },
                    { 8, "AeroStyle", 4, "Black", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Insulated puffer jacket designed for cold days. Water-resistant outer layer.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Puffer Jacket", 149.99m, "M", 25 },
                    { 9, "MoveX", 5, "White/Gray", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable lightweight sneakers with cushioned sole and breathable mesh upper.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Running Sneakers", 89.90m, "42", 40 },
                    { 10, "MoveX", 5, "White", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Minimal leather sneakers for everyday wear. Clean look and durable outsole.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Casual Leather Sneakers", 119.00m, "43", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
