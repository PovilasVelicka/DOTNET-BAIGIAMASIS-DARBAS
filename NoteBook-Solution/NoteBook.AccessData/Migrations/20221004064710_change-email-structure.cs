using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    public partial class changeemailstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Email",
                newName: "LocalPart");

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Email",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Email");

            migrationBuilder.RenameColumn(
                name: "LocalPart",
                table: "Email",
                newName: "Value");
        }
    }
}
