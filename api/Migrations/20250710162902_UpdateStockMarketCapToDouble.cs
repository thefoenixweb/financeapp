using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStockMarketCapToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1335edbd-cdaa-4a6f-8a50-2f3d77595319");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "373efd51-c68b-470c-a630-06b4f8de44de");

            migrationBuilder.AlterColumn<double>(
                name: "MarketCap",
                table: "Stocks",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalOtherIncomeExpensesNet",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "SellingGeneralAndAdministrativeExpenses",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "SellingAndMarketingExpenses",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "Revenue",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "ResearchAndDevelopmentExpenses",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherExpenses",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OperatingIncome",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OperatingExpenses",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetIncome",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "InterestIncome",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "InterestExpense",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "IncomeTaxExpense",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "IncomeBeforeTax",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "GrossProfit",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "GeneralAndAdministrativeExpenses",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "Ebitda",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DepreciationAndAmortization",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CostOfRevenue",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CostAndExpenses",
                table: "IncomeStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "VolAvg",
                table: "CompanyProfiles",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "MktCap",
                table: "CompanyProfiles",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "StockBasedCompensation",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "SalesMaturitiesOfInvestments",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasesOfInvestments",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherWorkingCapital",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherNonCashItems",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherInvestingActivites",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherFinancingActivites",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OperatingCashFlow",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetIncome",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetChangeInCash",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetCashUsedProvidedByFinancingActivities",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetCashUsedForInvestingActivites",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetCashProvidedByOperatingActivities",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "InvestmentsInPropertyPlantAndEquipment",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "Inventory",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "FreeCashFlow",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "EffectOfForexChangesOnCash",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DividendsPaid",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DepreciationAndAmortization",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DeferredIncomeTax",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DebtRepayment",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CommonStockRepurchased",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CommonStockIssued",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "ChangeInWorkingCapital",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CashAtEndOfPeriod",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CashAtBeginningOfPeriod",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CapitalExpenditure",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "AcquisitionsNet",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "AccountsReceivables",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "AccountsPayables",
                table: "CashFlowStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalStockholdersEquity",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalNonCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalNonCurrentAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalLiabilitiesAndTotalEquity",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalLiabilitiesAndStockholdersEquity",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalLiabilities",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalInvestments",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalEquity",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalDebt",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCurrentAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TotalAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TaxPayables",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "TaxAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "ShortTermInvestments",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "ShortTermDebt",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "RetainedEarnings",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "PropertyPlantEquipmentNet",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "PreferredStock",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OthertotalStockholdersEquity",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherNonCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherNonCurrentAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherLiabilities",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherCurrentAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "OtherAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetReceivables",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "NetDebt",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "MinorityInterest",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "LongTermInvestments",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "LongTermDebt",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "Inventory",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "IntangibleAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "GoodwillAndIntangibleAssets",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "Goodwill",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DeferredTaxLiabilitiesNonCurrent",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DeferredRevenueNonCurrent",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "DeferredRevenue",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CommonStock",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CashAndShortTermInvestments",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CashAndCashEquivalents",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "CapitalLeaseObligations",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "AccumulatedOtherComprehensiveIncomeLoss",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "AccountPayables",
                table: "BalanceSheetStatements",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf735b9a-0eee-4d0d-a280-dff5118d421e", null, "User", "USER" },
                    { "c71fa553-639a-4e3b-8365-3306f49a8d4e", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf735b9a-0eee-4d0d-a280-dff5118d421e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c71fa553-639a-4e3b-8365-3306f49a8d4e");

            migrationBuilder.AlterColumn<long>(
                name: "MarketCap",
                table: "Stocks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalOtherIncomeExpensesNet",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "SellingGeneralAndAdministrativeExpenses",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "SellingAndMarketingExpenses",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Revenue",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ResearchAndDevelopmentExpenses",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherExpenses",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OperatingIncome",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OperatingExpenses",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetIncome",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "InterestIncome",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "InterestExpense",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "IncomeTaxExpense",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "IncomeBeforeTax",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "GrossProfit",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "GeneralAndAdministrativeExpenses",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Ebitda",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationAndAmortization",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CostOfRevenue",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CostAndExpenses",
                table: "IncomeStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "VolAvg",
                table: "CompanyProfiles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "MktCap",
                table: "CompanyProfiles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "StockBasedCompensation",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "SalesMaturitiesOfInvestments",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "PurchasesOfInvestments",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherWorkingCapital",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonCashItems",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherInvestingActivites",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherFinancingActivites",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OperatingCashFlow",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetIncome",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetChangeInCash",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetCashUsedProvidedByFinancingActivities",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetCashUsedForInvestingActivites",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetCashProvidedByOperatingActivities",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "InvestmentsInPropertyPlantAndEquipment",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Inventory",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "FreeCashFlow",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "EffectOfForexChangesOnCash",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DividendsPaid",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationAndAmortization",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DeferredIncomeTax",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DebtRepayment",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CommonStockRepurchased",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CommonStockIssued",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInWorkingCapital",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CashAtEndOfPeriod",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CashAtBeginningOfPeriod",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CapitalExpenditure",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "AcquisitionsNet",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "AccountsReceivables",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "AccountsPayables",
                table: "CashFlowStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalStockholdersEquity",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalNonCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalNonCurrentAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalLiabilitiesAndTotalEquity",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalLiabilitiesAndStockholdersEquity",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalLiabilities",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalInvestments",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalEquity",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalDebt",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalCurrentAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TotalAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TaxPayables",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "TaxAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ShortTermInvestments",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ShortTermDebt",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "RetainedEarnings",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyPlantEquipmentNet",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "PreferredStock",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OthertotalStockholdersEquity",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonCurrentAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherLiabilities",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherCurrentLiabilities",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherCurrentAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "OtherAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetReceivables",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "NetDebt",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "MinorityInterest",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "LongTermInvestments",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "LongTermDebt",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Inventory",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "IntangibleAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "GoodwillAndIntangibleAssets",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Goodwill",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DeferredTaxLiabilitiesNonCurrent",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DeferredRevenueNonCurrent",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "DeferredRevenue",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CommonStock",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CashAndShortTermInvestments",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CashAndCashEquivalents",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "CapitalLeaseObligations",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "AccumulatedOtherComprehensiveIncomeLoss",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "AccountPayables",
                table: "BalanceSheetStatements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1335edbd-cdaa-4a6f-8a50-2f3d77595319", null, "User", "USER" },
                    { "373efd51-c68b-470c-a630-06b4f8de44de", null, "Admin", "ADMIN" }
                });
        }
    }
}
