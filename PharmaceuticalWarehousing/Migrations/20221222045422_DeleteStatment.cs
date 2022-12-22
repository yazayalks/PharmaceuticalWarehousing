using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PharmaceuticalWarehousing.Migrations
{
    /// <inheritdoc />
    public partial class DeleteStatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Statements_StatementId",
                table: "Medications");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.RenameColumn(
                name: "StatementId",
                table: "Medications",
                newName: "WaybillId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_StatementId",
                table: "Medications",
                newName: "IX_Medications_WaybillId");

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

            migrationBuilder.RenameColumn(
                name: "WaybillId",
                table: "Medications",
                newName: "StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_WaybillId",
                table: "Medications",
                newName: "IX_Medications_StatementId");

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WaybillId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_Waybills_WaybillId",
                        column: x => x.WaybillId,
                        principalTable: "Waybills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statements_WaybillId",
                table: "Statements",
                column: "WaybillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Statements_StatementId",
                table: "Medications",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id");
        }
    }
}
