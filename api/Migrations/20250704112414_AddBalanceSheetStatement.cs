using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddBalanceSheetStatement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57813dfc-e428-4ad1-bcc6-a03be241a75c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c39f9abb-879f-4e63-bb8a-93f096350805");

            migrationBuilder.CreateTable(
                name: "BalanceSheetStatements",
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
                    CashAndCashEquivalents = table.Column<long>(type: "bigint", nullable: false),
                    ShortTermInvestments = table.Column<long>(type: "bigint", nullable: false),
                    CashAndShortTermInvestments = table.Column<long>(type: "bigint", nullable: false),
                    NetReceivables = table.Column<long>(type: "bigint", nullable: false),
                    Inventory = table.Column<long>(type: "bigint", nullable: false),
                    OtherCurrentAssets = table.Column<long>(type: "bigint", nullable: false),
                    TotalCurrentAssets = table.Column<long>(type: "bigint", nullable: false),
                    PropertyPlantEquipmentNet = table.Column<long>(type: "bigint", nullable: false),
                    Goodwill = table.Column<long>(type: "bigint", nullable: false),
                    IntangibleAssets = table.Column<long>(type: "bigint", nullable: false),
                    GoodwillAndIntangibleAssets = table.Column<long>(type: "bigint", nullable: false),
                    LongTermInvestments = table.Column<long>(type: "bigint", nullable: false),
                    TaxAssets = table.Column<long>(type: "bigint", nullable: false),
                    OtherNonCurrentAssets = table.Column<long>(type: "bigint", nullable: false),
                    TotalNonCurrentAssets = table.Column<long>(type: "bigint", nullable: false),
                    OtherAssets = table.Column<long>(type: "bigint", nullable: false),
                    TotalAssets = table.Column<long>(type: "bigint", nullable: false),
                    AccountPayables = table.Column<long>(type: "bigint", nullable: false),
                    ShortTermDebt = table.Column<long>(type: "bigint", nullable: false),
                    TaxPayables = table.Column<long>(type: "bigint", nullable: false),
                    DeferredRevenue = table.Column<long>(type: "bigint", nullable: false),
                    OtherCurrentLiabilities = table.Column<long>(type: "bigint", nullable: false),
                    TotalCurrentLiabilities = table.Column<long>(type: "bigint", nullable: false),
                    LongTermDebt = table.Column<long>(type: "bigint", nullable: false),
                    DeferredRevenueNonCurrent = table.Column<long>(type: "bigint", nullable: false),
                    DeferredTaxLiabilitiesNonCurrent = table.Column<long>(type: "bigint", nullable: false),
                    OtherNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: false),
                    TotalNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: false),
                    OtherLiabilities = table.Column<long>(type: "bigint", nullable: false),
                    CapitalLeaseObligations = table.Column<long>(type: "bigint", nullable: false),
                    TotalLiabilities = table.Column<long>(type: "bigint", nullable: false),
                    PreferredStock = table.Column<long>(type: "bigint", nullable: false),
                    CommonStock = table.Column<long>(type: "bigint", nullable: false),
                    RetainedEarnings = table.Column<long>(type: "bigint", nullable: false),
                    AccumulatedOtherComprehensiveIncomeLoss = table.Column<long>(type: "bigint", nullable: false),
                    OthertotalStockholdersEquity = table.Column<long>(type: "bigint", nullable: false),
                    TotalStockholdersEquity = table.Column<long>(type: "bigint", nullable: false),
                    TotalEquity = table.Column<long>(type: "bigint", nullable: false),
                    TotalLiabilitiesAndStockholdersEquity = table.Column<long>(type: "bigint", nullable: false),
                    MinorityInterest = table.Column<long>(type: "bigint", nullable: false),
                    TotalLiabilitiesAndTotalEquity = table.Column<long>(type: "bigint", nullable: false),
                    TotalInvestments = table.Column<long>(type: "bigint", nullable: false),
                    TotalDebt = table.Column<long>(type: "bigint", nullable: false),
                    NetDebt = table.Column<long>(type: "bigint", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheetStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceSheetStatements_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d1cdfcc-736c-4870-b263-ba5b8c0affa7", null, "Admin", "ADMIN" },
                    { "3423a67f-de3c-4f53-8ba1-7ee745459ca6", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetStatements_StockId",
                table: "BalanceSheetStatements",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceSheetStatements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1cdfcc-736c-4870-b263-ba5b8c0affa7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3423a67f-de3c-4f53-8ba1-7ee745459ca6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57813dfc-e428-4ad1-bcc6-a03be241a75c", null, "User", "USER" },
                    { "c39f9abb-879f-4e63-bb8a-93f096350805", null, "Admin", "ADMIN" }
                });
        }
    }
}
