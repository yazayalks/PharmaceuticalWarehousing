using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class newTable7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaybillId",
                table: "Statement",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Check",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfDischarge = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AmountPayable = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waybill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waybill", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statement_WaybillId",
                table: "Statement",
                column: "WaybillId");

            migrationBuilder.CreateIndex(
                name: "IX_Check_InvoiceId",
                table: "Check",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Check_Invoice_InvoiceId",
                table: "Check",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statement_Waybill_WaybillId",
                table: "Statement",
                column: "WaybillId",
                principalTable: "Waybill",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Check_Invoice_InvoiceId",
                table: "Check");

            migrationBuilder.DropForeignKey(
                name: "FK_Statement_Waybill_WaybillId",
                table: "Statement");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Waybill");

            migrationBuilder.DropIndex(
                name: "IX_Statement_WaybillId",
                table: "Statement");

            migrationBuilder.DropIndex(
                name: "IX_Check_InvoiceId",
                table: "Check");

            migrationBuilder.DropColumn(
                name: "WaybillId",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Check");
        }
    }
}
