using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanzarah_fairy_book.Migrations
{
    /// <inheritdoc />
    public partial class EvolveUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CanEvolve",
                table: "Fairies",
                newName: "EvolveKind");

            migrationBuilder.AddColumn<int>(
                name: "EvolveItem",
                table: "Fairies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolveItem",
                table: "Fairies");

            migrationBuilder.RenameColumn(
                name: "EvolveKind",
                table: "Fairies",
                newName: "CanEvolve");
        }
    }
}
