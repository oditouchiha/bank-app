using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedLotteryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Lotteries",
                newName: "PrizePool");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Lotteries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Lotteries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Lotteries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Lotteries");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Lotteries");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Lotteries");

            migrationBuilder.RenameColumn(
                name: "PrizePool",
                table: "Lotteries",
                newName: "Balance");
        }
    }
}
