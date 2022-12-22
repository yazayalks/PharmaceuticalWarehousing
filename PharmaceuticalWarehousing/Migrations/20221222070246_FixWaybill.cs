using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class FixWaybill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications");

            migrationBuilder.AlterColumn<int>(
                name: "WaybillId",
                table: "Medications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications",
                column: "WaybillId",
                principalTable: "Waybills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications");

            migrationBuilder.AlterColumn<int>(
                name: "WaybillId",
                table: "Medications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Waybills_WaybillId",
                table: "Medications",
                column: "WaybillId",
                principalTable: "Waybills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
