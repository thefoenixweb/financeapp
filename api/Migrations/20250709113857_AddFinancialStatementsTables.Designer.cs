﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250709113857_AddFinancialStatementsTables")]
    partial class AddFinancialStatementsTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e411f16a-7ff7-40bf-80ef-7ea9a1e7f818",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "5e06cf70-b90c-4b40-aa0e-3fa3863b373c",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("api.Models.BalanceSheetStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AcceptedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("AccountPayables")
                        .HasColumnType("bigint");

                    b.Property<long>("AccumulatedOtherComprehensiveIncomeLoss")
                        .HasColumnType("bigint");

                    b.Property<string>("CalendarYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CapitalLeaseObligations")
                        .HasColumnType("bigint");

                    b.Property<long>("CashAndCashEquivalents")
                        .HasColumnType("bigint");

                    b.Property<long>("CashAndShortTermInvestments")
                        .HasColumnType("bigint");

                    b.Property<string>("Cik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CommonStock")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("DeferredRevenue")
                        .HasColumnType("bigint");

                    b.Property<long>("DeferredRevenueNonCurrent")
                        .HasColumnType("bigint");

                    b.Property<long>("DeferredTaxLiabilitiesNonCurrent")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FillingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinalLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Goodwill")
                        .HasColumnType("bigint");

                    b.Property<long>("GoodwillAndIntangibleAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("IntangibleAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("Inventory")
                        .HasColumnType("bigint");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LongTermDebt")
                        .HasColumnType("bigint");

                    b.Property<long>("LongTermInvestments")
                        .HasColumnType("bigint");

                    b.Property<long>("MinorityInterest")
                        .HasColumnType("bigint");

                    b.Property<long>("NetDebt")
                        .HasColumnType("bigint");

                    b.Property<long>("NetReceivables")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherCurrentAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherCurrentLiabilities")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherLiabilities")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherNonCurrentAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherNonCurrentLiabilities")
                        .HasColumnType("bigint");

                    b.Property<long>("OthertotalStockholdersEquity")
                        .HasColumnType("bigint");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PreferredStock")
                        .HasColumnType("bigint");

                    b.Property<long>("PropertyPlantEquipmentNet")
                        .HasColumnType("bigint");

                    b.Property<string>("ReportedCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RetainedEarnings")
                        .HasColumnType("bigint");

                    b.Property<long>("ShortTermDebt")
                        .HasColumnType("bigint");

                    b.Property<long>("ShortTermInvestments")
                        .HasColumnType("bigint");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TaxAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("TaxPayables")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalCurrentAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalCurrentLiabilities")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDebt")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalEquity")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalInvestments")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalLiabilities")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalLiabilitiesAndStockholdersEquity")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalLiabilitiesAndTotalEquity")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalNonCurrentAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalNonCurrentLiabilities")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalStockholdersEquity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("BalanceSheetStatements");
                });

            modelBuilder.Entity("api.Models.CashFlowStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AcceptedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("AccountsPayables")
                        .HasColumnType("bigint");

                    b.Property<long>("AccountsReceivables")
                        .HasColumnType("bigint");

                    b.Property<long>("AcquisitionsNet")
                        .HasColumnType("bigint");

                    b.Property<string>("CalendarYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CapitalExpenditure")
                        .HasColumnType("bigint");

                    b.Property<long>("CashAtBeginningOfPeriod")
                        .HasColumnType("bigint");

                    b.Property<long>("CashAtEndOfPeriod")
                        .HasColumnType("bigint");

                    b.Property<long>("ChangeInWorkingCapital")
                        .HasColumnType("bigint");

                    b.Property<string>("Cik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CommonStockIssued")
                        .HasColumnType("bigint");

                    b.Property<long>("CommonStockRepurchased")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("DebtRepayment")
                        .HasColumnType("bigint");

                    b.Property<long>("DeferredIncomeTax")
                        .HasColumnType("bigint");

                    b.Property<long>("DepreciationAndAmortization")
                        .HasColumnType("bigint");

                    b.Property<long>("DividendsPaid")
                        .HasColumnType("bigint");

                    b.Property<long>("EffectOfForexChangesOnCash")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FillingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinalLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FreeCashFlow")
                        .HasColumnType("bigint");

                    b.Property<long>("Inventory")
                        .HasColumnType("bigint");

                    b.Property<long>("InvestmentsInPropertyPlantAndEquipment")
                        .HasColumnType("bigint");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NetCashProvidedByOperatingActivities")
                        .HasColumnType("bigint");

                    b.Property<long>("NetCashUsedForInvestingActivites")
                        .HasColumnType("bigint");

                    b.Property<long>("NetCashUsedProvidedByFinancingActivities")
                        .HasColumnType("bigint");

                    b.Property<long>("NetChangeInCash")
                        .HasColumnType("bigint");

                    b.Property<long>("NetIncome")
                        .HasColumnType("bigint");

                    b.Property<long>("OperatingCashFlow")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherFinancingActivites")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherInvestingActivites")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherNonCashItems")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherWorkingCapital")
                        .HasColumnType("bigint");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PurchasesOfInvestments")
                        .HasColumnType("bigint");

                    b.Property<string>("ReportedCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SalesMaturitiesOfInvestments")
                        .HasColumnType("bigint");

                    b.Property<long>("StockBasedCompensation")
                        .HasColumnType("bigint");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("CashFlowStatements");
                });

            modelBuilder.Entity("api.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("StockId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("api.Models.CompanyProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Beta")
                        .HasColumnType("float");

                    b.Property<string>("Ceo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Changes")
                        .HasColumnType("float");

                    b.Property<string>("Cik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cusip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Dcf")
                        .HasColumnType("float");

                    b.Property<double>("DcfDiff")
                        .HasColumnType("float");

                    b.Property<bool>("DefaultImage")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exchange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExchangeShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullTimeEmployees")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IpoDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActivelyTrading")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdr")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEtf")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFund")
                        .HasColumnType("bit");

                    b.Property<string>("Isin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LastDiv")
                        .HasColumnType("float");

                    b.Property<long>("MktCap")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VolAvg")
                        .HasColumnType("bigint");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockId")
                        .IsUnique()
                        .HasFilter("[StockId] IS NOT NULL");

                    b.ToTable("CompanyProfiles");
                });

            modelBuilder.Entity("api.Models.IncomeStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AcceptedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CalendarYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CostAndExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("CostOfRevenue")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("DepreciationAndAmortization")
                        .HasColumnType("bigint");

                    b.Property<long>("Ebitda")
                        .HasColumnType("bigint");

                    b.Property<double>("EbitdaRatio")
                        .HasColumnType("float");

                    b.Property<double>("Eps")
                        .HasColumnType("float");

                    b.Property<double>("Epsdiluted")
                        .HasColumnType("float");

                    b.Property<DateTime>("FillingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinalLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GeneralAndAdministrativeExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("GrossProfit")
                        .HasColumnType("bigint");

                    b.Property<double>("GrossProfitRatio")
                        .HasColumnType("float");

                    b.Property<long>("IncomeBeforeTax")
                        .HasColumnType("bigint");

                    b.Property<double>("IncomeBeforeTaxRatio")
                        .HasColumnType("float");

                    b.Property<long>("IncomeTaxExpense")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestExpense")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestIncome")
                        .HasColumnType("bigint");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NetIncome")
                        .HasColumnType("bigint");

                    b.Property<double>("NetIncomeRatio")
                        .HasColumnType("float");

                    b.Property<long>("OperatingExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("OperatingIncome")
                        .HasColumnType("bigint");

                    b.Property<double>("OperatingIncomeRatio")
                        .HasColumnType("float");

                    b.Property<long>("OtherExpenses")
                        .HasColumnType("bigint");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportedCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ResearchAndDevelopmentExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("Revenue")
                        .HasColumnType("bigint");

                    b.Property<long>("SellingAndMarketingExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("SellingGeneralAndAdministrativeExpenses")
                        .HasColumnType("bigint");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalOtherIncomeExpensesNet")
                        .HasColumnType("bigint");

                    b.Property<long>("WeightedAverageShsOut")
                        .HasColumnType("bigint");

                    b.Property<long>("WeightedAverageShsOutDil")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("IncomeStatements");
                });

            modelBuilder.Entity("api.Models.Portfolio", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("AppUserId", "StockId");

                    b.HasIndex("StockId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("api.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LastDiv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("MarketCap")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Purchase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.BalanceSheetStatement", b =>
                {
                    b.HasOne("api.Models.Stock", "Stock")
                        .WithMany("BalanceSheetStatements")
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("api.Models.CashFlowStatement", b =>
                {
                    b.HasOne("api.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("api.Models.Comment", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Stock", "Stock")
                        .WithMany("Comments")
                        .HasForeignKey("StockId");

                    b.Navigation("AppUser");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("api.Models.CompanyProfile", b =>
                {
                    b.HasOne("api.Models.Stock", "Stock")
                        .WithOne("CompanyProfile")
                        .HasForeignKey("api.Models.CompanyProfile", "StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("api.Models.IncomeStatement", b =>
                {
                    b.HasOne("api.Models.Stock", "Stock")
                        .WithMany("IncomeStatements")
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("api.Models.Portfolio", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany("Portfolios")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Stock", "Stock")
                        .WithMany("Portfolios")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("api.Models.Stock", b =>
                {
                    b.Navigation("BalanceSheetStatements");

                    b.Navigation("Comments");

                    b.Navigation("CompanyProfile")
                        .IsRequired();

                    b.Navigation("IncomeStatements");

                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
