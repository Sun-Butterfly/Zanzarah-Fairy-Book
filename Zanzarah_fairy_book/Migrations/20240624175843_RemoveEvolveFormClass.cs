using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanzarah_fairy_book.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEvolveFormClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fairies_Fairies_EvolveFormId",
                table: "Fairies");

            migrationBuilder.DropIndex(
                name: "IX_Fairies_EvolveFormId",
                table: "Fairies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Fairies_EvolveFormId",
                table: "Fairies",
                column: "EvolveFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fairies_Fairies_EvolveFormId",
                table: "Fairies",
                column: "EvolveFormId",
                principalTable: "Fairies",
                principalColumn: "Id");
        }
    }
}
