using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedPortofolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portofolio",
                columns: table => new
                {
                    PortofolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portofolio", x => x.PortofolioId);
                });

            migrationBuilder.CreateTable(
                name: "AccountPortofolio",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PortofolioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPortofolio", x => new { x.AccountId, x.PortofolioId });
                    table.ForeignKey(
                        name: "FK_AccountPortofolio_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPortofolio_Portofolio_PortofolioId",
                        column: x => x.PortofolioId,
                        principalTable: "Portofolio",
                        principalColumn: "PortofolioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPortofolio_PortofolioId",
                table: "AccountPortofolio",
                column: "PortofolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPortofolio");

            migrationBuilder.DropTable(
                name: "Portofolio");
        }
    }
}
