using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "Hex", "Name" },
                values: new object[,]
                {
                    { 1, "white", "#FFFFFF", "Бял" },
                    { 2, "black", "#000000", "Черен" },
                    { 3, "gray", "#808080", "Сив" },
                    { 4, "navy", "#001F3F", "Тъмносин" },
                    { 5, "dark-blue", "#00008B", "Тъмно син" },
                    { 6, "light-blue", "#ADD8E6", "Светло син" },
                    { 7, "olive", "#808000", "Маслинен" },
                    { 8, "white-gray", "#D3D3D3", "Бяло/сиво" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "Id", "ColorId", "IsActive", "ProductId", "Size", "Stock" },
                values: new object[,]
                {
                    { 1, 1, true, 1, "M", 120 },
                    { 2, 2, true, 2, "L", 80 },
                    { 3, 3, true, 3, "M", 60 },
                    { 4, 4, true, 4, "S", 45 },
                    { 5, 5, true, 5, "32", 70 },
                    { 6, 6, true, 6, "34", 55 },
                    { 7, 7, true, 7, "L", 30 },
                    { 8, 2, true, 8, "M", 25 },
                    { 9, 8, true, 9, "42", 40 },
                    { 10, 1, true, 10, "43", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
