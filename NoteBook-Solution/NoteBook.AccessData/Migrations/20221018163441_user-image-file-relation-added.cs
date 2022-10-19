using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    public partial class userimagefilerelationadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                schema: "notebook",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FileId",
                schema: "notebook",
                table: "Users",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Files_FileId",
                schema: "notebook",
                table: "Users",
                column: "FileId",
                principalSchema: "general",
                principalTable: "Files",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Files_FileId",
                schema: "notebook",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FileId",
                schema: "notebook",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "notebook",
                table: "Users");
        }
    }
}
