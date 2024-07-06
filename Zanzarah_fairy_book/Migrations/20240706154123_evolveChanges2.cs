using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanzarah_fairy_book.Migrations
{
    /// <inheritdoc />
    public partial class evolveChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolveItem",
                table: "Fairies");

            migrationBuilder.DropColumn(
                name: "EvolveKind",
                table: "Fairies");

            migrationBuilder.DropColumn(
                name: "EvolveLevel",
                table: "Fairies");

            migrationBuilder.AddColumn<string>(
                name: "EvolveItem",
                table: "EvolveForms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvolveKind",
                table: "EvolveForms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvolveLevel",
                table: "EvolveForms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolveItem",
                table: "EvolveForms");

            migrationBuilder.DropColumn(
                name: "EvolveKind",
                table: "EvolveForms");

            migrationBuilder.DropColumn(
                name: "EvolveLevel",
                table: "EvolveForms");

            migrationBuilder.AddColumn<string>(
                name: "EvolveItem",
                table: "Fairies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvolveKind",
                table: "Fairies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvolveLevel",
                table: "Fairies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
