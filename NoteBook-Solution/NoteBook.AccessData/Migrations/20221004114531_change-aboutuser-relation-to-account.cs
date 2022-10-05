using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    public partial class changeaboutuserrelationtoaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AboutUsers_UserId",
                schema: "notebook",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "notebook",
                table: "Notes",
                newName: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Accounts_AccountId",
                schema: "notebook",
                table: "Notes",
                column: "AccountId",
                principalSchema: "sequrity",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Accounts_AccountId",
                schema: "notebook",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                schema: "notebook",
                table: "Notes",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AboutUsers_UserId",
                schema: "notebook",
                table: "Notes",
                column: "UserId",
                principalSchema: "notebook",
                principalTable: "AboutUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
