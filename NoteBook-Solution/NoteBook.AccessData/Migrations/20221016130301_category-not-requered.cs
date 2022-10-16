using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    public partial class categorynotrequered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                schema: "notebook",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "notebook",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "notebook",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                schema: "notebook",
                table: "Notes",
                column: "CategoryId",
                principalSchema: "notebook",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                schema: "notebook",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "notebook",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "notebook",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                schema: "notebook",
                table: "Notes",
                column: "CategoryId",
                principalSchema: "notebook",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
