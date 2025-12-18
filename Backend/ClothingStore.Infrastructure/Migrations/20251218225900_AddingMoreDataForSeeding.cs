using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingMoreDataForSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Warm hoodies for casual wear and layering.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 6, "Comfort-first pants for lounging, training, and daily wear.", true, "Sweatpants" },
                    { 7, "Lightweight shorts for summer, sport, and casual outfits.", true, "Shorts" },
                    { 8, "Button-up shirts: casual, smart-casual, and essentials.", true, "Shirts" },
                    { 9, "Sweaters, cardigans, and knitted essentials.", true, "Knitwear" },
                    { 10, "Winter and transitional coats with modern silhouettes.", true, "Coats" },
                    { 11, "Performance clothing for running, gym and outdoor.", true, "Activewear" },
                    { 12, "Everyday underwear basics with comfort materials.", true, "Underwear" },
                    { 13, "Crew, ankle and sport socks in multipacks.", true, "Socks" },
                    { 14, "Belts, wallets, sunglasses and small essentials.", true, "Accessories" },
                    { 15, "Backpacks, crossbody bags and travel-ready options.", true, "Bags" },
                    { 16, "Caps, beanies and seasonal headwear.", true, "Hats" },
                    { 17, "Casual and smart dresses for different occasions.", true, "Dresses" },
                    { 18, "Mini, midi and maxi skirts with versatile styling.", true, "Skirts" },
                    { 19, "Kidswear essentials: comfy, durable, easy-care.", true, "Kids" },
                    { 20, "Discounted items and last sizes. Limited availability.", true, "Sale" }
                });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "Hex", "Name" },
                values: new object[] { "blue", "#1E90FF", "Син" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Светлосин");

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "Hex", "Name" },
                values: new object[] { "red", "#E53935", "Червен" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "Hex", "Name" },
                values: new object[] { "burgundy", "#800020", "Бордо" });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "Hex", "Name" },
                values: new object[,]
                {
                    { 9, "green", "#2E7D32", "Зелен" },
                    { 10, "olive", "#808000", "Маслинен" },
                    { 11, "mint", "#98FF98", "Ментов" },
                    { 12, "yellow", "#FDD835", "Жълт" },
                    { 13, "mustard", "#D4A017", "Горчица" },
                    { 14, "orange", "#FB8C00", "Оранжев" },
                    { 15, "pink", "#EC407A", "Розов" },
                    { 16, "purple", "#8E24AA", "Лилав" },
                    { 17, "beige", "#F5F5DC", "Бежов" },
                    { 18, "cream", "#FFFDD0", "Крем" },
                    { 19, "brown", "#6D4C41", "Кафяв" },
                    { 20, "tan", "#D2B48C", "Тен" },
                    { 21, "khaki", "#C3B091", "Каки" },
                    { 22, "teal", "#008080", "Тийл" },
                    { 23, "cyan", "#00BCD4", "Циан" },
                    { 24, "lime", "#CDDC39", "Лайм" },
                    { 25, "charcoal", "#36454F", "Графит" },
                    { 26, "off-white", "#FAF9F6", "Екрю" },
                    { 27, "silver", "#C0C0C0", "Сребрист" },
                    { 28, "gold", "#D4AF37", "Златист" },
                    { 29, "lavender", "#B39DDB", "Лавандула" },
                    { 30, "peach", "#FFCCBC", "Праскова" }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "IsMain", "ProductId", "PublicId", "SortOrder", "Url" },
                values: new object[,]
                {
                    { 1, true, 1, "seed/clothing-001", 0, "https://picsum.photos/seed/clothing-001/800/1000" },
                    { 2, true, 2, "seed/clothing-002", 0, "https://picsum.photos/seed/clothing-002/800/1000" },
                    { 3, true, 3, "seed/clothing-003", 0, "https://picsum.photos/seed/clothing-003/800/1000" },
                    { 4, true, 4, "seed/clothing-004", 0, "https://picsum.photos/seed/clothing-004/800/1000" },
                    { 5, true, 5, "seed/clothing-005", 0, "https://picsum.photos/seed/clothing-005/800/1000" },
                    { 6, true, 6, "seed/clothing-006", 0, "https://picsum.photos/seed/clothing-006/800/1000" },
                    { 7, true, 7, "seed/clothing-007", 0, "https://picsum.photos/seed/clothing-007/800/1000" },
                    { 8, true, 8, "seed/clothing-008", 0, "https://picsum.photos/seed/clothing-008/800/1000" },
                    { 9, true, 9, "seed/clothing-009", 0, "https://picsum.photos/seed/clothing-009/800/1000" },
                    { 10, true, 10, "seed/clothing-010", 0, "https://picsum.photos/seed/clothing-010/800/1000" }
                });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorId", "Size", "Stock" },
                values: new object[] { 4, "S", 15 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColorId", "ProductId", "Stock" },
                values: new object[] { 8, 1, 19 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColorId", "ProductId", "Stock" },
                values: new object[] { 7, 2, 20 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 15, 2, "XL", 28 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 10, 3, "33", 25 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 22, 3, "36", 37 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ColorId", "ProductId", "Size" },
                values: new object[] { 13, 4, "XL" });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 29, 4, "S", 46 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 16, 5, "45", 35 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 6, 5, "41", 55 });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "Id", "ColorId", "IsActive", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { 18, 4, true, 9, "S", 91 },
                    { 19, 1, true, 10, "XS", 60 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "Name", "Price" },
                values: new object[] { "StreetLab", "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 001.", "Premium Graphic Tee #001", 23.25m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "NorthWear", 2, "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 002.", "Essential Fleece Hoodie #002", 57.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "DenimCo", 3, "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 003.", "Oversized Straight Jeans #003", 73.75m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "AeroStyle", 4, "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 004.", "Relaxed Bomber Jacket #004", 100.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "MoveX", 5, "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 005.", "Slim Leather Sneakers #005", 91.25m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "CoreLine", 6, "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 006.", "Regular Fleece Pants #006", 52.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "PulseActive", 7, "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 007.", "Vintage Denim Shorts #007", 36.75m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "MinimalForm", 8, "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 008.", "Modern Oxford Shirt #008", 59.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "StudioKnit", 9, "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 009.", "Lightweight Cardigan #009", 71.25m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "CityTailor", 10, "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 010.", "Heavyweight Trench Coat #010", 132.50m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "IsActive", "ModifiedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 21, "CoreLine", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 021.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Graphic Tee #021", 29.50m },
                    { 22, "PulseActive", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 022.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Fleece Hoodie #022", 63.75m },
                    { 23, "MinimalForm", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 023.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Straight Jeans #023", 80.00m },
                    { 24, "StudioKnit", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 024.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Bomber Jacket #024", 106.25m },
                    { 25, "CityTailor", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 025.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Leather Sneakers #025", 97.50m },
                    { 41, "DailyCraft", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 041.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Graphic Tee #041", 35.75m },
                    { 42, "NovaFit", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 042.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Fleece Hoodie #042", 70.00m },
                    { 43, "Heritage", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 043.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Straight Jeans #043", 86.25m },
                    { 44, "MonoWear", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 044.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Bomber Jacket #044", 112.50m },
                    { 45, "UrbanBasics", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 045.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Leather Sneakers #045", 85.00m },
                    { 61, "StreetLab", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 061.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Graphic Tee #061", 23.25m },
                    { 62, "NorthWear", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 062.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Fleece Hoodie #062", 57.50m },
                    { 63, "DenimCo", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 063.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Straight Jeans #063", 73.75m },
                    { 64, "AeroStyle", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 064.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Bomber Jacket #064", 100.00m },
                    { 65, "MoveX", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 065.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Leather Sneakers #065", 91.25m },
                    { 81, "CoreLine", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 081.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Graphic Tee #081", 29.50m },
                    { 82, "PulseActive", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 082.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Fleece Hoodie #082", 63.75m },
                    { 83, "MinimalForm", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 083.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Straight Jeans #083", 80.00m },
                    { 84, "StudioKnit", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 084.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Bomber Jacket #084", 106.25m },
                    { 85, "CityTailor", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 085.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Leather Sneakers #085", 97.50m },
                    { 101, "DailyCraft", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 101.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Graphic Tee #101", 35.75m },
                    { 102, "NovaFit", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 102.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Fleece Hoodie #102", 70.00m },
                    { 103, "Heritage", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 103.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Straight Jeans #103", 86.25m },
                    { 104, "MonoWear", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 104.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Bomber Jacket #104", 112.50m },
                    { 105, "UrbanBasics", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 105.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Leather Sneakers #105", 85.00m },
                    { 121, "StreetLab", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 121.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Graphic Tee #121", 23.25m },
                    { 122, "NorthWear", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 122.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Fleece Hoodie #122", 57.50m },
                    { 123, "DenimCo", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 123.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Straight Jeans #123", 73.75m },
                    { 124, "AeroStyle", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 124.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Bomber Jacket #124", 100.00m },
                    { 125, "MoveX", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 125.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Leather Sneakers #125", 91.25m },
                    { 141, "CoreLine", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 141.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Graphic Tee #141", 29.50m },
                    { 142, "PulseActive", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 142.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Fleece Hoodie #142", 63.75m },
                    { 143, "MinimalForm", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 143.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Straight Jeans #143", 80.00m },
                    { 144, "StudioKnit", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 144.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Bomber Jacket #144", 106.25m },
                    { 145, "CityTailor", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 145.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Leather Sneakers #145", 97.50m },
                    { 161, "DailyCraft", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 161.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Graphic Tee #161", 35.75m },
                    { 162, "NovaFit", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 162.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Fleece Hoodie #162", 70.00m },
                    { 163, "Heritage", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 163.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Straight Jeans #163", 86.25m },
                    { 164, "MonoWear", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 164.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Bomber Jacket #164", 112.50m },
                    { 165, "UrbanBasics", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 165.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Leather Sneakers #165", 85.00m },
                    { 181, "StreetLab", 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality graphic tee designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 181.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Graphic Tee #181", 23.25m },
                    { 182, "NorthWear", 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece hoodie designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 182.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Fleece Hoodie #182", 57.50m },
                    { 183, "DenimCo", 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality straight jeans designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 183.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Straight Jeans #183", 73.75m },
                    { 184, "AeroStyle", 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality bomber jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 184.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Bomber Jacket #184", 100.00m },
                    { 185, "MoveX", 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality leather sneakers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 185.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Leather Sneakers #185", 91.25m }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "IsMain", "ProductId", "PublicId", "SortOrder", "Url" },
                values: new object[,]
                {
                    { 21, true, 21, "seed/clothing-021", 0, "https://picsum.photos/seed/clothing-021/800/1000" },
                    { 22, true, 22, "seed/clothing-022", 0, "https://picsum.photos/seed/clothing-022/800/1000" },
                    { 23, true, 23, "seed/clothing-023", 0, "https://picsum.photos/seed/clothing-023/800/1000" },
                    { 24, true, 24, "seed/clothing-024", 0, "https://picsum.photos/seed/clothing-024/800/1000" },
                    { 25, true, 25, "seed/clothing-025", 0, "https://picsum.photos/seed/clothing-025/800/1000" },
                    { 41, true, 41, "seed/clothing-041", 0, "https://picsum.photos/seed/clothing-041/800/1000" },
                    { 42, true, 42, "seed/clothing-042", 0, "https://picsum.photos/seed/clothing-042/800/1000" },
                    { 43, true, 43, "seed/clothing-043", 0, "https://picsum.photos/seed/clothing-043/800/1000" },
                    { 44, true, 44, "seed/clothing-044", 0, "https://picsum.photos/seed/clothing-044/800/1000" },
                    { 45, true, 45, "seed/clothing-045", 0, "https://picsum.photos/seed/clothing-045/800/1000" },
                    { 61, true, 61, "seed/clothing-061", 0, "https://picsum.photos/seed/clothing-061/800/1000" },
                    { 62, true, 62, "seed/clothing-062", 0, "https://picsum.photos/seed/clothing-062/800/1000" },
                    { 63, true, 63, "seed/clothing-063", 0, "https://picsum.photos/seed/clothing-063/800/1000" },
                    { 64, true, 64, "seed/clothing-064", 0, "https://picsum.photos/seed/clothing-064/800/1000" },
                    { 65, true, 65, "seed/clothing-065", 0, "https://picsum.photos/seed/clothing-065/800/1000" },
                    { 81, true, 81, "seed/clothing-081", 0, "https://picsum.photos/seed/clothing-081/800/1000" },
                    { 82, true, 82, "seed/clothing-082", 0, "https://picsum.photos/seed/clothing-082/800/1000" },
                    { 83, true, 83, "seed/clothing-083", 0, "https://picsum.photos/seed/clothing-083/800/1000" },
                    { 84, true, 84, "seed/clothing-084", 0, "https://picsum.photos/seed/clothing-084/800/1000" },
                    { 85, true, 85, "seed/clothing-085", 0, "https://picsum.photos/seed/clothing-085/800/1000" },
                    { 101, true, 101, "seed/clothing-101", 0, "https://picsum.photos/seed/clothing-101/800/1000" },
                    { 102, true, 102, "seed/clothing-102", 0, "https://picsum.photos/seed/clothing-102/800/1000" },
                    { 103, true, 103, "seed/clothing-103", 0, "https://picsum.photos/seed/clothing-103/800/1000" },
                    { 104, true, 104, "seed/clothing-104", 0, "https://picsum.photos/seed/clothing-104/800/1000" },
                    { 105, true, 105, "seed/clothing-105", 0, "https://picsum.photos/seed/clothing-105/800/1000" },
                    { 121, true, 121, "seed/clothing-121", 0, "https://picsum.photos/seed/clothing-121/800/1000" },
                    { 122, true, 122, "seed/clothing-122", 0, "https://picsum.photos/seed/clothing-122/800/1000" },
                    { 123, true, 123, "seed/clothing-123", 0, "https://picsum.photos/seed/clothing-123/800/1000" },
                    { 124, true, 124, "seed/clothing-124", 0, "https://picsum.photos/seed/clothing-124/800/1000" },
                    { 125, true, 125, "seed/clothing-125", 0, "https://picsum.photos/seed/clothing-125/800/1000" },
                    { 141, true, 141, "seed/clothing-141", 0, "https://picsum.photos/seed/clothing-141/800/1000" },
                    { 142, true, 142, "seed/clothing-142", 0, "https://picsum.photos/seed/clothing-142/800/1000" },
                    { 143, true, 143, "seed/clothing-143", 0, "https://picsum.photos/seed/clothing-143/800/1000" },
                    { 144, true, 144, "seed/clothing-144", 0, "https://picsum.photos/seed/clothing-144/800/1000" },
                    { 145, true, 145, "seed/clothing-145", 0, "https://picsum.photos/seed/clothing-145/800/1000" },
                    { 161, true, 161, "seed/clothing-161", 0, "https://picsum.photos/seed/clothing-161/800/1000" },
                    { 162, true, 162, "seed/clothing-162", 0, "https://picsum.photos/seed/clothing-162/800/1000" },
                    { 163, true, 163, "seed/clothing-163", 0, "https://picsum.photos/seed/clothing-163/800/1000" },
                    { 164, true, 164, "seed/clothing-164", 0, "https://picsum.photos/seed/clothing-164/800/1000" },
                    { 165, true, 165, "seed/clothing-165", 0, "https://picsum.photos/seed/clothing-165/800/1000" },
                    { 181, true, 181, "seed/clothing-181", 0, "https://picsum.photos/seed/clothing-181/800/1000" },
                    { 182, true, 182, "seed/clothing-182", 0, "https://picsum.photos/seed/clothing-182/800/1000" },
                    { 183, true, 183, "seed/clothing-183", 0, "https://picsum.photos/seed/clothing-183/800/1000" },
                    { 184, true, 184, "seed/clothing-184", 0, "https://picsum.photos/seed/clothing-184/800/1000" },
                    { 185, true, 185, "seed/clothing-185", 0, "https://picsum.photos/seed/clothing-185/800/1000" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "Id", "ColorId", "IsActive", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { 11, 19, true, 6, "S", 40 },
                    { 12, 13, true, 6, "L", 64 },
                    { 13, 22, true, 7, "M", 45 },
                    { 14, 20, true, 7, "XL", 73 },
                    { 15, 25, true, 8, "L", 50 },
                    { 16, 27, true, 8, "XS", 82 },
                    { 17, 28, true, 9, "XL", 55 },
                    { 20, 11, true, 10, "M", 100 },
                    { 41, 4, true, 21, "S", 115 },
                    { 42, 28, true, 21, "L", 79 },
                    { 43, 7, true, 22, "M", 120 },
                    { 44, 5, true, 22, "XL", 88 },
                    { 45, 10, true, 23, "36", 125 },
                    { 46, 12, true, 23, "31", 97 },
                    { 47, 13, true, 24, "XL", 10 },
                    { 48, 19, true, 24, "S", 106 },
                    { 49, 16, true, 25, "41", 15 },
                    { 50, 26, true, 25, "43", 115 },
                    { 81, 4, true, 41, "S", 95 },
                    { 82, 18, true, 41, "L", 19 },
                    { 83, 7, true, 42, "M", 100 },
                    { 84, 25, true, 42, "XL", 28 },
                    { 85, 10, true, 43, "31", 105 },
                    { 86, 2, true, 43, "33", 37 },
                    { 87, 13, true, 44, "XL", 110 },
                    { 88, 9, true, 44, "S", 46 },
                    { 89, 16, true, 45, "43", 115 },
                    { 90, 17, true, 45, "45", 55 },
                    { 121, 4, true, 61, "S", 75 },
                    { 122, 8, true, 61, "L", 79 },
                    { 123, 7, true, 62, "M", 80 },
                    { 124, 15, true, 62, "XL", 88 },
                    { 125, 10, true, 63, "33", 85 },
                    { 126, 22, true, 63, "36", 97 },
                    { 127, 13, true, 64, "XL", 90 },
                    { 128, 29, true, 64, "S", 106 },
                    { 129, 16, true, 65, "45", 95 },
                    { 130, 6, true, 65, "41", 115 },
                    { 161, 4, true, 81, "S", 55 },
                    { 162, 28, true, 81, "L", 19 },
                    { 163, 7, true, 82, "M", 60 },
                    { 164, 5, true, 82, "XL", 28 },
                    { 165, 10, true, 83, "36", 65 },
                    { 166, 12, true, 83, "31", 37 },
                    { 167, 13, true, 84, "XL", 70 },
                    { 168, 19, true, 84, "S", 46 },
                    { 169, 16, true, 85, "41", 75 },
                    { 170, 26, true, 85, "43", 55 },
                    { 201, 4, true, 101, "S", 35 },
                    { 202, 18, true, 101, "L", 79 },
                    { 203, 7, true, 102, "M", 40 },
                    { 204, 25, true, 102, "XL", 88 },
                    { 205, 10, true, 103, "31", 45 },
                    { 206, 2, true, 103, "33", 97 },
                    { 207, 13, true, 104, "XL", 50 },
                    { 208, 9, true, 104, "S", 106 },
                    { 209, 16, true, 105, "43", 55 },
                    { 210, 17, true, 105, "45", 115 },
                    { 241, 4, true, 121, "S", 15 },
                    { 242, 8, true, 121, "L", 19 },
                    { 243, 7, true, 122, "M", 20 },
                    { 244, 15, true, 122, "XL", 28 },
                    { 245, 10, true, 123, "33", 25 },
                    { 246, 22, true, 123, "36", 37 },
                    { 247, 13, true, 124, "XL", 30 },
                    { 248, 29, true, 124, "S", 46 },
                    { 249, 16, true, 125, "45", 35 },
                    { 250, 6, true, 125, "41", 55 },
                    { 281, 4, true, 141, "S", 115 },
                    { 282, 28, true, 141, "L", 79 },
                    { 283, 7, true, 142, "M", 120 },
                    { 284, 5, true, 142, "XL", 88 },
                    { 285, 10, true, 143, "36", 125 },
                    { 286, 12, true, 143, "31", 97 },
                    { 287, 13, true, 144, "XL", 10 },
                    { 288, 19, true, 144, "S", 106 },
                    { 289, 16, true, 145, "41", 15 },
                    { 290, 26, true, 145, "43", 115 },
                    { 321, 4, true, 161, "S", 95 },
                    { 322, 18, true, 161, "L", 19 },
                    { 323, 7, true, 162, "M", 100 },
                    { 324, 25, true, 162, "XL", 28 },
                    { 325, 10, true, 163, "31", 105 },
                    { 326, 2, true, 163, "33", 37 },
                    { 327, 13, true, 164, "XL", 110 },
                    { 328, 9, true, 164, "S", 46 },
                    { 329, 16, true, 165, "43", 115 },
                    { 330, 17, true, 165, "45", 55 },
                    { 361, 4, true, 181, "S", 75 },
                    { 362, 8, true, 181, "L", 79 },
                    { 363, 7, true, 182, "M", 80 },
                    { 364, 15, true, 182, "XL", 88 },
                    { 365, 10, true, 183, "33", 85 },
                    { 366, 22, true, 183, "36", 97 },
                    { 367, 13, true, 184, "XL", 90 },
                    { 368, 29, true, 184, "S", 106 },
                    { 369, 16, true, 185, "45", 95 },
                    { 370, 6, true, 185, "41", 115 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "IsActive", "ModifiedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 11, "DailyCraft", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 011.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Running Jacket #011", 53.75m },
                    { 12, "NovaFit", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 012.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Boxers #012", 33.00m },
                    { 13, "Heritage", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 013.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Ankle Socks #013", 25.25m },
                    { 14, "MonoWear", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 014.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Wallet #014", 32.50m },
                    { 15, "UrbanBasics", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 015.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Tote Bag #015", 35.00m },
                    { 16, "StreetLab", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 016.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Cap #016", 15.25m },
                    { 17, "NorthWear", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 017.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Midi Dress #017", 77.50m },
                    { 18, "DenimCo", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 018.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Denim Skirt #018", 48.75m },
                    { 19, "AeroStyle", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 019.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Kids Jacket #019", 25.00m },
                    { 20, "MoveX", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 020.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Sale Item #020", 31.25m },
                    { 26, "DailyCraft", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 026.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Fleece Pants #026", 58.75m },
                    { 27, "NovaFit", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 027.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Denim Shorts #027", 43.00m },
                    { 28, "Heritage", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 028.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Oxford Shirt #028", 65.25m },
                    { 29, "MonoWear", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 029.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Cardigan #029", 77.50m },
                    { 30, "UrbanBasics", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 030.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Trench Coat #030", 120.00m },
                    { 31, "StreetLab", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 031.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Running Jacket #031", 41.25m },
                    { 32, "NorthWear", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 032.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Boxers #032", 20.50m },
                    { 33, "DenimCo", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 033.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Ankle Socks #033", 12.75m },
                    { 34, "AeroStyle", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 034.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Wallet #034", 20.00m },
                    { 35, "MoveX", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 035.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Tote Bag #035", 41.25m },
                    { 36, "CoreLine", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 036.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Cap #036", 21.50m },
                    { 37, "PulseActive", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 037.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Midi Dress #037", 83.75m },
                    { 38, "MinimalForm", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 038.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Denim Skirt #038", 55.00m },
                    { 39, "StudioKnit", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 039.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Kids Jacket #039", 31.25m },
                    { 40, "CityTailor", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 040.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Sale Item #040", 37.50m },
                    { 46, "StreetLab", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 046.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Fleece Pants #046", 46.25m },
                    { 47, "NorthWear", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 047.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Denim Shorts #047", 30.50m },
                    { 48, "DenimCo", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 048.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Oxford Shirt #048", 52.75m },
                    { 49, "AeroStyle", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 049.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Cardigan #049", 65.00m },
                    { 50, "MoveX", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 050.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Trench Coat #050", 126.25m },
                    { 51, "CoreLine", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 051.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Running Jacket #051", 47.50m },
                    { 52, "PulseActive", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 052.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Boxers #052", 26.75m },
                    { 53, "MinimalForm", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 053.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Ankle Socks #053", 19.00m },
                    { 54, "StudioKnit", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 054.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Wallet #054", 26.25m },
                    { 55, "CityTailor", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 055.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Tote Bag #055", 47.50m },
                    { 56, "DailyCraft", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 056.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Cap #056", 27.75m },
                    { 57, "NovaFit", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 057.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Midi Dress #057", 90.00m },
                    { 58, "Heritage", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 058.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Denim Skirt #058", 61.25m },
                    { 59, "MonoWear", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 059.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Kids Jacket #059", 37.50m },
                    { 60, "UrbanBasics", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 060.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Sale Item #060", 25.00m },
                    { 66, "CoreLine", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 066.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Fleece Pants #066", 52.50m },
                    { 67, "PulseActive", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 067.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Denim Shorts #067", 36.75m },
                    { 68, "MinimalForm", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 068.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Oxford Shirt #068", 59.00m },
                    { 69, "StudioKnit", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 069.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Cardigan #069", 71.25m },
                    { 70, "CityTailor", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 070.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Trench Coat #070", 132.50m },
                    { 71, "DailyCraft", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 071.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Running Jacket #071", 53.75m },
                    { 72, "NovaFit", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 072.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Boxers #072", 33.00m },
                    { 73, "Heritage", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 073.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Ankle Socks #073", 25.25m },
                    { 74, "MonoWear", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 074.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Wallet #074", 32.50m },
                    { 75, "UrbanBasics", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 075.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Tote Bag #075", 35.00m },
                    { 76, "StreetLab", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 076.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Cap #076", 15.25m },
                    { 77, "NorthWear", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 077.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Midi Dress #077", 77.50m },
                    { 78, "DenimCo", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 078.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Denim Skirt #078", 48.75m },
                    { 79, "AeroStyle", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 079.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Kids Jacket #079", 25.00m },
                    { 80, "MoveX", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 080.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Sale Item #080", 31.25m },
                    { 86, "DailyCraft", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 086.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Fleece Pants #086", 58.75m },
                    { 87, "NovaFit", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 087.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Denim Shorts #087", 43.00m },
                    { 88, "Heritage", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 088.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Oxford Shirt #088", 65.25m },
                    { 89, "MonoWear", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 089.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Cardigan #089", 77.50m },
                    { 90, "UrbanBasics", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 090.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Trench Coat #090", 120.00m },
                    { 91, "StreetLab", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 091.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Running Jacket #091", 41.25m },
                    { 92, "NorthWear", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 092.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Boxers #092", 20.50m },
                    { 93, "DenimCo", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 093.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Ankle Socks #093", 12.75m },
                    { 94, "AeroStyle", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 094.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Wallet #094", 20.00m },
                    { 95, "MoveX", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 095.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Tote Bag #095", 41.25m },
                    { 96, "CoreLine", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 096.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Cap #096", 21.50m },
                    { 97, "PulseActive", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 097.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Midi Dress #097", 83.75m },
                    { 98, "MinimalForm", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 098.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Denim Skirt #098", 55.00m },
                    { 99, "StudioKnit", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 099.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Kids Jacket #099", 31.25m },
                    { 100, "CityTailor", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 100.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Sale Item #100", 37.50m },
                    { 106, "StreetLab", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 106.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Fleece Pants #106", 46.25m },
                    { 107, "NorthWear", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 107.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Denim Shorts #107", 30.50m },
                    { 108, "DenimCo", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 108.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Oxford Shirt #108", 52.75m },
                    { 109, "AeroStyle", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 109.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Cardigan #109", 65.00m },
                    { 110, "MoveX", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 110.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Trench Coat #110", 126.25m },
                    { 111, "CoreLine", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 111.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Running Jacket #111", 47.50m },
                    { 112, "PulseActive", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 112.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Boxers #112", 26.75m },
                    { 113, "MinimalForm", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 113.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Ankle Socks #113", 19.00m },
                    { 114, "StudioKnit", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 114.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Wallet #114", 26.25m },
                    { 115, "CityTailor", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 115.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Tote Bag #115", 47.50m },
                    { 116, "DailyCraft", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 116.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Cap #116", 27.75m },
                    { 117, "NovaFit", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 117.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Midi Dress #117", 90.00m },
                    { 118, "Heritage", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 118.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Denim Skirt #118", 61.25m },
                    { 119, "MonoWear", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 119.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Kids Jacket #119", 37.50m },
                    { 120, "UrbanBasics", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 120.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Sale Item #120", 25.00m },
                    { 126, "CoreLine", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 126.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Fleece Pants #126", 52.50m },
                    { 127, "PulseActive", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 127.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Denim Shorts #127", 36.75m },
                    { 128, "MinimalForm", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 128.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Oxford Shirt #128", 59.00m },
                    { 129, "StudioKnit", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 129.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Cardigan #129", 71.25m },
                    { 130, "CityTailor", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 130.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Trench Coat #130", 132.50m },
                    { 131, "DailyCraft", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 131.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Running Jacket #131", 53.75m },
                    { 132, "NovaFit", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 132.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Boxers #132", 33.00m },
                    { 133, "Heritage", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 133.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Ankle Socks #133", 25.25m },
                    { 134, "MonoWear", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 134.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Wallet #134", 32.50m },
                    { 135, "UrbanBasics", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 135.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Tote Bag #135", 35.00m },
                    { 136, "StreetLab", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 136.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Cap #136", 15.25m },
                    { 137, "NorthWear", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 137.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Midi Dress #137", 77.50m },
                    { 138, "DenimCo", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 138.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Denim Skirt #138", 48.75m },
                    { 139, "AeroStyle", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 139.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Kids Jacket #139", 25.00m },
                    { 140, "MoveX", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 140.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Sale Item #140", 31.25m },
                    { 146, "DailyCraft", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 146.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Fleece Pants #146", 58.75m },
                    { 147, "NovaFit", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 147.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Denim Shorts #147", 43.00m },
                    { 148, "Heritage", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 148.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Oxford Shirt #148", 65.25m },
                    { 149, "MonoWear", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 149.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Cardigan #149", 77.50m },
                    { 150, "UrbanBasics", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 150.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Trench Coat #150", 120.00m },
                    { 151, "StreetLab", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 151.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Running Jacket #151", 41.25m },
                    { 152, "NorthWear", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 152.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Boxers #152", 20.50m },
                    { 153, "DenimCo", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 153.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Ankle Socks #153", 12.75m },
                    { 154, "AeroStyle", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 154.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Wallet #154", 20.00m },
                    { 155, "MoveX", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 155.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Tote Bag #155", 41.25m },
                    { 156, "CoreLine", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 156.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Cap #156", 21.50m },
                    { 157, "PulseActive", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 157.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Midi Dress #157", 83.75m },
                    { 158, "MinimalForm", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 158.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Denim Skirt #158", 55.00m },
                    { 159, "StudioKnit", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 159.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Kids Jacket #159", 31.25m },
                    { 160, "CityTailor", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 160.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Sale Item #160", 37.50m },
                    { 166, "StreetLab", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 166.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Fleece Pants #166", 46.25m },
                    { 167, "NorthWear", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 167.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Denim Shorts #167", 30.50m },
                    { 168, "DenimCo", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 168.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Oxford Shirt #168", 52.75m },
                    { 169, "AeroStyle", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 169.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Cardigan #169", 65.00m },
                    { 170, "MoveX", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 170.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Trench Coat #170", 126.25m },
                    { 171, "CoreLine", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 171.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Running Jacket #171", 47.50m },
                    { 172, "PulseActive", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 172.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Boxers #172", 26.75m },
                    { 173, "MinimalForm", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 173.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Ankle Socks #173", 19.00m },
                    { 174, "StudioKnit", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 174.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Wallet #174", 26.25m },
                    { 175, "CityTailor", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 175.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Tote Bag #175", 47.50m },
                    { 176, "DailyCraft", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 176.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Cap #176", 27.75m },
                    { 177, "NovaFit", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 177.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Midi Dress #177", 90.00m },
                    { 178, "Heritage", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 178.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Denim Skirt #178", 61.25m },
                    { 179, "MonoWear", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 179.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Kids Jacket #179", 37.50m },
                    { 180, "UrbanBasics", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 180.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Sale Item #180", 25.00m },
                    { 186, "CoreLine", 6, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality fleece pants designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 186.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Regular Fleece Pants #186", 52.50m },
                    { 187, "PulseActive", 7, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim shorts designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 187.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Vintage Denim Shorts #187", 36.75m },
                    { 188, "MinimalForm", 8, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality oxford shirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 188.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Modern Oxford Shirt #188", 59.00m },
                    { 189, "StudioKnit", 9, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cardigan designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 189.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight Cardigan #189", 71.25m },
                    { 190, "CityTailor", 10, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality trench coat designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 190.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Heavyweight Trench Coat #190", 132.50m },
                    { 191, "DailyCraft", 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality running jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 191.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Soft Running Jacket #191", 53.75m },
                    { 192, "NovaFit", 12, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality boxers designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 192.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Boxers #192", 33.00m },
                    { 193, "Heritage", 13, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality ankle socks designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 193.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Water-Resistant Ankle Socks #193", 25.25m },
                    { 194, "MonoWear", 14, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality wallet designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 194.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy Wallet #194", 32.50m },
                    { 195, "UrbanBasics", 15, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality tote bag designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 195.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Tote Bag #195", 35.00m },
                    { 196, "StreetLab", 16, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality cap designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 196.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Premium Cap #196", 15.25m },
                    { 197, "NorthWear", 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality midi dress designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 197.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Essential Midi Dress #197", 77.50m },
                    { 198, "DenimCo", 18, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality denim skirt designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 198.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Oversized Denim Skirt #198", 48.75m },
                    { 199, "AeroStyle", 19, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality kids jacket designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 199.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Relaxed Kids Jacket #199", 25.00m },
                    { 200, "MoveX", 20, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sale item designed for comfort and daily wear. Balanced fit, durable stitching, and easy styling for multiple outfits. Model: 200.", true, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Slim Sale Item #200", 31.25m }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "IsMain", "ProductId", "PublicId", "SortOrder", "Url" },
                values: new object[,]
                {
                    { 11, true, 11, "seed/clothing-011", 0, "https://picsum.photos/seed/clothing-011/800/1000" },
                    { 12, true, 12, "seed/clothing-012", 0, "https://picsum.photos/seed/clothing-012/800/1000" },
                    { 13, true, 13, "seed/clothing-013", 0, "https://picsum.photos/seed/clothing-013/800/1000" },
                    { 14, true, 14, "seed/clothing-014", 0, "https://picsum.photos/seed/clothing-014/800/1000" },
                    { 15, true, 15, "seed/clothing-015", 0, "https://picsum.photos/seed/clothing-015/800/1000" },
                    { 16, true, 16, "seed/clothing-016", 0, "https://picsum.photos/seed/clothing-016/800/1000" },
                    { 17, true, 17, "seed/clothing-017", 0, "https://picsum.photos/seed/clothing-017/800/1000" },
                    { 18, true, 18, "seed/clothing-018", 0, "https://picsum.photos/seed/clothing-018/800/1000" },
                    { 19, true, 19, "seed/clothing-019", 0, "https://picsum.photos/seed/clothing-019/800/1000" },
                    { 20, true, 20, "seed/clothing-020", 0, "https://picsum.photos/seed/clothing-020/800/1000" },
                    { 26, true, 26, "seed/clothing-026", 0, "https://picsum.photos/seed/clothing-026/800/1000" },
                    { 27, true, 27, "seed/clothing-027", 0, "https://picsum.photos/seed/clothing-027/800/1000" },
                    { 28, true, 28, "seed/clothing-028", 0, "https://picsum.photos/seed/clothing-028/800/1000" },
                    { 29, true, 29, "seed/clothing-029", 0, "https://picsum.photos/seed/clothing-029/800/1000" },
                    { 30, true, 30, "seed/clothing-030", 0, "https://picsum.photos/seed/clothing-030/800/1000" },
                    { 31, true, 31, "seed/clothing-031", 0, "https://picsum.photos/seed/clothing-031/800/1000" },
                    { 32, true, 32, "seed/clothing-032", 0, "https://picsum.photos/seed/clothing-032/800/1000" },
                    { 33, true, 33, "seed/clothing-033", 0, "https://picsum.photos/seed/clothing-033/800/1000" },
                    { 34, true, 34, "seed/clothing-034", 0, "https://picsum.photos/seed/clothing-034/800/1000" },
                    { 35, true, 35, "seed/clothing-035", 0, "https://picsum.photos/seed/clothing-035/800/1000" },
                    { 36, true, 36, "seed/clothing-036", 0, "https://picsum.photos/seed/clothing-036/800/1000" },
                    { 37, true, 37, "seed/clothing-037", 0, "https://picsum.photos/seed/clothing-037/800/1000" },
                    { 38, true, 38, "seed/clothing-038", 0, "https://picsum.photos/seed/clothing-038/800/1000" },
                    { 39, true, 39, "seed/clothing-039", 0, "https://picsum.photos/seed/clothing-039/800/1000" },
                    { 40, true, 40, "seed/clothing-040", 0, "https://picsum.photos/seed/clothing-040/800/1000" },
                    { 46, true, 46, "seed/clothing-046", 0, "https://picsum.photos/seed/clothing-046/800/1000" },
                    { 47, true, 47, "seed/clothing-047", 0, "https://picsum.photos/seed/clothing-047/800/1000" },
                    { 48, true, 48, "seed/clothing-048", 0, "https://picsum.photos/seed/clothing-048/800/1000" },
                    { 49, true, 49, "seed/clothing-049", 0, "https://picsum.photos/seed/clothing-049/800/1000" },
                    { 50, true, 50, "seed/clothing-050", 0, "https://picsum.photos/seed/clothing-050/800/1000" },
                    { 51, true, 51, "seed/clothing-051", 0, "https://picsum.photos/seed/clothing-051/800/1000" },
                    { 52, true, 52, "seed/clothing-052", 0, "https://picsum.photos/seed/clothing-052/800/1000" },
                    { 53, true, 53, "seed/clothing-053", 0, "https://picsum.photos/seed/clothing-053/800/1000" },
                    { 54, true, 54, "seed/clothing-054", 0, "https://picsum.photos/seed/clothing-054/800/1000" },
                    { 55, true, 55, "seed/clothing-055", 0, "https://picsum.photos/seed/clothing-055/800/1000" },
                    { 56, true, 56, "seed/clothing-056", 0, "https://picsum.photos/seed/clothing-056/800/1000" },
                    { 57, true, 57, "seed/clothing-057", 0, "https://picsum.photos/seed/clothing-057/800/1000" },
                    { 58, true, 58, "seed/clothing-058", 0, "https://picsum.photos/seed/clothing-058/800/1000" },
                    { 59, true, 59, "seed/clothing-059", 0, "https://picsum.photos/seed/clothing-059/800/1000" },
                    { 60, true, 60, "seed/clothing-060", 0, "https://picsum.photos/seed/clothing-060/800/1000" },
                    { 66, true, 66, "seed/clothing-066", 0, "https://picsum.photos/seed/clothing-066/800/1000" },
                    { 67, true, 67, "seed/clothing-067", 0, "https://picsum.photos/seed/clothing-067/800/1000" },
                    { 68, true, 68, "seed/clothing-068", 0, "https://picsum.photos/seed/clothing-068/800/1000" },
                    { 69, true, 69, "seed/clothing-069", 0, "https://picsum.photos/seed/clothing-069/800/1000" },
                    { 70, true, 70, "seed/clothing-070", 0, "https://picsum.photos/seed/clothing-070/800/1000" },
                    { 71, true, 71, "seed/clothing-071", 0, "https://picsum.photos/seed/clothing-071/800/1000" },
                    { 72, true, 72, "seed/clothing-072", 0, "https://picsum.photos/seed/clothing-072/800/1000" },
                    { 73, true, 73, "seed/clothing-073", 0, "https://picsum.photos/seed/clothing-073/800/1000" },
                    { 74, true, 74, "seed/clothing-074", 0, "https://picsum.photos/seed/clothing-074/800/1000" },
                    { 75, true, 75, "seed/clothing-075", 0, "https://picsum.photos/seed/clothing-075/800/1000" },
                    { 76, true, 76, "seed/clothing-076", 0, "https://picsum.photos/seed/clothing-076/800/1000" },
                    { 77, true, 77, "seed/clothing-077", 0, "https://picsum.photos/seed/clothing-077/800/1000" },
                    { 78, true, 78, "seed/clothing-078", 0, "https://picsum.photos/seed/clothing-078/800/1000" },
                    { 79, true, 79, "seed/clothing-079", 0, "https://picsum.photos/seed/clothing-079/800/1000" },
                    { 80, true, 80, "seed/clothing-080", 0, "https://picsum.photos/seed/clothing-080/800/1000" },
                    { 86, true, 86, "seed/clothing-086", 0, "https://picsum.photos/seed/clothing-086/800/1000" },
                    { 87, true, 87, "seed/clothing-087", 0, "https://picsum.photos/seed/clothing-087/800/1000" },
                    { 88, true, 88, "seed/clothing-088", 0, "https://picsum.photos/seed/clothing-088/800/1000" },
                    { 89, true, 89, "seed/clothing-089", 0, "https://picsum.photos/seed/clothing-089/800/1000" },
                    { 90, true, 90, "seed/clothing-090", 0, "https://picsum.photos/seed/clothing-090/800/1000" },
                    { 91, true, 91, "seed/clothing-091", 0, "https://picsum.photos/seed/clothing-091/800/1000" },
                    { 92, true, 92, "seed/clothing-092", 0, "https://picsum.photos/seed/clothing-092/800/1000" },
                    { 93, true, 93, "seed/clothing-093", 0, "https://picsum.photos/seed/clothing-093/800/1000" },
                    { 94, true, 94, "seed/clothing-094", 0, "https://picsum.photos/seed/clothing-094/800/1000" },
                    { 95, true, 95, "seed/clothing-095", 0, "https://picsum.photos/seed/clothing-095/800/1000" },
                    { 96, true, 96, "seed/clothing-096", 0, "https://picsum.photos/seed/clothing-096/800/1000" },
                    { 97, true, 97, "seed/clothing-097", 0, "https://picsum.photos/seed/clothing-097/800/1000" },
                    { 98, true, 98, "seed/clothing-098", 0, "https://picsum.photos/seed/clothing-098/800/1000" },
                    { 99, true, 99, "seed/clothing-099", 0, "https://picsum.photos/seed/clothing-099/800/1000" },
                    { 100, true, 100, "seed/clothing-100", 0, "https://picsum.photos/seed/clothing-100/800/1000" },
                    { 106, true, 106, "seed/clothing-106", 0, "https://picsum.photos/seed/clothing-106/800/1000" },
                    { 107, true, 107, "seed/clothing-107", 0, "https://picsum.photos/seed/clothing-107/800/1000" },
                    { 108, true, 108, "seed/clothing-108", 0, "https://picsum.photos/seed/clothing-108/800/1000" },
                    { 109, true, 109, "seed/clothing-109", 0, "https://picsum.photos/seed/clothing-109/800/1000" },
                    { 110, true, 110, "seed/clothing-110", 0, "https://picsum.photos/seed/clothing-110/800/1000" },
                    { 111, true, 111, "seed/clothing-111", 0, "https://picsum.photos/seed/clothing-111/800/1000" },
                    { 112, true, 112, "seed/clothing-112", 0, "https://picsum.photos/seed/clothing-112/800/1000" },
                    { 113, true, 113, "seed/clothing-113", 0, "https://picsum.photos/seed/clothing-113/800/1000" },
                    { 114, true, 114, "seed/clothing-114", 0, "https://picsum.photos/seed/clothing-114/800/1000" },
                    { 115, true, 115, "seed/clothing-115", 0, "https://picsum.photos/seed/clothing-115/800/1000" },
                    { 116, true, 116, "seed/clothing-116", 0, "https://picsum.photos/seed/clothing-116/800/1000" },
                    { 117, true, 117, "seed/clothing-117", 0, "https://picsum.photos/seed/clothing-117/800/1000" },
                    { 118, true, 118, "seed/clothing-118", 0, "https://picsum.photos/seed/clothing-118/800/1000" },
                    { 119, true, 119, "seed/clothing-119", 0, "https://picsum.photos/seed/clothing-119/800/1000" },
                    { 120, true, 120, "seed/clothing-120", 0, "https://picsum.photos/seed/clothing-120/800/1000" },
                    { 126, true, 126, "seed/clothing-126", 0, "https://picsum.photos/seed/clothing-126/800/1000" },
                    { 127, true, 127, "seed/clothing-127", 0, "https://picsum.photos/seed/clothing-127/800/1000" },
                    { 128, true, 128, "seed/clothing-128", 0, "https://picsum.photos/seed/clothing-128/800/1000" },
                    { 129, true, 129, "seed/clothing-129", 0, "https://picsum.photos/seed/clothing-129/800/1000" },
                    { 130, true, 130, "seed/clothing-130", 0, "https://picsum.photos/seed/clothing-130/800/1000" },
                    { 131, true, 131, "seed/clothing-131", 0, "https://picsum.photos/seed/clothing-131/800/1000" },
                    { 132, true, 132, "seed/clothing-132", 0, "https://picsum.photos/seed/clothing-132/800/1000" },
                    { 133, true, 133, "seed/clothing-133", 0, "https://picsum.photos/seed/clothing-133/800/1000" },
                    { 134, true, 134, "seed/clothing-134", 0, "https://picsum.photos/seed/clothing-134/800/1000" },
                    { 135, true, 135, "seed/clothing-135", 0, "https://picsum.photos/seed/clothing-135/800/1000" },
                    { 136, true, 136, "seed/clothing-136", 0, "https://picsum.photos/seed/clothing-136/800/1000" },
                    { 137, true, 137, "seed/clothing-137", 0, "https://picsum.photos/seed/clothing-137/800/1000" },
                    { 138, true, 138, "seed/clothing-138", 0, "https://picsum.photos/seed/clothing-138/800/1000" },
                    { 139, true, 139, "seed/clothing-139", 0, "https://picsum.photos/seed/clothing-139/800/1000" },
                    { 140, true, 140, "seed/clothing-140", 0, "https://picsum.photos/seed/clothing-140/800/1000" },
                    { 146, true, 146, "seed/clothing-146", 0, "https://picsum.photos/seed/clothing-146/800/1000" },
                    { 147, true, 147, "seed/clothing-147", 0, "https://picsum.photos/seed/clothing-147/800/1000" },
                    { 148, true, 148, "seed/clothing-148", 0, "https://picsum.photos/seed/clothing-148/800/1000" },
                    { 149, true, 149, "seed/clothing-149", 0, "https://picsum.photos/seed/clothing-149/800/1000" },
                    { 150, true, 150, "seed/clothing-150", 0, "https://picsum.photos/seed/clothing-150/800/1000" },
                    { 151, true, 151, "seed/clothing-151", 0, "https://picsum.photos/seed/clothing-151/800/1000" },
                    { 152, true, 152, "seed/clothing-152", 0, "https://picsum.photos/seed/clothing-152/800/1000" },
                    { 153, true, 153, "seed/clothing-153", 0, "https://picsum.photos/seed/clothing-153/800/1000" },
                    { 154, true, 154, "seed/clothing-154", 0, "https://picsum.photos/seed/clothing-154/800/1000" },
                    { 155, true, 155, "seed/clothing-155", 0, "https://picsum.photos/seed/clothing-155/800/1000" },
                    { 156, true, 156, "seed/clothing-156", 0, "https://picsum.photos/seed/clothing-156/800/1000" },
                    { 157, true, 157, "seed/clothing-157", 0, "https://picsum.photos/seed/clothing-157/800/1000" },
                    { 158, true, 158, "seed/clothing-158", 0, "https://picsum.photos/seed/clothing-158/800/1000" },
                    { 159, true, 159, "seed/clothing-159", 0, "https://picsum.photos/seed/clothing-159/800/1000" },
                    { 160, true, 160, "seed/clothing-160", 0, "https://picsum.photos/seed/clothing-160/800/1000" },
                    { 166, true, 166, "seed/clothing-166", 0, "https://picsum.photos/seed/clothing-166/800/1000" },
                    { 167, true, 167, "seed/clothing-167", 0, "https://picsum.photos/seed/clothing-167/800/1000" },
                    { 168, true, 168, "seed/clothing-168", 0, "https://picsum.photos/seed/clothing-168/800/1000" },
                    { 169, true, 169, "seed/clothing-169", 0, "https://picsum.photos/seed/clothing-169/800/1000" },
                    { 170, true, 170, "seed/clothing-170", 0, "https://picsum.photos/seed/clothing-170/800/1000" },
                    { 171, true, 171, "seed/clothing-171", 0, "https://picsum.photos/seed/clothing-171/800/1000" },
                    { 172, true, 172, "seed/clothing-172", 0, "https://picsum.photos/seed/clothing-172/800/1000" },
                    { 173, true, 173, "seed/clothing-173", 0, "https://picsum.photos/seed/clothing-173/800/1000" },
                    { 174, true, 174, "seed/clothing-174", 0, "https://picsum.photos/seed/clothing-174/800/1000" },
                    { 175, true, 175, "seed/clothing-175", 0, "https://picsum.photos/seed/clothing-175/800/1000" },
                    { 176, true, 176, "seed/clothing-176", 0, "https://picsum.photos/seed/clothing-176/800/1000" },
                    { 177, true, 177, "seed/clothing-177", 0, "https://picsum.photos/seed/clothing-177/800/1000" },
                    { 178, true, 178, "seed/clothing-178", 0, "https://picsum.photos/seed/clothing-178/800/1000" },
                    { 179, true, 179, "seed/clothing-179", 0, "https://picsum.photos/seed/clothing-179/800/1000" },
                    { 180, true, 180, "seed/clothing-180", 0, "https://picsum.photos/seed/clothing-180/800/1000" },
                    { 186, true, 186, "seed/clothing-186", 0, "https://picsum.photos/seed/clothing-186/800/1000" },
                    { 187, true, 187, "seed/clothing-187", 0, "https://picsum.photos/seed/clothing-187/800/1000" },
                    { 188, true, 188, "seed/clothing-188", 0, "https://picsum.photos/seed/clothing-188/800/1000" },
                    { 189, true, 189, "seed/clothing-189", 0, "https://picsum.photos/seed/clothing-189/800/1000" },
                    { 190, true, 190, "seed/clothing-190", 0, "https://picsum.photos/seed/clothing-190/800/1000" },
                    { 191, true, 191, "seed/clothing-191", 0, "https://picsum.photos/seed/clothing-191/800/1000" },
                    { 192, true, 192, "seed/clothing-192", 0, "https://picsum.photos/seed/clothing-192/800/1000" },
                    { 193, true, 193, "seed/clothing-193", 0, "https://picsum.photos/seed/clothing-193/800/1000" },
                    { 194, true, 194, "seed/clothing-194", 0, "https://picsum.photos/seed/clothing-194/800/1000" },
                    { 195, true, 195, "seed/clothing-195", 0, "https://picsum.photos/seed/clothing-195/800/1000" },
                    { 196, true, 196, "seed/clothing-196", 0, "https://picsum.photos/seed/clothing-196/800/1000" },
                    { 197, true, 197, "seed/clothing-197", 0, "https://picsum.photos/seed/clothing-197/800/1000" },
                    { 198, true, 198, "seed/clothing-198", 0, "https://picsum.photos/seed/clothing-198/800/1000" },
                    { 199, true, 199, "seed/clothing-199", 0, "https://picsum.photos/seed/clothing-199/800/1000" },
                    { 200, true, 200, "seed/clothing-200", 0, "https://picsum.photos/seed/clothing-200/800/1000" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "Id", "ColorId", "IsActive", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { 21, 4, true, 11, "S", 65 },
                    { 22, 18, true, 11, "L", 109 },
                    { 23, 7, true, 12, "M", 70 },
                    { 24, 25, true, 12, "XL", 118 },
                    { 25, 10, true, 13, "L", 75 },
                    { 26, 2, true, 13, "XS", 127 },
                    { 27, 13, true, 14, "XL", 80 },
                    { 28, 9, true, 14, "S", 16 },
                    { 29, 16, true, 15, "XS", 85 },
                    { 30, 17, true, 15, "M", 25 },
                    { 31, 19, true, 16, "S", 90 },
                    { 32, 23, true, 16, "L", 34 },
                    { 33, 22, true, 17, "M", 95 },
                    { 34, 30, true, 17, "XL", 43 },
                    { 35, 25, true, 18, "L", 100 },
                    { 36, 7, true, 18, "XS", 52 },
                    { 37, 28, true, 19, "116", 105 },
                    { 38, 14, true, 19, "128", 61 },
                    { 39, 1, true, 20, "XS", 110 },
                    { 40, 21, true, 20, "M", 70 },
                    { 51, 19, true, 26, "S", 20 },
                    { 52, 3, true, 26, "L", 124 },
                    { 53, 22, true, 27, "M", 25 },
                    { 54, 10, true, 27, "XL", 13 },
                    { 55, 25, true, 28, "L", 30 },
                    { 56, 17, true, 28, "XS", 22 },
                    { 57, 28, true, 29, "XL", 35 },
                    { 58, 24, true, 29, "S", 31 },
                    { 59, 1, true, 30, "XS", 40 },
                    { 60, 2, true, 30, "M", 40 },
                    { 61, 4, true, 31, "S", 45 },
                    { 62, 8, true, 31, "L", 49 },
                    { 63, 7, true, 32, "M", 50 },
                    { 64, 15, true, 32, "XL", 58 },
                    { 65, 10, true, 33, "L", 55 },
                    { 66, 22, true, 33, "XS", 67 },
                    { 67, 13, true, 34, "XL", 60 },
                    { 68, 29, true, 34, "S", 76 },
                    { 69, 16, true, 35, "XS", 65 },
                    { 70, 6, true, 35, "M", 85 },
                    { 71, 19, true, 36, "S", 70 },
                    { 72, 13, true, 36, "L", 94 },
                    { 73, 22, true, 37, "M", 75 },
                    { 74, 20, true, 37, "XL", 103 },
                    { 75, 25, true, 38, "L", 80 },
                    { 76, 27, true, 38, "XS", 112 },
                    { 77, 28, true, 39, "140", 85 },
                    { 78, 4, true, 39, "104", 121 },
                    { 79, 1, true, 40, "XS", 90 },
                    { 80, 11, true, 40, "M", 10 },
                    { 91, 19, true, 46, "S", 120 },
                    { 92, 23, true, 46, "L", 64 },
                    { 93, 22, true, 47, "M", 125 },
                    { 94, 30, true, 47, "XL", 73 },
                    { 95, 25, true, 48, "L", 10 },
                    { 96, 7, true, 48, "XS", 82 },
                    { 97, 28, true, 49, "XL", 15 },
                    { 98, 14, true, 49, "S", 91 },
                    { 99, 1, true, 50, "XS", 20 },
                    { 100, 21, true, 50, "M", 100 },
                    { 101, 4, true, 51, "S", 25 },
                    { 102, 28, true, 51, "L", 109 },
                    { 103, 7, true, 52, "M", 30 },
                    { 104, 5, true, 52, "XL", 118 },
                    { 105, 10, true, 53, "L", 35 },
                    { 106, 12, true, 53, "XS", 127 },
                    { 107, 13, true, 54, "XL", 40 },
                    { 108, 19, true, 54, "S", 16 },
                    { 109, 16, true, 55, "XS", 45 },
                    { 110, 26, true, 55, "M", 25 },
                    { 111, 19, true, 56, "S", 50 },
                    { 112, 3, true, 56, "L", 34 },
                    { 113, 22, true, 57, "M", 55 },
                    { 114, 10, true, 57, "XL", 43 },
                    { 115, 25, true, 58, "L", 60 },
                    { 116, 17, true, 58, "XS", 52 },
                    { 117, 28, true, 59, "116", 65 },
                    { 118, 24, true, 59, "128", 61 },
                    { 119, 1, true, 60, "XS", 70 },
                    { 120, 2, true, 60, "M", 70 },
                    { 131, 19, true, 66, "S", 100 },
                    { 132, 13, true, 66, "L", 124 },
                    { 133, 22, true, 67, "M", 105 },
                    { 134, 20, true, 67, "XL", 13 },
                    { 135, 25, true, 68, "L", 110 },
                    { 136, 27, true, 68, "XS", 22 },
                    { 137, 28, true, 69, "XL", 115 },
                    { 138, 4, true, 69, "S", 31 },
                    { 139, 1, true, 70, "XS", 120 },
                    { 140, 11, true, 70, "M", 40 },
                    { 141, 4, true, 71, "S", 125 },
                    { 142, 18, true, 71, "L", 49 },
                    { 143, 7, true, 72, "M", 10 },
                    { 144, 25, true, 72, "XL", 58 },
                    { 145, 10, true, 73, "L", 15 },
                    { 146, 2, true, 73, "XS", 67 },
                    { 147, 13, true, 74, "XL", 20 },
                    { 148, 9, true, 74, "S", 76 },
                    { 149, 16, true, 75, "XS", 25 },
                    { 150, 17, true, 75, "M", 85 },
                    { 151, 19, true, 76, "S", 30 },
                    { 152, 23, true, 76, "L", 94 },
                    { 153, 22, true, 77, "M", 35 },
                    { 154, 30, true, 77, "XL", 103 },
                    { 155, 25, true, 78, "L", 40 },
                    { 156, 7, true, 78, "XS", 112 },
                    { 157, 28, true, 79, "140", 45 },
                    { 158, 14, true, 79, "104", 121 },
                    { 159, 1, true, 80, "XS", 50 },
                    { 160, 21, true, 80, "M", 10 },
                    { 171, 19, true, 86, "S", 80 },
                    { 172, 3, true, 86, "L", 64 },
                    { 173, 22, true, 87, "M", 85 },
                    { 174, 10, true, 87, "XL", 73 },
                    { 175, 25, true, 88, "L", 90 },
                    { 176, 17, true, 88, "XS", 82 },
                    { 177, 28, true, 89, "XL", 95 },
                    { 178, 24, true, 89, "S", 91 },
                    { 179, 1, true, 90, "XS", 100 },
                    { 180, 2, true, 90, "M", 100 },
                    { 181, 4, true, 91, "S", 105 },
                    { 182, 8, true, 91, "L", 109 },
                    { 183, 7, true, 92, "M", 110 },
                    { 184, 15, true, 92, "XL", 118 },
                    { 185, 10, true, 93, "L", 115 },
                    { 186, 22, true, 93, "XS", 127 },
                    { 187, 13, true, 94, "XL", 120 },
                    { 188, 29, true, 94, "S", 16 },
                    { 189, 16, true, 95, "XS", 125 },
                    { 190, 6, true, 95, "M", 25 },
                    { 191, 19, true, 96, "S", 10 },
                    { 192, 13, true, 96, "L", 34 },
                    { 193, 22, true, 97, "M", 15 },
                    { 194, 20, true, 97, "XL", 43 },
                    { 195, 25, true, 98, "L", 20 },
                    { 196, 27, true, 98, "XS", 52 },
                    { 197, 28, true, 99, "116", 25 },
                    { 198, 4, true, 99, "128", 61 },
                    { 199, 1, true, 100, "XS", 30 },
                    { 200, 11, true, 100, "M", 70 },
                    { 211, 19, true, 106, "S", 60 },
                    { 212, 23, true, 106, "L", 124 },
                    { 213, 22, true, 107, "M", 65 },
                    { 214, 30, true, 107, "XL", 13 },
                    { 215, 25, true, 108, "L", 70 },
                    { 216, 7, true, 108, "XS", 22 },
                    { 217, 28, true, 109, "XL", 75 },
                    { 218, 14, true, 109, "S", 31 },
                    { 219, 1, true, 110, "XS", 80 },
                    { 220, 21, true, 110, "M", 40 },
                    { 221, 4, true, 111, "S", 85 },
                    { 222, 28, true, 111, "L", 49 },
                    { 223, 7, true, 112, "M", 90 },
                    { 224, 5, true, 112, "XL", 58 },
                    { 225, 10, true, 113, "L", 95 },
                    { 226, 12, true, 113, "XS", 67 },
                    { 227, 13, true, 114, "XL", 100 },
                    { 228, 19, true, 114, "S", 76 },
                    { 229, 16, true, 115, "XS", 105 },
                    { 230, 26, true, 115, "M", 85 },
                    { 231, 19, true, 116, "S", 110 },
                    { 232, 3, true, 116, "L", 94 },
                    { 233, 22, true, 117, "M", 115 },
                    { 234, 10, true, 117, "XL", 103 },
                    { 235, 25, true, 118, "L", 120 },
                    { 236, 17, true, 118, "XS", 112 },
                    { 237, 28, true, 119, "140", 125 },
                    { 238, 24, true, 119, "104", 121 },
                    { 239, 1, true, 120, "XS", 10 },
                    { 240, 2, true, 120, "M", 10 },
                    { 251, 19, true, 126, "S", 40 },
                    { 252, 13, true, 126, "L", 64 },
                    { 253, 22, true, 127, "M", 45 },
                    { 254, 20, true, 127, "XL", 73 },
                    { 255, 25, true, 128, "L", 50 },
                    { 256, 27, true, 128, "XS", 82 },
                    { 257, 28, true, 129, "XL", 55 },
                    { 258, 4, true, 129, "S", 91 },
                    { 259, 1, true, 130, "XS", 60 },
                    { 260, 11, true, 130, "M", 100 },
                    { 261, 4, true, 131, "S", 65 },
                    { 262, 18, true, 131, "L", 109 },
                    { 263, 7, true, 132, "M", 70 },
                    { 264, 25, true, 132, "XL", 118 },
                    { 265, 10, true, 133, "L", 75 },
                    { 266, 2, true, 133, "XS", 127 },
                    { 267, 13, true, 134, "XL", 80 },
                    { 268, 9, true, 134, "S", 16 },
                    { 269, 16, true, 135, "XS", 85 },
                    { 270, 17, true, 135, "M", 25 },
                    { 271, 19, true, 136, "S", 90 },
                    { 272, 23, true, 136, "L", 34 },
                    { 273, 22, true, 137, "M", 95 },
                    { 274, 30, true, 137, "XL", 43 },
                    { 275, 25, true, 138, "L", 100 },
                    { 276, 7, true, 138, "XS", 52 },
                    { 277, 28, true, 139, "116", 105 },
                    { 278, 14, true, 139, "128", 61 },
                    { 279, 1, true, 140, "XS", 110 },
                    { 280, 21, true, 140, "M", 70 },
                    { 291, 19, true, 146, "S", 20 },
                    { 292, 3, true, 146, "L", 124 },
                    { 293, 22, true, 147, "M", 25 },
                    { 294, 10, true, 147, "XL", 13 },
                    { 295, 25, true, 148, "L", 30 },
                    { 296, 17, true, 148, "XS", 22 },
                    { 297, 28, true, 149, "XL", 35 },
                    { 298, 24, true, 149, "S", 31 },
                    { 299, 1, true, 150, "XS", 40 },
                    { 300, 2, true, 150, "M", 40 },
                    { 301, 4, true, 151, "S", 45 },
                    { 302, 8, true, 151, "L", 49 },
                    { 303, 7, true, 152, "M", 50 },
                    { 304, 15, true, 152, "XL", 58 },
                    { 305, 10, true, 153, "L", 55 },
                    { 306, 22, true, 153, "XS", 67 },
                    { 307, 13, true, 154, "XL", 60 },
                    { 308, 29, true, 154, "S", 76 },
                    { 309, 16, true, 155, "XS", 65 },
                    { 310, 6, true, 155, "M", 85 },
                    { 311, 19, true, 156, "S", 70 },
                    { 312, 13, true, 156, "L", 94 },
                    { 313, 22, true, 157, "M", 75 },
                    { 314, 20, true, 157, "XL", 103 },
                    { 315, 25, true, 158, "L", 80 },
                    { 316, 27, true, 158, "XS", 112 },
                    { 317, 28, true, 159, "140", 85 },
                    { 318, 4, true, 159, "104", 121 },
                    { 319, 1, true, 160, "XS", 90 },
                    { 320, 11, true, 160, "M", 10 },
                    { 331, 19, true, 166, "S", 120 },
                    { 332, 23, true, 166, "L", 64 },
                    { 333, 22, true, 167, "M", 125 },
                    { 334, 30, true, 167, "XL", 73 },
                    { 335, 25, true, 168, "L", 10 },
                    { 336, 7, true, 168, "XS", 82 },
                    { 337, 28, true, 169, "XL", 15 },
                    { 338, 14, true, 169, "S", 91 },
                    { 339, 1, true, 170, "XS", 20 },
                    { 340, 21, true, 170, "M", 100 },
                    { 341, 4, true, 171, "S", 25 },
                    { 342, 28, true, 171, "L", 109 },
                    { 343, 7, true, 172, "M", 30 },
                    { 344, 5, true, 172, "XL", 118 },
                    { 345, 10, true, 173, "L", 35 },
                    { 346, 12, true, 173, "XS", 127 },
                    { 347, 13, true, 174, "XL", 40 },
                    { 348, 19, true, 174, "S", 16 },
                    { 349, 16, true, 175, "XS", 45 },
                    { 350, 26, true, 175, "M", 25 },
                    { 351, 19, true, 176, "S", 50 },
                    { 352, 3, true, 176, "L", 34 },
                    { 353, 22, true, 177, "M", 55 },
                    { 354, 10, true, 177, "XL", 43 },
                    { 355, 25, true, 178, "L", 60 },
                    { 356, 17, true, 178, "XS", 52 },
                    { 357, 28, true, 179, "116", 65 },
                    { 358, 24, true, 179, "128", 61 },
                    { 359, 1, true, 180, "XS", 70 },
                    { 360, 2, true, 180, "M", 70 },
                    { 371, 19, true, 186, "S", 100 },
                    { 372, 13, true, 186, "L", 124 },
                    { 373, 22, true, 187, "M", 105 },
                    { 374, 20, true, 187, "XL", 13 },
                    { 375, 25, true, 188, "L", 110 },
                    { 376, 27, true, 188, "XS", 22 },
                    { 377, 28, true, 189, "XL", 115 },
                    { 378, 4, true, 189, "S", 31 },
                    { 379, 1, true, 190, "XS", 120 },
                    { 380, 11, true, 190, "M", 40 },
                    { 381, 4, true, 191, "S", 125 },
                    { 382, 18, true, 191, "L", 49 },
                    { 383, 7, true, 192, "M", 10 },
                    { 384, 25, true, 192, "XL", 58 },
                    { 385, 10, true, 193, "L", 15 },
                    { 386, 2, true, 193, "XS", 67 },
                    { 387, 13, true, 194, "XL", 20 },
                    { 388, 9, true, 194, "S", 76 },
                    { 389, 16, true, 195, "XS", 25 },
                    { 390, 17, true, 195, "M", 85 },
                    { 391, 19, true, 196, "S", 30 },
                    { 392, 23, true, 196, "L", 94 },
                    { 393, 22, true, 197, "M", 35 },
                    { 394, 30, true, 197, "XL", 103 },
                    { 395, 25, true, 198, "L", 40 },
                    { 396, 7, true, 198, "XS", 112 },
                    { 397, 28, true, 199, "140", 45 },
                    { 398, 14, true, 199, "104", 121 },
                    { 399, 1, true, 200, "XS", 50 },
                    { 400, 21, true, 200, "M", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Warm and comfortable hoodies for casual wear and layering.");

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "Hex", "Name" },
                values: new object[] { "dark-blue", "#00008B", "Тъмно син" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Светло син");

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "Hex", "Name" },
                values: new object[] { "olive", "#808000", "Маслинен" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "Hex", "Name" },
                values: new object[] { "white-gray", "#D3D3D3", "Бяло/сиво" });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorId", "Size", "Stock" },
                values: new object[] { 1, "M", 120 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColorId", "ProductId", "Stock" },
                values: new object[] { 2, 2, 80 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColorId", "ProductId", "Stock" },
                values: new object[] { 3, 3, 60 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 4, 4, "S", 45 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 5, 5, "32", 70 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 6, 6, "34", 55 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ColorId", "ProductId", "Size" },
                values: new object[] { 7, 7, "L" });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 2, 8, "M", 25 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 8, 9, "42", 40 });

            migrationBuilder.UpdateData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ColorId", "ProductId", "Size", "Stock" },
                values: new object[] { 1, 10, "43", 35 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "Name", "Price" },
                values: new object[] { "UrbanBasics", "Soft 100% cotton t-shirt with a regular fit. Easy to pair with jeans or shorts.", "Classic Cotton T-Shirt", 24.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "StreetLab", 1, "Oversized fit t-shirt with a minimal front print and bold back graphic.", "Oversized Graphic Tee", 29.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "NorthWear", 2, "Warm fleece-lined hoodie with a kangaroo pocket and adjustable drawstrings.", "Premium Hoodie", 59.90m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "NorthWear", 2, "Everyday zip-up hoodie with soft interior, perfect for layering.", "Zip-Up Hoodie", 54.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "DenimCo", 3, "Slim fit jeans with a comfortable stretch. Clean look for casual or smart outfits.", "Slim Fit Jeans", 79.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "DenimCo", 3, "Classic straight fit denim with durable stitching and mid-rise waist.", "Straight Fit Jeans", 74.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "AeroStyle", 4, "Light bomber jacket with a smooth finish and ribbed cuffs. Great for spring/fall.", "Lightweight Bomber Jacket", 99.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "AeroStyle", 4, "Insulated puffer jacket designed for cold days. Water-resistant outer layer.", "Puffer Jacket", 149.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "MoveX", 5, "Comfortable lightweight sneakers with cushioned sole and breathable mesh upper.", "Running Sneakers", 89.90m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Brand", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { "MoveX", 5, "Minimal leather sneakers for everyday wear. Clean look and durable outsole.", "Casual Leather Sneakers", 119.00m });
        }
    }
}
