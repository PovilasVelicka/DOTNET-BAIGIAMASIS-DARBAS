using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "notebook");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "notebook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => new { x.UserId, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirstName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LastName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailId = table.Column<int>(type: "int", nullable: false),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutUsers",
                schema: "notebook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNameId = table.Column<int>(type: "int", nullable: false),
                    LastNameId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUsers_FirstName_FirstNameId",
                        column: x => x.FirstNameId,
                        principalTable: "FirstName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutUsers_LastName_LastNameId",
                        column: x => x.LastNameId,
                        principalTable: "LastName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "notebook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    Reminder = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UseReminder = table.Column<bool>(type: "bit", nullable: false),
                    Fill = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false, defaultValueSql: "('#FFFFFFFF')"),
                    Color = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false, defaultValueSql: "('#000000FF')"),
                    Complete = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DoPriority = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_AboutUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "notebook",
                        principalTable: "AboutUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Categories",
                        columns: x => new { x.UserId, x.CategoryId },
                        principalSchema: "notebook",
                        principalTable: "Categories",
                        principalColumns: new[] { "UserId", "Id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsers_FirstNameId",
                schema: "notebook",
                table: "AboutUsers",
                column: "FirstNameId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsers_LastNameId",
                schema: "notebook",
                table: "AboutUsers",
                column: "LastNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmailId",
                table: "Accounts",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes",
                schema: "notebook",
                table: "Notes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId_CategoryId",
                schema: "notebook",
                table: "Notes",
                columns: new[] { "UserId", "CategoryId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Notes",
                schema: "notebook");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "AboutUsers",
                schema: "notebook");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "notebook");

            migrationBuilder.DropTable(
                name: "FirstName");

            migrationBuilder.DropTable(
                name: "LastName");
        }
    }
}
