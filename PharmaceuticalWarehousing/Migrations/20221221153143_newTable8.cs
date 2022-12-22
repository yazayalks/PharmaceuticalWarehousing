using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class newTable8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Waybill",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Invoice",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesmanId",
                table: "Invoice",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Counterparty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    House = table.Column<string>(type: "text", nullable: false),
                    Flat = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    ITN = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counterparty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salesman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesman", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_ProviderId",
                table: "Waybill",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BuyerId",
                table: "Invoice",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SalesmanId",
                table: "Invoice",
                column: "SalesmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Counterparty_BuyerId",
                table: "Invoice",
                column: "BuyerId",
                principalTable: "Counterparty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Salesman_SalesmanId",
                table: "Invoice",
                column: "SalesmanId",
                principalTable: "Salesman",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybill_Counterparty_ProviderId",
                table: "Waybill",
                column: "ProviderId",
                principalTable: "Counterparty",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Counterparty_BuyerId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Salesman_SalesmanId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybill_Counterparty_ProviderId",
                table: "Waybill");

            migrationBuilder.DropTable(
                name: "Counterparty");

            migrationBuilder.DropTable(
                name: "Salesman");

            migrationBuilder.DropIndex(
                name: "IX_Waybill_ProviderId",
                table: "Waybill");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_BuyerId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_SalesmanId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Waybill");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "SalesmanId",
                table: "Invoice");
        }
    }
}
