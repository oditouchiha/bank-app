using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPortofolioToLottery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsPortofolios");

            migrationBuilder.DropTable(
                name: "Portofolios");

            migrationBuilder.CreateTable(
                name: "Lotteries",
                columns: table => new
                {
                    LotteryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotteries", x => x.LotteryId);
                });

            migrationBuilder.CreateTable(
                name: "AccountsLotteries",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    LotteryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsLotteries", x => new { x.AccountId, x.LotteryId });
                    table.ForeignKey(
                        name: "FK_AccountsLotteries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsLotteries_Lotteries_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lotteries",
                        principalColumn: "LotteryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsLotteries_LotteryId",
                table: "AccountsLotteries",
                column: "LotteryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsLotteries");

            migrationBuilder.DropTable(
                name: "Lotteries");

            migrationBuilder.CreateTable(
                name: "Portofolios",
                columns: table => new
                {
                    PortofolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portofolios", x => x.PortofolioId);
                });

            migrationBuilder.CreateTable(
                name: "AccountsPortofolios",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PortofolioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsPortofolios", x => new { x.AccountId, x.PortofolioId });
                    table.ForeignKey(
                        name: "FK_AccountsPortofolios_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsPortofolios_Portofolios_PortofolioId",
                        column: x => x.PortofolioId,
                        principalTable: "Portofolios",
                        principalColumn: "PortofolioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsPortofolios_PortofolioId",
                table: "AccountsPortofolios",
                column: "PortofolioId");
        }
    }
}
