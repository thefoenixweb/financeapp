using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCalendarYearToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf735b9a-0eee-4d0d-a280-dff5118d421e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c71fa553-639a-4e3b-8365-3306f49a8d4e");

            migrationBuilder.RenameColumn(
                name: "CalendarYear",
                table: "IncomeStatements",
                newName: "calendarYear");

            migrationBuilder.RenameColumn(
                name: "CalendarYear",
                table: "CashFlowStatements",
                newName: "calendarYear");

            migrationBuilder.RenameColumn(
                name: "CalendarYear",
                table: "BalanceSheetStatements",
                newName: "calendarYear");

            migrationBuilder.AlterColumn<int>(
                name: "calendarYear",
                table: "IncomeStatements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "calendarYear",
                table: "CashFlowStatements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "calendarYear",
                table: "BalanceSheetStatements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f028f9d-bd09-4eee-9d25-da3d4f9dd9f7", null, "User", "USER" },
                    { "87b86b93-6a88-4566-b8c8-b113c6cc9d2c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f028f9d-bd09-4eee-9d25-da3d4f9dd9f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87b86b93-6a88-4566-b8c8-b113c6cc9d2c");

            migrationBuilder.RenameColumn(
                name: "calendarYear",
                table: "IncomeStatements",
                newName: "CalendarYear");

            migrationBuilder.RenameColumn(
                name: "calendarYear",
                table: "CashFlowStatements",
                newName: "CalendarYear");

            migrationBuilder.RenameColumn(
                name: "calendarYear",
                table: "BalanceSheetStatements",
                newName: "CalendarYear");

            migrationBuilder.AlterColumn<string>(
                name: "CalendarYear",
                table: "IncomeStatements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CalendarYear",
                table: "CashFlowStatements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CalendarYear",
                table: "BalanceSheetStatements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf735b9a-0eee-4d0d-a280-dff5118d421e", null, "User", "USER" },
                    { "c71fa553-639a-4e3b-8365-3306f49a8d4e", null, "Admin", "ADMIN" }
                });
        }
    }
}
