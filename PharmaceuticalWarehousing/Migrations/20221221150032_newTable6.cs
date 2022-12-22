using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class newTable6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckId",
                table: "Medication",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatementId",
                table: "Medication",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Check",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medication_CheckId",
                table: "Medication",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_StatementId",
                table: "Medication",
                column: "StatementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Check_CheckId",
                table: "Medication",
                column: "CheckId",
                principalTable: "Check",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Statement_StatementId",
                table: "Medication",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Check_CheckId",
                table: "Medication");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Statement_StatementId",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "Check");

            migrationBuilder.DropTable(
                name: "Statement");

            migrationBuilder.DropIndex(
                name: "IX_Medication_CheckId",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_StatementId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "StatementId",
                table: "Medication");
        }
    }
}
