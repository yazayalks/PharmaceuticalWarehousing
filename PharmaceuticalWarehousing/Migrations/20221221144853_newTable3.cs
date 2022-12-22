using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class newTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Medication",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicineId",
                table: "Medication",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Medicine_MedicineId",
                table: "Medication",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Medicine_MedicineId",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_MedicineId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Medication");
        }
    }
}
