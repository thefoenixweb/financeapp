using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddCashFlowStatement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5849bcbd-fa3c-46ad-8ac1-00ff8cd9a6d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79f392bf-21e3-4e59-a899-f2a066f3884a");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CashFlowStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalendarYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetIncome = table.Column<long>(type: "bigint", nullable: false),
                    DepreciationAndAmortization = table.Column<long>(type: "bigint", nullable: false),
                    DeferredIncomeTax = table.Column<long>(type: "bigint", nullable: false),
                    StockBasedCompensation = table.Column<long>(type: "bigint", nullable: false),
                    ChangeInWorkingCapital = table.Column<long>(type: "bigint", nullable: false),
                    AccountsReceivables = table.Column<long>(type: "bigint", nullable: false),
                    Inventory = table.Column<long>(type: "bigint", nullable: false),
                    AccountsPayables = table.Column<long>(type: "bigint", nullable: false),
                    OtherWorkingCapital = table.Column<long>(type: "bigint", nullable: false),
                    OtherNonCashItems = table.Column<long>(type: "bigint", nullable: false),
                    NetCashProvidedByOperatingActivities = table.Column<long>(type: "bigint", nullable: false),
                    InvestmentsInPropertyPlantAndEquipment = table.Column<long>(type: "bigint", nullable: false),
                    AcquisitionsNet = table.Column<long>(type: "bigint", nullable: false),
                    PurchasesOfInvestments = table.Column<long>(type: "bigint", nullable: false),
                    SalesMaturitiesOfInvestments = table.Column<long>(type: "bigint", nullable: false),
                    OtherInvestingActivites = table.Column<long>(type: "bigint", nullable: false),
                    NetCashUsedForInvestingActivites = table.Column<long>(type: "bigint", nullable: false),
                    DebtRepayment = table.Column<long>(type: "bigint", nullable: false),
                    CommonStockIssued = table.Column<long>(type: "bigint", nullable: false),
                    CommonStockRepurchased = table.Column<long>(type: "bigint", nullable: false),
                    DividendsPaid = table.Column<long>(type: "bigint", nullable: false),
                    OtherFinancingActivites = table.Column<long>(type: "bigint", nullable: false),
                    NetCashUsedProvidedByFinancingActivities = table.Column<long>(type: "bigint", nullable: false),
                    EffectOfForexChangesOnCash = table.Column<long>(type: "bigint", nullable: false),
                    NetChangeInCash = table.Column<long>(type: "bigint", nullable: false),
                    CashAtEndOfPeriod = table.Column<long>(type: "bigint", nullable: false),
                    CashAtBeginningOfPeriod = table.Column<long>(type: "bigint", nullable: false),
                    OperatingCashFlow = table.Column<long>(type: "bigint", nullable: false),
                    CapitalExpenditure = table.Column<long>(type: "bigint", nullable: false),
                    FreeCashFlow = table.Column<long>(type: "bigint", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFlowStatements_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => new { x.AppUserId, x.StockId });
                    table.ForeignKey(
                        name: "FK_Portfolios_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c0971e5-ec94-4663-af66-ae88cceacca6", null, "User", "USER" },
                    { "f6c47495-30b0-4a33-b2ad-b65a1eee120e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowStatements_StockId",
                table: "CashFlowStatements",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_StockId",
                table: "Portfolios",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CashFlowStatements");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c0971e5-ec94-4663-af66-ae88cceacca6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6c47495-30b0-4a33-b2ad-b65a1eee120e");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5849bcbd-fa3c-46ad-8ac1-00ff8cd9a6d7", null, "User", "USER" },
                    { "79f392bf-21e3-4e59-a899-f2a066f3884a", null, "Admin", "ADMIN" }
                });
        }
    }
}
