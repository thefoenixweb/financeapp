using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVolAvgToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f028f9d-bd09-4eee-9d25-da3d4f9dd9f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b86b93-6a88-4566-b8c8-b113c6cc9d2c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "525f2537-7110-4df2-ac86-6262b97a9752", null, "User", "USER" },
                    { "5cb7be52-9e86-4b45-9ae5-c193aac6d901", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "525f2537-7110-4df2-ac86-6262b97a9752");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb7be52-9e86-4b45-9ae5-c193aac6d901");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f028f9d-bd09-4eee-9d25-da3d4f9dd9f7", null, "User", "USER" },
                    { "87b86b93-6a88-4566-b8c8-b113c6cc9d2c", null, "Admin", "ADMIN" }
                });
        }
    }
}
