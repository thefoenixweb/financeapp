using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddFinancialStatements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0761bb4b-bd6c-4b66-9d29-33be0c1f0f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e89377-59ed-4436-a39e-2da750ffa8ae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36da5fc2-2866-45e4-9b06-aa1b3c7697f2", null, "User", "USER" },
                    { "4df5387c-1df3-447b-ac0a-4961a8bb6da4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "0761bb4b-bd6c-4b66-9d29-33be0c1f0f46", null, "Admin", "ADMIN" },
                    { "28e89377-59ed-4436-a39e-2da750ffa8ae", null, "User", "USER" }
                });
        }
    }
}
