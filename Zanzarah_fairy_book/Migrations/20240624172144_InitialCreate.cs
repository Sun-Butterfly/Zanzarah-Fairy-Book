using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanzarah_fairy_book.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fairies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Element = table.Column<int>(type: "INTEGER", nullable: false),
                    HitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    JumpAbility = table.Column<int>(type: "INTEGER", nullable: false),
                    Special = table.Column<int>(type: "INTEGER", nullable: false),
                    CanEvolve = table.Column<bool>(type: "INTEGER", nullable: false),
                    EvolveLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    EvolveFormId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fairies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fairies_Fairies_EvolveFormId",
                        column: x => x.EvolveFormId,
                        principalTable: "Fairies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fairies_EvolveFormId",
                table: "Fairies",
                column: "EvolveFormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fairies");
        }
    }
}
