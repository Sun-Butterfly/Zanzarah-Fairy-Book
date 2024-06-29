using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanzarah_fairy_book.Migrations
{
    /// <inheritdoc />
    public partial class evolve_forms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolveFormId",
                table: "Fairies");

            migrationBuilder.CreateTable(
                name: "EvolveForms",
                columns: table => new
                {
                    FromId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolveForms", x => new { x.FromId, x.ToId });
                    table.ForeignKey(
                        name: "FK_EvolveForms_Fairies_FromId",
                        column: x => x.FromId,
                        principalTable: "Fairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvolveForms_Fairies_ToId",
                        column: x => x.ToId,
                        principalTable: "Fairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvolveForms_ToId",
                table: "EvolveForms",
                column: "ToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvolveForms");

            migrationBuilder.AddColumn<int>(
                name: "EvolveFormId",
                table: "Fairies",
                type: "INTEGER",
                nullable: true);
        }
    }
}
