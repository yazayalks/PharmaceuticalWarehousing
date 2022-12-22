using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class User2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Check_Invoice_InvoiceId",
                table: "Check");

            migrationBuilder.DropForeignKey(
                name: "FK_Counterparty_PaymentAccount_PaymentAccountId",
                table: "Counterparty");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Counterparty_BuyerId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Salesman_SalesmanId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Check_CheckId",
                table: "Medication");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Manufacturer_ManufacturerId",
                table: "Medication");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Medicine_MedicineId",
                table: "Medication");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Statement_StatementId",
                table: "Medication");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Category_CategoryId",
                table: "Medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_Medication_MedicationsId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_PackageType_PackageTypeId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAccount_Bank_BankId",
                table: "PaymentAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Statement_Waybill_WaybillId",
                table: "Statement");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybill_Counterparty_ProviderId",
                table: "Waybill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waybill",
                table: "Waybill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statement",
                table: "Statement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salesman",
                table: "Salesman");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentAccount",
                table: "PaymentAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageType",
                table: "PackageType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medication",
                table: "Medication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Counterparty",
                table: "Counterparty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Check",
                table: "Check");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bank",
                table: "Bank");

            migrationBuilder.RenameTable(
                name: "Waybill",
                newName: "Waybills");

            migrationBuilder.RenameTable(
                name: "Statement",
                newName: "Statements");

            migrationBuilder.RenameTable(
                name: "Salesman",
                newName: "Salesmans");

            migrationBuilder.RenameTable(
                name: "PaymentAccount",
                newName: "PaymentAccounts");

            migrationBuilder.RenameTable(
                name: "PackageType",
                newName: "PackageTypes");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "Packages");

            migrationBuilder.RenameTable(
                name: "Medicine",
                newName: "Medicines");

            migrationBuilder.RenameTable(
                name: "Medication",
                newName: "Medications");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                newName: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Counterparty",
                newName: "Counterparties");

            migrationBuilder.RenameTable(
                name: "Check",
                newName: "Checks");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categorys");

            migrationBuilder.RenameTable(
                name: "Bank",
                newName: "Banks");

            migrationBuilder.RenameIndex(
                name: "IX_Waybill_ProviderId",
                table: "Waybills",
                newName: "IX_Waybills_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Statement_WaybillId",
                table: "Statements",
                newName: "IX_Statements_WaybillId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentAccount_BankId",
                table: "PaymentAccounts",
                newName: "IX_PaymentAccounts_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_PackageTypeId",
                table: "Packages",
                newName: "IX_Packages_PackageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_MedicationsId",
                table: "Packages",
                newName: "IX_Packages_MedicationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_CategoryId",
                table: "Medicines",
                newName: "IX_Medicines_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Medication_StatementId",
                table: "Medications",
                newName: "IX_Medications_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_Medication_MedicineId",
                table: "Medications",
                newName: "IX_Medications_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_Medication_ManufacturerId",
                table: "Medications",
                newName: "IX_Medications_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Medication_CheckId",
                table: "Medications",
                newName: "IX_Medications_CheckId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_SalesmanId",
                table: "Invoices",
                newName: "IX_Invoices_SalesmanId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_BuyerId",
                table: "Invoices",
                newName: "IX_Invoices_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Counterparty_PaymentAccountId",
                table: "Counterparties",
                newName: "IX_Counterparties_PaymentAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Check_InvoiceId",
                table: "Checks",
                newName: "IX_Checks_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waybills",
                table: "Waybills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statements",
                table: "Statements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salesmans",
                table: "Salesmans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentAccounts",
                table: "PaymentAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageTypes",
                table: "PackageTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medications",
                table: "Medications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Counterparties",
                table: "Counterparties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checks",
                table: "Checks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccessRight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Read = table.Column<bool>(type: "boolean", nullable: false),
                    Write = table.Column<bool>(type: "boolean", nullable: false),
                    Edit = table.Column<bool>(type: "boolean", nullable: false),
                    Delete = table.Column<bool>(type: "boolean", nullable: false),
                    Form = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessRight_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessRight_UserId",
                table: "AccessRight",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Invoices_InvoiceId",
                table: "Checks",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

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
                name: "FK_Medications_Manufacturers_ManufacturerId",
                table: "Medications",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Medicines_MedicineId",
                table: "Medications",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Statements_StatementId",
                table: "Medications",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Categorys_CategoryId",
                table: "Medicines",
                column: "CategoryId",
                principalTable: "Categorys",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Statements_Waybills_WaybillId",
                table: "Statements",
                column: "WaybillId",
                principalTable: "Waybills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybills_Counterparties_ProviderId",
                table: "Waybills",
                column: "ProviderId",
                principalTable: "Counterparties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Invoices_InvoiceId",
                table: "Checks");

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
                name: "FK_Medications_Manufacturers_ManufacturerId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Medicines_MedicineId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Statements_StatementId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Categorys_CategoryId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Medications_MedicationsId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageTypes_PackageTypeId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAccounts_Banks_BankId",
                table: "PaymentAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Statements_Waybills_WaybillId",
                table: "Statements");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybills_Counterparties_ProviderId",
                table: "Waybills");

            migrationBuilder.DropTable(
                name: "AccessRight");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waybills",
                table: "Waybills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statements",
                table: "Statements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salesmans",
                table: "Salesmans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentAccounts",
                table: "PaymentAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageTypes",
                table: "PackageTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medications",
                table: "Medications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Counterparties",
                table: "Counterparties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checks",
                table: "Checks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.RenameTable(
                name: "Waybills",
                newName: "Waybill");

            migrationBuilder.RenameTable(
                name: "Statements",
                newName: "Statement");

            migrationBuilder.RenameTable(
                name: "Salesmans",
                newName: "Salesman");

            migrationBuilder.RenameTable(
                name: "PaymentAccounts",
                newName: "PaymentAccount");

            migrationBuilder.RenameTable(
                name: "PackageTypes",
                newName: "PackageType");

            migrationBuilder.RenameTable(
                name: "Packages",
                newName: "Package");

            migrationBuilder.RenameTable(
                name: "Medicines",
                newName: "Medicine");

            migrationBuilder.RenameTable(
                name: "Medications",
                newName: "Medication");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "Manufacturer");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "Counterparties",
                newName: "Counterparty");

            migrationBuilder.RenameTable(
                name: "Checks",
                newName: "Check");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "Bank");

            migrationBuilder.RenameIndex(
                name: "IX_Waybills_ProviderId",
                table: "Waybill",
                newName: "IX_Waybill_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Statements_WaybillId",
                table: "Statement",
                newName: "IX_Statement_WaybillId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentAccounts_BankId",
                table: "PaymentAccount",
                newName: "IX_PaymentAccount_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_PackageTypeId",
                table: "Package",
                newName: "IX_Package_PackageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_MedicationsId",
                table: "Package",
                newName: "IX_Package_MedicationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicines_CategoryId",
                table: "Medicine",
                newName: "IX_Medicine_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_StatementId",
                table: "Medication",
                newName: "IX_Medication_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_MedicineId",
                table: "Medication",
                newName: "IX_Medication_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_ManufacturerId",
                table: "Medication",
                newName: "IX_Medication_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_CheckId",
                table: "Medication",
                newName: "IX_Medication_CheckId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SalesmanId",
                table: "Invoice",
                newName: "IX_Invoice_SalesmanId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_BuyerId",
                table: "Invoice",
                newName: "IX_Invoice_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Counterparties_PaymentAccountId",
                table: "Counterparty",
                newName: "IX_Counterparty_PaymentAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Checks_InvoiceId",
                table: "Check",
                newName: "IX_Check_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waybill",
                table: "Waybill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statement",
                table: "Statement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salesman",
                table: "Salesman",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentAccount",
                table: "PaymentAccount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageType",
                table: "PackageType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicine",
                table: "Medicine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medication",
                table: "Medication",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Counterparty",
                table: "Counterparty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Check",
                table: "Check",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bank",
                table: "Bank",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Check_Invoice_InvoiceId",
                table: "Check",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Counterparty_PaymentAccount_PaymentAccountId",
                table: "Counterparty",
                column: "PaymentAccountId",
                principalTable: "PaymentAccount",
                principalColumn: "Id");

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
                name: "FK_Medication_Check_CheckId",
                table: "Medication",
                column: "CheckId",
                principalTable: "Check",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Manufacturer_ManufacturerId",
                table: "Medication",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Medicine_MedicineId",
                table: "Medication",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Statement_StatementId",
                table: "Medication",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Category_CategoryId",
                table: "Medicine",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Medication_MedicationsId",
                table: "Package",
                column: "MedicationsId",
                principalTable: "Medication",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_PackageType_PackageTypeId",
                table: "Package",
                column: "PackageTypeId",
                principalTable: "PackageType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAccount_Bank_BankId",
                table: "PaymentAccount",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statement_Waybill_WaybillId",
                table: "Statement",
                column: "WaybillId",
                principalTable: "Waybill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybill_Counterparty_ProviderId",
                table: "Waybill",
                column: "ProviderId",
                principalTable: "Counterparty",
                principalColumn: "Id");
        }
    }
}
