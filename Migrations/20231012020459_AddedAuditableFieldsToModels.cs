using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuditableFieldsToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountPortofolio_Accounts_AccountId",
                table: "AccountPortofolio");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountPortofolio_Portofolio_PortofolioId",
                table: "AccountPortofolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Accounts_DepositorAccountId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Accounts_WithdrawlAccountId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portofolio",
                table: "Portofolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountPortofolio",
                table: "AccountPortofolio");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Portofolio",
                newName: "Portofolios");

            migrationBuilder.RenameTable(
                name: "AccountPortofolio",
                newName: "AccountsPortofolios");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_WithdrawlAccountId",
                table: "Transactions",
                newName: "IX_Transactions_WithdrawlAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_DepositorAccountId",
                table: "Transactions",
                newName: "IX_Transactions_DepositorAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountPortofolio_PortofolioId",
                table: "AccountsPortofolios",
                newName: "IX_AccountsPortofolios_PortofolioId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Portofolios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Portofolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Portofolios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Portofolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portofolios",
                table: "Portofolios",
                column: "PortofolioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountsPortofolios",
                table: "AccountsPortofolios",
                columns: new[] { "AccountId", "PortofolioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsPortofolios_Accounts_AccountId",
                table: "AccountsPortofolios",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsPortofolios_Portofolios_PortofolioId",
                table: "AccountsPortofolios",
                column: "PortofolioId",
                principalTable: "Portofolios",
                principalColumn: "PortofolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_DepositorAccountId",
                table: "Transactions",
                column: "DepositorAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_WithdrawlAccountId",
                table: "Transactions",
                column: "WithdrawlAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsPortofolios_Accounts_AccountId",
                table: "AccountsPortofolios");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsPortofolios_Portofolios_PortofolioId",
                table: "AccountsPortofolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_DepositorAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_WithdrawlAccountId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portofolios",
                table: "Portofolios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountsPortofolios",
                table: "AccountsPortofolios");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Portofolios");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Portofolios");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Portofolios");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Portofolios");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Portofolios",
                newName: "Portofolio");

            migrationBuilder.RenameTable(
                name: "AccountsPortofolios",
                newName: "AccountPortofolio");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_WithdrawlAccountId",
                table: "Transaction",
                newName: "IX_Transaction_WithdrawlAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_DepositorAccountId",
                table: "Transaction",
                newName: "IX_Transaction_DepositorAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsPortofolios_PortofolioId",
                table: "AccountPortofolio",
                newName: "IX_AccountPortofolio_PortofolioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portofolio",
                table: "Portofolio",
                column: "PortofolioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountPortofolio",
                table: "AccountPortofolio",
                columns: new[] { "AccountId", "PortofolioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPortofolio_Accounts_AccountId",
                table: "AccountPortofolio",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPortofolio_Portofolio_PortofolioId",
                table: "AccountPortofolio",
                column: "PortofolioId",
                principalTable: "Portofolio",
                principalColumn: "PortofolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Accounts_DepositorAccountId",
                table: "Transaction",
                column: "DepositorAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Accounts_WithdrawlAccountId",
                table: "Transaction",
                column: "WithdrawlAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
