using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLibrary.Migrations
{
    public partial class InitDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketPrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    MarketId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketPrices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPrices_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1000, "C1", "Company 1" },
                    { 1001, "C2", "Company 2" },
                    { 1002, "C3", "Company 3" },
                    { 1003, "C4", "Company 4" },
                    { 1004, "C5", "Company 5" }
                });

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1000, "M1", "Market 1" },
                    { 1001, "M2", "Market 2" },
                    { 1002, "M3", "Market 3" },
                    { 1003, "M4", "Market 4" },
                    { 1004, "M5", "Market 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketPrices_CompanyId",
                table: "MarketPrices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPrices_MarketId",
                table: "MarketPrices",
                column: "MarketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketPrices");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Markets");
        }
    }
}
