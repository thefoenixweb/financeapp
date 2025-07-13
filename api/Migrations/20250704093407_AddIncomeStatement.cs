using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddIncomeStatement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c0971e5-ec94-4663-af66-ae88cceacca6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6c47495-30b0-4a33-b2ad-b65a1eee120e");

            migrationBuilder.CreateTable(
                name: "IncomeStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalendarYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revenue = table.Column<long>(type: "bigint", nullable: false),
                    CostOfRevenue = table.Column<long>(type: "bigint", nullable: false),
                    GrossProfit = table.Column<long>(type: "bigint", nullable: false),
                    GrossProfitRatio = table.Column<double>(type: "float", nullable: false),
                    ResearchAndDevelopmentExpenses = table.Column<long>(type: "bigint", nullable: false),
                    GeneralAndAdministrativeExpenses = table.Column<long>(type: "bigint", nullable: false),
                    SellingAndMarketingExpenses = table.Column<long>(type: "bigint", nullable: false),
                    SellingGeneralAndAdministrativeExpenses = table.Column<long>(type: "bigint", nullable: false),
                    OtherExpenses = table.Column<long>(type: "bigint", nullable: false),
                    OperatingExpenses = table.Column<long>(type: "bigint", nullable: false),
                    CostAndExpenses = table.Column<long>(type: "bigint", nullable: false),
                    InterestIncome = table.Column<long>(type: "bigint", nullable: false),
                    InterestExpense = table.Column<long>(type: "bigint", nullable: false),
                    DepreciationAndAmortization = table.Column<long>(type: "bigint", nullable: false),
                    Ebitda = table.Column<long>(type: "bigint", nullable: false),
                    EbitdaRatio = table.Column<double>(type: "float", nullable: false),
                    OperatingIncome = table.Column<long>(type: "bigint", nullable: false),
                    OperatingIncomeRatio = table.Column<double>(type: "float", nullable: false),
                    TotalOtherIncomeExpensesNet = table.Column<long>(type: "bigint", nullable: false),
                    IncomeBeforeTax = table.Column<long>(type: "bigint", nullable: false),
                    IncomeBeforeTaxRatio = table.Column<double>(type: "float", nullable: false),
                    IncomeTaxExpense = table.Column<long>(type: "bigint", nullable: false),
                    NetIncome = table.Column<long>(type: "bigint", nullable: false),
                    NetIncomeRatio = table.Column<double>(type: "float", nullable: false),
                    Eps = table.Column<double>(type: "float", nullable: false),
                    Epsdiluted = table.Column<double>(type: "float", nullable: false),
                    WeightedAverageShsOut = table.Column<long>(type: "bigint", nullable: false),
                    WeightedAverageShsOutDil = table.Column<long>(type: "bigint", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeStatements_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57813dfc-e428-4ad1-bcc6-a03be241a75c", null, "User", "USER" },
                    { "c39f9abb-879f-4e63-bb8a-93f096350805", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatements_StockId",
                table: "IncomeStatements",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeStatements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57813dfc-e428-4ad1-bcc6-a03be241a75c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c39f9abb-879f-4e63-bb8a-93f096350805");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c0971e5-ec94-4663-af66-ae88cceacca6", null, "User", "USER" },
                    { "f6c47495-30b0-4a33-b2ad-b65a1eee120e", null, "Admin", "ADMIN" }
                });
        }
    }
}
