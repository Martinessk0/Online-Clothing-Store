using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingSeedingImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-001", "https://loremflickr.com/800/1000/tshirt?lock=1" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-002", "https://loremflickr.com/800/1000/hoodie?lock=2" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-003", "https://loremflickr.com/800/1000/jeans?lock=3" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-004", "https://loremflickr.com/800/1000/jacket?lock=4" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-005", "https://loremflickr.com/800/1000/sneakers?lock=5" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-006", "https://loremflickr.com/800/1000/sweatpants?lock=6" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-007", "https://loremflickr.com/800/1000/shorts?lock=7" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-008", "https://loremflickr.com/800/1000/shirt?lock=8" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-009", "https://loremflickr.com/800/1000/knitwear?lock=9" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-010", "https://loremflickr.com/800/1000/coat?lock=10" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-011", "https://loremflickr.com/800/1000/activewear?lock=11" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-012", "https://loremflickr.com/800/1000/underwear?lock=12" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-013", "https://loremflickr.com/800/1000/socks?lock=13" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-014", "https://loremflickr.com/800/1000/accessories?lock=14" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-015", "https://loremflickr.com/800/1000/bag?lock=15" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-016", "https://loremflickr.com/800/1000/hat?lock=16" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-017", "https://loremflickr.com/800/1000/dress?lock=17" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-018", "https://loremflickr.com/800/1000/skirt?lock=18" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-019", "https://loremflickr.com/800/1000/kids-clothing?lock=19" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 20,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=20");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-021", "https://loremflickr.com/800/1000/tshirt?lock=21" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-022", "https://loremflickr.com/800/1000/hoodie?lock=22" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-023", "https://loremflickr.com/800/1000/jeans?lock=23" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-024", "https://loremflickr.com/800/1000/jacket?lock=24" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-025", "https://loremflickr.com/800/1000/sneakers?lock=25" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-026", "https://loremflickr.com/800/1000/sweatpants?lock=26" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-027", "https://loremflickr.com/800/1000/shorts?lock=27" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-028", "https://loremflickr.com/800/1000/shirt?lock=28" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-029", "https://loremflickr.com/800/1000/knitwear?lock=29" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-030", "https://loremflickr.com/800/1000/coat?lock=30" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-031", "https://loremflickr.com/800/1000/activewear?lock=31" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-032", "https://loremflickr.com/800/1000/underwear?lock=32" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-033", "https://loremflickr.com/800/1000/socks?lock=33" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-034", "https://loremflickr.com/800/1000/accessories?lock=34" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-035", "https://loremflickr.com/800/1000/bag?lock=35" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-036", "https://loremflickr.com/800/1000/hat?lock=36" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-037", "https://loremflickr.com/800/1000/dress?lock=37" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-038", "https://loremflickr.com/800/1000/skirt?lock=38" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-039", "https://loremflickr.com/800/1000/kids-clothing?lock=39" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 40,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=40");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-041", "https://loremflickr.com/800/1000/tshirt?lock=41" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-042", "https://loremflickr.com/800/1000/hoodie?lock=42" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-043", "https://loremflickr.com/800/1000/jeans?lock=43" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-044", "https://loremflickr.com/800/1000/jacket?lock=44" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-045", "https://loremflickr.com/800/1000/sneakers?lock=45" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-046", "https://loremflickr.com/800/1000/sweatpants?lock=46" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-047", "https://loremflickr.com/800/1000/shorts?lock=47" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-048", "https://loremflickr.com/800/1000/shirt?lock=48" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-049", "https://loremflickr.com/800/1000/knitwear?lock=49" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-050", "https://loremflickr.com/800/1000/coat?lock=50" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-051", "https://loremflickr.com/800/1000/activewear?lock=51" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-052", "https://loremflickr.com/800/1000/underwear?lock=52" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-053", "https://loremflickr.com/800/1000/socks?lock=53" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-054", "https://loremflickr.com/800/1000/accessories?lock=54" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-055", "https://loremflickr.com/800/1000/bag?lock=55" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-056", "https://loremflickr.com/800/1000/hat?lock=56" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-057", "https://loremflickr.com/800/1000/dress?lock=57" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-058", "https://loremflickr.com/800/1000/skirt?lock=58" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-059", "https://loremflickr.com/800/1000/kids-clothing?lock=59" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 60,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=60");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-061", "https://loremflickr.com/800/1000/tshirt?lock=61" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-062", "https://loremflickr.com/800/1000/hoodie?lock=62" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-063", "https://loremflickr.com/800/1000/jeans?lock=63" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-064", "https://loremflickr.com/800/1000/jacket?lock=64" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-065", "https://loremflickr.com/800/1000/sneakers?lock=65" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-066", "https://loremflickr.com/800/1000/sweatpants?lock=66" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-067", "https://loremflickr.com/800/1000/shorts?lock=67" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-068", "https://loremflickr.com/800/1000/shirt?lock=68" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-069", "https://loremflickr.com/800/1000/knitwear?lock=69" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-070", "https://loremflickr.com/800/1000/coat?lock=70" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-071", "https://loremflickr.com/800/1000/activewear?lock=71" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-072", "https://loremflickr.com/800/1000/underwear?lock=72" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-073", "https://loremflickr.com/800/1000/socks?lock=73" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-074", "https://loremflickr.com/800/1000/accessories?lock=74" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-075", "https://loremflickr.com/800/1000/bag?lock=75" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-076", "https://loremflickr.com/800/1000/hat?lock=76" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-077", "https://loremflickr.com/800/1000/dress?lock=77" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-078", "https://loremflickr.com/800/1000/skirt?lock=78" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-079", "https://loremflickr.com/800/1000/kids-clothing?lock=79" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 80,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=80");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-081", "https://loremflickr.com/800/1000/tshirt?lock=81" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-082", "https://loremflickr.com/800/1000/hoodie?lock=82" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-083", "https://loremflickr.com/800/1000/jeans?lock=83" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-084", "https://loremflickr.com/800/1000/jacket?lock=84" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-085", "https://loremflickr.com/800/1000/sneakers?lock=85" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-086", "https://loremflickr.com/800/1000/sweatpants?lock=86" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-087", "https://loremflickr.com/800/1000/shorts?lock=87" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-088", "https://loremflickr.com/800/1000/shirt?lock=88" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-089", "https://loremflickr.com/800/1000/knitwear?lock=89" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-090", "https://loremflickr.com/800/1000/coat?lock=90" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-091", "https://loremflickr.com/800/1000/activewear?lock=91" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-092", "https://loremflickr.com/800/1000/underwear?lock=92" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-093", "https://loremflickr.com/800/1000/socks?lock=93" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-094", "https://loremflickr.com/800/1000/accessories?lock=94" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-095", "https://loremflickr.com/800/1000/bag?lock=95" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-096", "https://loremflickr.com/800/1000/hat?lock=96" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-097", "https://loremflickr.com/800/1000/dress?lock=97" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-098", "https://loremflickr.com/800/1000/skirt?lock=98" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-099", "https://loremflickr.com/800/1000/kids-clothing?lock=99" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 100,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=100");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-101", "https://loremflickr.com/800/1000/tshirt?lock=101" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-102", "https://loremflickr.com/800/1000/hoodie?lock=102" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-103", "https://loremflickr.com/800/1000/jeans?lock=103" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-104", "https://loremflickr.com/800/1000/jacket?lock=104" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-105", "https://loremflickr.com/800/1000/sneakers?lock=105" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-106", "https://loremflickr.com/800/1000/sweatpants?lock=106" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-107", "https://loremflickr.com/800/1000/shorts?lock=107" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-108", "https://loremflickr.com/800/1000/shirt?lock=108" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-109", "https://loremflickr.com/800/1000/knitwear?lock=109" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-110", "https://loremflickr.com/800/1000/coat?lock=110" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-111", "https://loremflickr.com/800/1000/activewear?lock=111" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-112", "https://loremflickr.com/800/1000/underwear?lock=112" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-113", "https://loremflickr.com/800/1000/socks?lock=113" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-114", "https://loremflickr.com/800/1000/accessories?lock=114" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-115", "https://loremflickr.com/800/1000/bag?lock=115" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-116", "https://loremflickr.com/800/1000/hat?lock=116" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-117", "https://loremflickr.com/800/1000/dress?lock=117" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-118", "https://loremflickr.com/800/1000/skirt?lock=118" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-119", "https://loremflickr.com/800/1000/kids-clothing?lock=119" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 120,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=120");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-121", "https://loremflickr.com/800/1000/tshirt?lock=121" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-122", "https://loremflickr.com/800/1000/hoodie?lock=122" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-123", "https://loremflickr.com/800/1000/jeans?lock=123" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-124", "https://loremflickr.com/800/1000/jacket?lock=124" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-125", "https://loremflickr.com/800/1000/sneakers?lock=125" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-126", "https://loremflickr.com/800/1000/sweatpants?lock=126" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-127", "https://loremflickr.com/800/1000/shorts?lock=127" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-128", "https://loremflickr.com/800/1000/shirt?lock=128" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-129", "https://loremflickr.com/800/1000/knitwear?lock=129" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-130", "https://loremflickr.com/800/1000/coat?lock=130" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-131", "https://loremflickr.com/800/1000/activewear?lock=131" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-132", "https://loremflickr.com/800/1000/underwear?lock=132" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-133", "https://loremflickr.com/800/1000/socks?lock=133" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-134", "https://loremflickr.com/800/1000/accessories?lock=134" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-135", "https://loremflickr.com/800/1000/bag?lock=135" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-136", "https://loremflickr.com/800/1000/hat?lock=136" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-137", "https://loremflickr.com/800/1000/dress?lock=137" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-138", "https://loremflickr.com/800/1000/skirt?lock=138" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-139", "https://loremflickr.com/800/1000/kids-clothing?lock=139" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 140,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=140");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-141", "https://loremflickr.com/800/1000/tshirt?lock=141" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-142", "https://loremflickr.com/800/1000/hoodie?lock=142" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-143", "https://loremflickr.com/800/1000/jeans?lock=143" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-144", "https://loremflickr.com/800/1000/jacket?lock=144" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-145", "https://loremflickr.com/800/1000/sneakers?lock=145" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-146", "https://loremflickr.com/800/1000/sweatpants?lock=146" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-147", "https://loremflickr.com/800/1000/shorts?lock=147" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-148", "https://loremflickr.com/800/1000/shirt?lock=148" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-149", "https://loremflickr.com/800/1000/knitwear?lock=149" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-150", "https://loremflickr.com/800/1000/coat?lock=150" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-151", "https://loremflickr.com/800/1000/activewear?lock=151" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-152", "https://loremflickr.com/800/1000/underwear?lock=152" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-153", "https://loremflickr.com/800/1000/socks?lock=153" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-154", "https://loremflickr.com/800/1000/accessories?lock=154" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-155", "https://loremflickr.com/800/1000/bag?lock=155" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-156", "https://loremflickr.com/800/1000/hat?lock=156" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-157", "https://loremflickr.com/800/1000/dress?lock=157" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-158", "https://loremflickr.com/800/1000/skirt?lock=158" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-159", "https://loremflickr.com/800/1000/kids-clothing?lock=159" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 160,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=160");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-161", "https://loremflickr.com/800/1000/tshirt?lock=161" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-162", "https://loremflickr.com/800/1000/hoodie?lock=162" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-163", "https://loremflickr.com/800/1000/jeans?lock=163" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-164", "https://loremflickr.com/800/1000/jacket?lock=164" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-165", "https://loremflickr.com/800/1000/sneakers?lock=165" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-166", "https://loremflickr.com/800/1000/sweatpants?lock=166" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-167", "https://loremflickr.com/800/1000/shorts?lock=167" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-168", "https://loremflickr.com/800/1000/shirt?lock=168" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-169", "https://loremflickr.com/800/1000/knitwear?lock=169" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-170", "https://loremflickr.com/800/1000/coat?lock=170" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-171", "https://loremflickr.com/800/1000/activewear?lock=171" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-172", "https://loremflickr.com/800/1000/underwear?lock=172" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-173", "https://loremflickr.com/800/1000/socks?lock=173" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-174", "https://loremflickr.com/800/1000/accessories?lock=174" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-175", "https://loremflickr.com/800/1000/bag?lock=175" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-176", "https://loremflickr.com/800/1000/hat?lock=176" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-177", "https://loremflickr.com/800/1000/dress?lock=177" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-178", "https://loremflickr.com/800/1000/skirt?lock=178" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-179", "https://loremflickr.com/800/1000/kids-clothing?lock=179" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 180,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=180");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/tshirt-181", "https://loremflickr.com/800/1000/tshirt?lock=181" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hoodie-182", "https://loremflickr.com/800/1000/hoodie?lock=182" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jeans-183", "https://loremflickr.com/800/1000/jeans?lock=183" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/jacket-184", "https://loremflickr.com/800/1000/jacket?lock=184" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sneakers-185", "https://loremflickr.com/800/1000/sneakers?lock=185" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/sweatpants-186", "https://loremflickr.com/800/1000/sweatpants?lock=186" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shorts-187", "https://loremflickr.com/800/1000/shorts?lock=187" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/shirt-188", "https://loremflickr.com/800/1000/shirt?lock=188" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/knitwear-189", "https://loremflickr.com/800/1000/knitwear?lock=189" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/coat-190", "https://loremflickr.com/800/1000/coat?lock=190" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/activewear-191", "https://loremflickr.com/800/1000/activewear?lock=191" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/underwear-192", "https://loremflickr.com/800/1000/underwear?lock=192" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/socks-193", "https://loremflickr.com/800/1000/socks?lock=193" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/accessories-194", "https://loremflickr.com/800/1000/accessories?lock=194" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/bag-195", "https://loremflickr.com/800/1000/bag?lock=195" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/hat-196", "https://loremflickr.com/800/1000/hat?lock=196" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/dress-197", "https://loremflickr.com/800/1000/dress?lock=197" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/skirt-198", "https://loremflickr.com/800/1000/skirt?lock=198" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/kids-clothing-199", "https://loremflickr.com/800/1000/kids-clothing?lock=199" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 200,
                column: "Url",
                value: "https://loremflickr.com/800/1000/clothing?lock=200");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-001", "https://picsum.photos/seed/clothing-001/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-002", "https://picsum.photos/seed/clothing-002/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-003", "https://picsum.photos/seed/clothing-003/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-004", "https://picsum.photos/seed/clothing-004/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-005", "https://picsum.photos/seed/clothing-005/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-006", "https://picsum.photos/seed/clothing-006/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-007", "https://picsum.photos/seed/clothing-007/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-008", "https://picsum.photos/seed/clothing-008/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-009", "https://picsum.photos/seed/clothing-009/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-010", "https://picsum.photos/seed/clothing-010/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-011", "https://picsum.photos/seed/clothing-011/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-012", "https://picsum.photos/seed/clothing-012/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-013", "https://picsum.photos/seed/clothing-013/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-014", "https://picsum.photos/seed/clothing-014/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-015", "https://picsum.photos/seed/clothing-015/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-016", "https://picsum.photos/seed/clothing-016/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-017", "https://picsum.photos/seed/clothing-017/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-018", "https://picsum.photos/seed/clothing-018/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-019", "https://picsum.photos/seed/clothing-019/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 20,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-020/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-021", "https://picsum.photos/seed/clothing-021/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-022", "https://picsum.photos/seed/clothing-022/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-023", "https://picsum.photos/seed/clothing-023/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-024", "https://picsum.photos/seed/clothing-024/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-025", "https://picsum.photos/seed/clothing-025/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-026", "https://picsum.photos/seed/clothing-026/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-027", "https://picsum.photos/seed/clothing-027/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-028", "https://picsum.photos/seed/clothing-028/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-029", "https://picsum.photos/seed/clothing-029/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-030", "https://picsum.photos/seed/clothing-030/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-031", "https://picsum.photos/seed/clothing-031/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-032", "https://picsum.photos/seed/clothing-032/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-033", "https://picsum.photos/seed/clothing-033/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-034", "https://picsum.photos/seed/clothing-034/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-035", "https://picsum.photos/seed/clothing-035/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-036", "https://picsum.photos/seed/clothing-036/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-037", "https://picsum.photos/seed/clothing-037/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-038", "https://picsum.photos/seed/clothing-038/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-039", "https://picsum.photos/seed/clothing-039/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 40,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-040/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-041", "https://picsum.photos/seed/clothing-041/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-042", "https://picsum.photos/seed/clothing-042/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-043", "https://picsum.photos/seed/clothing-043/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-044", "https://picsum.photos/seed/clothing-044/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-045", "https://picsum.photos/seed/clothing-045/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-046", "https://picsum.photos/seed/clothing-046/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-047", "https://picsum.photos/seed/clothing-047/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-048", "https://picsum.photos/seed/clothing-048/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-049", "https://picsum.photos/seed/clothing-049/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-050", "https://picsum.photos/seed/clothing-050/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-051", "https://picsum.photos/seed/clothing-051/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-052", "https://picsum.photos/seed/clothing-052/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-053", "https://picsum.photos/seed/clothing-053/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-054", "https://picsum.photos/seed/clothing-054/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-055", "https://picsum.photos/seed/clothing-055/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-056", "https://picsum.photos/seed/clothing-056/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-057", "https://picsum.photos/seed/clothing-057/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-058", "https://picsum.photos/seed/clothing-058/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-059", "https://picsum.photos/seed/clothing-059/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 60,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-060/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-061", "https://picsum.photos/seed/clothing-061/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-062", "https://picsum.photos/seed/clothing-062/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-063", "https://picsum.photos/seed/clothing-063/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-064", "https://picsum.photos/seed/clothing-064/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-065", "https://picsum.photos/seed/clothing-065/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-066", "https://picsum.photos/seed/clothing-066/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-067", "https://picsum.photos/seed/clothing-067/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-068", "https://picsum.photos/seed/clothing-068/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-069", "https://picsum.photos/seed/clothing-069/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-070", "https://picsum.photos/seed/clothing-070/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-071", "https://picsum.photos/seed/clothing-071/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-072", "https://picsum.photos/seed/clothing-072/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-073", "https://picsum.photos/seed/clothing-073/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-074", "https://picsum.photos/seed/clothing-074/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-075", "https://picsum.photos/seed/clothing-075/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-076", "https://picsum.photos/seed/clothing-076/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-077", "https://picsum.photos/seed/clothing-077/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-078", "https://picsum.photos/seed/clothing-078/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-079", "https://picsum.photos/seed/clothing-079/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 80,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-080/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-081", "https://picsum.photos/seed/clothing-081/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-082", "https://picsum.photos/seed/clothing-082/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-083", "https://picsum.photos/seed/clothing-083/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-084", "https://picsum.photos/seed/clothing-084/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-085", "https://picsum.photos/seed/clothing-085/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-086", "https://picsum.photos/seed/clothing-086/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-087", "https://picsum.photos/seed/clothing-087/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-088", "https://picsum.photos/seed/clothing-088/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-089", "https://picsum.photos/seed/clothing-089/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-090", "https://picsum.photos/seed/clothing-090/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-091", "https://picsum.photos/seed/clothing-091/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-092", "https://picsum.photos/seed/clothing-092/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-093", "https://picsum.photos/seed/clothing-093/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-094", "https://picsum.photos/seed/clothing-094/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-095", "https://picsum.photos/seed/clothing-095/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-096", "https://picsum.photos/seed/clothing-096/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-097", "https://picsum.photos/seed/clothing-097/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-098", "https://picsum.photos/seed/clothing-098/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-099", "https://picsum.photos/seed/clothing-099/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 100,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-100/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-101", "https://picsum.photos/seed/clothing-101/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-102", "https://picsum.photos/seed/clothing-102/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-103", "https://picsum.photos/seed/clothing-103/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-104", "https://picsum.photos/seed/clothing-104/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-105", "https://picsum.photos/seed/clothing-105/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-106", "https://picsum.photos/seed/clothing-106/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-107", "https://picsum.photos/seed/clothing-107/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-108", "https://picsum.photos/seed/clothing-108/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-109", "https://picsum.photos/seed/clothing-109/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-110", "https://picsum.photos/seed/clothing-110/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-111", "https://picsum.photos/seed/clothing-111/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-112", "https://picsum.photos/seed/clothing-112/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-113", "https://picsum.photos/seed/clothing-113/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-114", "https://picsum.photos/seed/clothing-114/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-115", "https://picsum.photos/seed/clothing-115/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-116", "https://picsum.photos/seed/clothing-116/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-117", "https://picsum.photos/seed/clothing-117/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-118", "https://picsum.photos/seed/clothing-118/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-119", "https://picsum.photos/seed/clothing-119/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 120,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-120/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-121", "https://picsum.photos/seed/clothing-121/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-122", "https://picsum.photos/seed/clothing-122/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-123", "https://picsum.photos/seed/clothing-123/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-124", "https://picsum.photos/seed/clothing-124/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-125", "https://picsum.photos/seed/clothing-125/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-126", "https://picsum.photos/seed/clothing-126/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-127", "https://picsum.photos/seed/clothing-127/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-128", "https://picsum.photos/seed/clothing-128/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-129", "https://picsum.photos/seed/clothing-129/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-130", "https://picsum.photos/seed/clothing-130/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-131", "https://picsum.photos/seed/clothing-131/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-132", "https://picsum.photos/seed/clothing-132/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-133", "https://picsum.photos/seed/clothing-133/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-134", "https://picsum.photos/seed/clothing-134/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-135", "https://picsum.photos/seed/clothing-135/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-136", "https://picsum.photos/seed/clothing-136/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-137", "https://picsum.photos/seed/clothing-137/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-138", "https://picsum.photos/seed/clothing-138/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-139", "https://picsum.photos/seed/clothing-139/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 140,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-140/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-141", "https://picsum.photos/seed/clothing-141/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-142", "https://picsum.photos/seed/clothing-142/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-143", "https://picsum.photos/seed/clothing-143/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-144", "https://picsum.photos/seed/clothing-144/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-145", "https://picsum.photos/seed/clothing-145/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-146", "https://picsum.photos/seed/clothing-146/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-147", "https://picsum.photos/seed/clothing-147/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-148", "https://picsum.photos/seed/clothing-148/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-149", "https://picsum.photos/seed/clothing-149/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-150", "https://picsum.photos/seed/clothing-150/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-151", "https://picsum.photos/seed/clothing-151/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-152", "https://picsum.photos/seed/clothing-152/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-153", "https://picsum.photos/seed/clothing-153/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-154", "https://picsum.photos/seed/clothing-154/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-155", "https://picsum.photos/seed/clothing-155/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-156", "https://picsum.photos/seed/clothing-156/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-157", "https://picsum.photos/seed/clothing-157/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-158", "https://picsum.photos/seed/clothing-158/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-159", "https://picsum.photos/seed/clothing-159/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 160,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-160/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-161", "https://picsum.photos/seed/clothing-161/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-162", "https://picsum.photos/seed/clothing-162/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-163", "https://picsum.photos/seed/clothing-163/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-164", "https://picsum.photos/seed/clothing-164/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-165", "https://picsum.photos/seed/clothing-165/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-166", "https://picsum.photos/seed/clothing-166/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-167", "https://picsum.photos/seed/clothing-167/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-168", "https://picsum.photos/seed/clothing-168/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-169", "https://picsum.photos/seed/clothing-169/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-170", "https://picsum.photos/seed/clothing-170/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-171", "https://picsum.photos/seed/clothing-171/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-172", "https://picsum.photos/seed/clothing-172/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-173", "https://picsum.photos/seed/clothing-173/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-174", "https://picsum.photos/seed/clothing-174/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-175", "https://picsum.photos/seed/clothing-175/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-176", "https://picsum.photos/seed/clothing-176/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-177", "https://picsum.photos/seed/clothing-177/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-178", "https://picsum.photos/seed/clothing-178/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-179", "https://picsum.photos/seed/clothing-179/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 180,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-180/800/1000");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-181", "https://picsum.photos/seed/clothing-181/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-182", "https://picsum.photos/seed/clothing-182/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-183", "https://picsum.photos/seed/clothing-183/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-184", "https://picsum.photos/seed/clothing-184/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-185", "https://picsum.photos/seed/clothing-185/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-186", "https://picsum.photos/seed/clothing-186/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-187", "https://picsum.photos/seed/clothing-187/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-188", "https://picsum.photos/seed/clothing-188/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-189", "https://picsum.photos/seed/clothing-189/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-190", "https://picsum.photos/seed/clothing-190/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-191", "https://picsum.photos/seed/clothing-191/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-192", "https://picsum.photos/seed/clothing-192/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-193", "https://picsum.photos/seed/clothing-193/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-194", "https://picsum.photos/seed/clothing-194/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-195", "https://picsum.photos/seed/clothing-195/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-196", "https://picsum.photos/seed/clothing-196/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-197", "https://picsum.photos/seed/clothing-197/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-198", "https://picsum.photos/seed/clothing-198/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "PublicId", "Url" },
                values: new object[] { "seed/clothing-199", "https://picsum.photos/seed/clothing-199/800/1000" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 200,
                column: "Url",
                value: "https://picsum.photos/seed/clothing-200/800/1000");
        }
    }
}
