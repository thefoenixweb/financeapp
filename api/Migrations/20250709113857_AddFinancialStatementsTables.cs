using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddFinancialStatementsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36da5fc2-2866-45e4-9b06-aa1b3c7697f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df5387c-1df3-447b-ac0a-4961a8bb6da4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e06cf70-b90c-4b40-aa0e-3fa3863b373c", null, "User", "USER" },
                    { "e411f16a-7ff7-40bf-80ef-7ea9a1e7f818", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e06cf70-b90c-4b40-aa0e-3fa3863b373c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e411f16a-7ff7-40bf-80ef-7ea9a1e7f818");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36da5fc2-2866-45e4-9b06-aa1b3c7697f2", null, "User", "USER" },
                    { "4df5387c-1df3-447b-ac0a-4961a8bb6da4", null, "Admin", "ADMIN" }
                });
        }
    }
}
