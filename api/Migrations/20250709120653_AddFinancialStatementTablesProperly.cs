using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddFinancialStatementTablesProperly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1335edbd-cdaa-4a6f-8a50-2f3d77595319", null, "User", "USER" },
                    { "373efd51-c68b-470c-a630-06b4f8de44de", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1335edbd-cdaa-4a6f-8a50-2f3d77595319");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "373efd51-c68b-470c-a630-06b4f8de44de");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e06cf70-b90c-4b40-aa0e-3fa3863b373c", null, "User", "USER" },
                    { "e411f16a-7ff7-40bf-80ef-7ea9a1e7f818", null, "Admin", "ADMIN" }
                });
        }
    }
}
