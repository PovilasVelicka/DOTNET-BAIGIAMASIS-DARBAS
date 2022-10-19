using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    public partial class noteimagerelationadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                schema: "notebook",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_FileId",
                schema: "notebook",
                table: "Notes",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Files_FileId",
                schema: "notebook",
                table: "Notes",
                column: "FileId",
                principalSchema: "general",
                principalTable: "Files",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Files_FileId",
                schema: "notebook",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_FileId",
                schema: "notebook",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "notebook",
                table: "Notes");
        }
    }
}
