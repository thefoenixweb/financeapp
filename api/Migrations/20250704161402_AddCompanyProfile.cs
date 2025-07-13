using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1cdfcc-736c-4870-b263-ba5b8c0affa7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3423a67f-de3c-4f53-8ba1-7ee745459ca6");

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Beta = table.Column<double>(type: "float", nullable: false),
                    VolAvg = table.Column<long>(type: "bigint", nullable: false),
                    MktCap = table.Column<long>(type: "bigint", nullable: false),
                    LastDiv = table.Column<double>(type: "float", nullable: false),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changes = table.Column<double>(type: "float", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cusip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exchange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ceo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullTimeEmployees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DcfDiff = table.Column<double>(type: "float", nullable: false),
                    Dcf = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpoDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultImage = table.Column<bool>(type: "bit", nullable: false),
                    IsEtf = table.Column<bool>(type: "bit", nullable: false),
                    IsActivelyTrading = table.Column<bool>(type: "bit", nullable: false),
                    IsAdr = table.Column<bool>(type: "bit", nullable: false),
                    IsFund = table.Column<bool>(type: "bit", nullable: false),
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
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "026185d2-2bd0-4f13-842c-408907f60967", null, "Admin", "ADMIN" },
                    { "fad8eafd-da29-458f-829b-1eb0c3947dbb", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_StockId",
                table: "CompanyProfiles",
                column: "StockId",
                unique: true,
                filter: "[StockId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProfiles");

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
                    { "0d1cdfcc-736c-4870-b263-ba5b8c0affa7", null, "Admin", "ADMIN" },
                    { "3423a67f-de3c-4f53-8ba1-7ee745459ca6", null, "User", "USER" }
                });
        }
    }
}
