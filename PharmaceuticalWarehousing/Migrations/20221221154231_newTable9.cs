using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class newTable9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentAccountId",
                table: "Counterparty",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<int>(type: "integer", nullable: false),
                    BankId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentAccount_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counterparty_PaymentAccountId",
                table: "Counterparty",
                column: "PaymentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAccount_BankId",
                table: "PaymentAccount",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Counterparty_PaymentAccount_PaymentAccountId",
                table: "Counterparty",
                column: "PaymentAccountId",
                principalTable: "PaymentAccount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counterparty_PaymentAccount_PaymentAccountId",
                table: "Counterparty");

            migrationBuilder.DropTable(
                name: "PaymentAccount");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropIndex(
                name: "IX_Counterparty_PaymentAccountId",
                table: "Counterparty");

            migrationBuilder.DropColumn(
                name: "PaymentAccountId",
                table: "Counterparty");
        }
    }
}
