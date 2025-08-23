using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDescriptionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarketCap = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BalanceSheetStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportedCurrency = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cik = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FillingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    calendarYear = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CashAndCashEquivalents = table.Column<double>(type: "double", nullable: false),
                    ShortTermInvestments = table.Column<double>(type: "double", nullable: false),
                    CashAndShortTermInvestments = table.Column<double>(type: "double", nullable: false),
                    NetReceivables = table.Column<double>(type: "double", nullable: false),
                    Inventory = table.Column<double>(type: "double", nullable: false),
                    OtherCurrentAssets = table.Column<double>(type: "double", nullable: false),
                    TotalCurrentAssets = table.Column<double>(type: "double", nullable: false),
                    PropertyPlantEquipmentNet = table.Column<double>(type: "double", nullable: false),
                    Goodwill = table.Column<double>(type: "double", nullable: false),
                    IntangibleAssets = table.Column<double>(type: "double", nullable: false),
                    GoodwillAndIntangibleAssets = table.Column<double>(type: "double", nullable: false),
                    LongTermInvestments = table.Column<double>(type: "double", nullable: false),
                    TaxAssets = table.Column<double>(type: "double", nullable: false),
                    OtherNonCurrentAssets = table.Column<double>(type: "double", nullable: false),
                    TotalNonCurrentAssets = table.Column<double>(type: "double", nullable: false),
                    OtherAssets = table.Column<double>(type: "double", nullable: false),
                    TotalAssets = table.Column<double>(type: "double", nullable: false),
                    AccountPayables = table.Column<double>(type: "double", nullable: false),
                    ShortTermDebt = table.Column<double>(type: "double", nullable: false),
                    TaxPayables = table.Column<double>(type: "double", nullable: false),
                    DeferredRevenue = table.Column<double>(type: "double", nullable: false),
                    OtherCurrentLiabilities = table.Column<double>(type: "double", nullable: false),
                    TotalCurrentLiabilities = table.Column<double>(type: "double", nullable: false),
                    LongTermDebt = table.Column<double>(type: "double", nullable: false),
                    DeferredRevenueNonCurrent = table.Column<double>(type: "double", nullable: false),
                    DeferredTaxLiabilitiesNonCurrent = table.Column<double>(type: "double", nullable: false),
                    OtherNonCurrentLiabilities = table.Column<double>(type: "double", nullable: false),
                    TotalNonCurrentLiabilities = table.Column<double>(type: "double", nullable: false),
                    OtherLiabilities = table.Column<double>(type: "double", nullable: false),
                    CapitalLeaseObligations = table.Column<double>(type: "double", nullable: false),
                    TotalLiabilities = table.Column<double>(type: "double", nullable: false),
                    PreferredStock = table.Column<double>(type: "double", nullable: false),
                    CommonStock = table.Column<double>(type: "double", nullable: false),
                    RetainedEarnings = table.Column<double>(type: "double", nullable: false),
                    AccumulatedOtherComprehensiveIncomeLoss = table.Column<double>(type: "double", nullable: false),
                    OthertotalStockholdersEquity = table.Column<double>(type: "double", nullable: false),
                    TotalStockholdersEquity = table.Column<double>(type: "double", nullable: false),
                    TotalEquity = table.Column<double>(type: "double", nullable: false),
                    TotalLiabilitiesAndStockholdersEquity = table.Column<double>(type: "double", nullable: false),
                    MinorityInterest = table.Column<double>(type: "double", nullable: false),
                    TotalLiabilitiesAndTotalEquity = table.Column<double>(type: "double", nullable: false),
                    TotalInvestments = table.Column<double>(type: "double", nullable: false),
                    TotalDebt = table.Column<double>(type: "double", nullable: false),
                    NetDebt = table.Column<double>(type: "double", nullable: false),
                    Link = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinalLink = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashFlowStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportedCurrency = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cik = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FillingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    calendarYear = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NetIncome = table.Column<double>(type: "double", nullable: false),
                    DepreciationAndAmortization = table.Column<double>(type: "double", nullable: false),
                    DeferredIncomeTax = table.Column<double>(type: "double", nullable: false),
                    StockBasedCompensation = table.Column<double>(type: "double", nullable: false),
                    ChangeInWorkingCapital = table.Column<double>(type: "double", nullable: false),
                    AccountsReceivables = table.Column<double>(type: "double", nullable: false),
                    Inventory = table.Column<double>(type: "double", nullable: false),
                    AccountsPayables = table.Column<double>(type: "double", nullable: false),
                    OtherWorkingCapital = table.Column<double>(type: "double", nullable: false),
                    OtherNonCashItems = table.Column<double>(type: "double", nullable: false),
                    NetCashProvidedByOperatingActivities = table.Column<double>(type: "double", nullable: false),
                    InvestmentsInPropertyPlantAndEquipment = table.Column<double>(type: "double", nullable: false),
                    AcquisitionsNet = table.Column<double>(type: "double", nullable: false),
                    PurchasesOfInvestments = table.Column<double>(type: "double", nullable: false),
                    SalesMaturitiesOfInvestments = table.Column<double>(type: "double", nullable: false),
                    OtherInvestingActivites = table.Column<double>(type: "double", nullable: false),
                    NetCashUsedForInvestingActivites = table.Column<double>(type: "double", nullable: false),
                    DebtRepayment = table.Column<double>(type: "double", nullable: false),
                    CommonStockIssued = table.Column<double>(type: "double", nullable: false),
                    CommonStockRepurchased = table.Column<double>(type: "double", nullable: false),
                    DividendsPaid = table.Column<double>(type: "double", nullable: false),
                    OtherFinancingActivites = table.Column<double>(type: "double", nullable: false),
                    NetCashUsedProvidedByFinancingActivities = table.Column<double>(type: "double", nullable: false),
                    EffectOfForexChangesOnCash = table.Column<double>(type: "double", nullable: false),
                    NetChangeInCash = table.Column<double>(type: "double", nullable: false),
                    CashAtEndOfPeriod = table.Column<double>(type: "double", nullable: false),
                    CashAtBeginningOfPeriod = table.Column<double>(type: "double", nullable: false),
                    OperatingCashFlow = table.Column<double>(type: "double", nullable: false),
                    CapitalExpenditure = table.Column<double>(type: "double", nullable: false),
                    FreeCashFlow = table.Column<double>(type: "double", nullable: false),
                    Link = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinalLink = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Beta = table.Column<double>(type: "double", nullable: false),
                    VolAvg = table.Column<double>(type: "double", nullable: false),
                    MktCap = table.Column<double>(type: "double", nullable: false),
                    LastDiv = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Changes = table.Column<double>(type: "double", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Currency = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cik = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Isin = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cusip = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exchange = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExchangeShortName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Industry = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ceo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sector = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullTimeEmployees = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DcfDiff = table.Column<double>(type: "double", nullable: false),
                    Dcf = table.Column<double>(type: "double", nullable: false),
                    Image = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IpoDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DefaultImage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsEtf = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActivelyTrading = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsAdr = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFund = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncomeStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportedCurrency = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cik = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FillingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    calendarYear = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Revenue = table.Column<double>(type: "double", nullable: false),
                    CostOfRevenue = table.Column<double>(type: "double", nullable: false),
                    GrossProfit = table.Column<double>(type: "double", nullable: false),
                    GrossProfitRatio = table.Column<double>(type: "double", nullable: false),
                    ResearchAndDevelopmentExpenses = table.Column<double>(type: "double", nullable: false),
                    GeneralAndAdministrativeExpenses = table.Column<double>(type: "double", nullable: false),
                    SellingAndMarketingExpenses = table.Column<double>(type: "double", nullable: false),
                    SellingGeneralAndAdministrativeExpenses = table.Column<double>(type: "double", nullable: false),
                    OtherExpenses = table.Column<double>(type: "double", nullable: false),
                    OperatingExpenses = table.Column<double>(type: "double", nullable: false),
                    CostAndExpenses = table.Column<double>(type: "double", nullable: false),
                    InterestIncome = table.Column<double>(type: "double", nullable: false),
                    InterestExpense = table.Column<double>(type: "double", nullable: false),
                    DepreciationAndAmortization = table.Column<double>(type: "double", nullable: false),
                    Ebitda = table.Column<double>(type: "double", nullable: false),
                    EbitdaRatio = table.Column<double>(type: "double", nullable: false),
                    OperatingIncome = table.Column<double>(type: "double", nullable: false),
                    OperatingIncomeRatio = table.Column<double>(type: "double", nullable: false),
                    TotalOtherIncomeExpensesNet = table.Column<double>(type: "double", nullable: false),
                    IncomeBeforeTax = table.Column<double>(type: "double", nullable: false),
                    IncomeBeforeTaxRatio = table.Column<double>(type: "double", nullable: false),
                    IncomeTaxExpense = table.Column<double>(type: "double", nullable: false),
                    NetIncome = table.Column<double>(type: "double", nullable: false),
                    NetIncomeRatio = table.Column<double>(type: "double", nullable: false),
                    Eps = table.Column<double>(type: "double", nullable: false),
                    Epsdiluted = table.Column<double>(type: "double", nullable: false),
                    WeightedAverageShsOut = table.Column<long>(type: "bigint", nullable: false),
                    WeightedAverageShsOutDil = table.Column<long>(type: "bigint", nullable: false),
                    Link = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinalLink = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e9ffbf1-d1db-4d9d-beb9-4607e8aa3d34", null, "User", "USER" },
                    { "e32049e7-b90a-4785-a275-f8a2a175fee2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetStatements_StockId",
                table: "BalanceSheetStatements",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowStatements_StockId",
                table: "CashFlowStatements",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_StockId",
                table: "CompanyProfiles",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatements_StockId",
                table: "IncomeStatements",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_StockId",
                table: "Portfolios",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BalanceSheetStatements");

            migrationBuilder.DropTable(
                name: "CashFlowStatements");

            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "IncomeStatements");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
