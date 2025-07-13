using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyProfileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "026185d2-2bd0-4f13-842c-408907f60967");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad8eafd-da29-458f-829b-1eb0c3947dbb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0761bb4b-bd6c-4b66-9d29-33be0c1f0f46", null, "Admin", "ADMIN" },
                    { "28e89377-59ed-4436-a39e-2da750ffa8ae", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "026185d2-2bd0-4f13-842c-408907f60967", null, "Admin", "ADMIN" },
                    { "fad8eafd-da29-458f-829b-1eb0c3947dbb", null, "User", "USER" }
                });
        }
    }
}
