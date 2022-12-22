using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Manufacturers_ManufacturerId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Medicines_MedicineId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Categorys_CategoryId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybills_Counterparties_ProviderId",
                table: "Waybills");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Waybills",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Medicines",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WaybillId",
                table: "Medications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Medications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Medications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Manufacturers_ManufacturerId",
                table: "Medications",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Medicines_MedicineId",
                table: "Medications",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications",
                column: "WaybillId",
                principalTable: "Waybills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Categorys_CategoryId",
                table: "Medicines",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Waybills_Counterparties_ProviderId",
                table: "Waybills",
                column: "ProviderId",
                principalTable: "Counterparties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Manufacturers_ManufacturerId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Medicines_MedicineId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Categorys_CategoryId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybills_Counterparties_ProviderId",
                table: "Waybills");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Waybills",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Medicines",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "WaybillId",
                table: "Medications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Medications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Medications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications",
                column: "WaybillId",
                principalTable: "Waybills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Categorys_CategoryId",
                table: "Medicines",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybills_Counterparties_ProviderId",
                table: "Waybills",
                column: "ProviderId",
                principalTable: "Counterparties",
                principalColumn: "Id");
        }
    }
}
