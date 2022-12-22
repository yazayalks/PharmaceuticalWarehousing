using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class newTable10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Package_PackageId",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_PackageId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Medication");

            migrationBuilder.AddColumn<int>(
                name: "MedicationsId",
                table: "Package",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_MedicationsId",
                table: "Package",
                column: "MedicationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Medication_MedicationsId",
                table: "Package",
                column: "MedicationsId",
                principalTable: "Medication",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Medication_MedicationsId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_MedicationsId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "MedicationsId",
                table: "Package");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Medication",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_PackageId",
                table: "Medication",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Package_PackageId",
                table: "Medication",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id");
        }
    }
}
