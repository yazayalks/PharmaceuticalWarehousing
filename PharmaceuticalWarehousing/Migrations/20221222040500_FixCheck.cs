using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class FixCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counterparties_PaymentAccounts_PaymentAccountId",
                table: "Counterparties");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Counterparties_BuyerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Salesmans_SalesmanId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Checks_CheckId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Medications_MedicationsId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageTypes_PackageTypeId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAccounts_Banks_BankId",
                table: "PaymentAccounts");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.RenameColumn(
                name: "CheckId",
                table: "Medications",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_CheckId",
                table: "Medications",
                newName: "IX_Medications_InvoiceId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiptDate",
                table: "Waybills",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "PaymentAccounts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PackageTypeId",
                table: "Packages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicationsId",
                table: "Packages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfManufacture",
                table: "Medications",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BestBeforeDate",
                table: "Medications",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "SalesmanId",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfDischarge",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentAccountId",
                table: "Counterparties",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Counterparties_PaymentAccounts_PaymentAccountId",
                table: "Counterparties",
                column: "PaymentAccountId",
                principalTable: "PaymentAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Counterparties_BuyerId",
                table: "Invoices",
                column: "BuyerId",
                principalTable: "Counterparties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Salesmans_SalesmanId",
                table: "Invoices",
                column: "SalesmanId",
                principalTable: "Salesmans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Invoices_InvoiceId",
                table: "Medications",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Medications_MedicationsId",
                table: "Packages",
                column: "MedicationsId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageTypes_PackageTypeId",
                table: "Packages",
                column: "PackageTypeId",
                principalTable: "PackageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAccounts_Banks_BankId",
                table: "PaymentAccounts",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counterparties_PaymentAccounts_PaymentAccountId",
                table: "Counterparties");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Counterparties_BuyerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Salesmans_SalesmanId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Invoices_InvoiceId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Medications_MedicationsId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageTypes_PackageTypeId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAccounts_Banks_BankId",
                table: "PaymentAccounts");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Medications",
                newName: "CheckId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_InvoiceId",
                table: "Medications",
                newName: "IX_Medications_CheckId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiptDate",
                table: "Waybills",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "PaymentAccounts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PackageTypeId",
                table: "Packages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MedicationsId",
                table: "Packages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfManufacture",
                table: "Medications",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BestBeforeDate",
                table: "Medications",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "SalesmanId",
                table: "Invoices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfDischarge",
                table: "Invoices",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Invoices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentAccountId",
                table: "Counterparties",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checks_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checks_InvoiceId",
                table: "Checks",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Counterparties_PaymentAccounts_PaymentAccountId",
                table: "Counterparties",
                column: "PaymentAccountId",
                principalTable: "PaymentAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Counterparties_BuyerId",
                table: "Invoices",
                column: "BuyerId",
                principalTable: "Counterparties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Salesmans_SalesmanId",
                table: "Invoices",
                column: "SalesmanId",
                principalTable: "Salesmans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Checks_CheckId",
                table: "Medications",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Medications_MedicationsId",
                table: "Packages",
                column: "MedicationsId",
                principalTable: "Medications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageTypes_PackageTypeId",
                table: "Packages",
                column: "PackageTypeId",
                principalTable: "PackageTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAccounts_Banks_BankId",
                table: "PaymentAccounts",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }
    }
}
