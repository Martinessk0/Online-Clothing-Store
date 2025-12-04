using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "User", "USER" },
                    { "2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 0, null, null, "f81c19fd-26e6-4bf4-b0d5-9fe7b6ab964e", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@test.bg", true, "Martin", "Grahovski", false, null, "ADMIN@TEST.BG", "ADMIN@TEST.BG", "AQAAAAIAAYagAAAAELsHLYJ3ohlX9t3pZfMqITIGBk0HCxoM7DgBvgJ4riXCt+YmwIuSdrY+Llv3lhURHg==", null, false, "YIXYIXE6GJSSN4KVYJROXMJQKQ2EVPJT", false, "admin@test.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f" },
                    { "2", "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f");
        }
    }
}
