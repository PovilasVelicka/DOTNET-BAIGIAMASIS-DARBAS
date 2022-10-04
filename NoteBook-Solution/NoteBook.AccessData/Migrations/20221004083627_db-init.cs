using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    public partial class dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "notebook");

            migrationBuilder.EnsureSchema(
                name: "sequrity");

            migrationBuilder.EnsureSchema(
                name: "general");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "notebook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => new { x.UserId, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                schema: "general",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalPart = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    Domain = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    Value = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirstNames",
                schema: "general",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LastNames",
                schema: "general",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "sequrity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailId = table.Column<int>(type: "int", nullable: false),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Emails_EmailId",
                        column: x => x.EmailId,
                        principalSchema: "general",
                        principalTable: "Emails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutUsers",
                schema: "notebook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstNameId = table.Column<int>(type: "int", nullable: false),
                    LastNameId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUsers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "sequrity",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutUsers_FirstNames_FirstNameId",
                        column: x => x.FirstNameId,
                        principalSchema: "general",
                        principalTable: "FirstNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutUsers_LastNames_LastNameId",
                        column: x => x.LastNameId,
                        principalSchema: "general",
                        principalTable: "LastNames",
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_AboutUsers_AccountId",
                schema: "notebook",
                table: "AboutUsers",
                column: "AccountId");

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
                schema: "sequrity",
                table: "Accounts",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "UI_LoginName",
                schema: "sequrity",
                table: "Accounts",
                column: "LoginName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_Emails",
                schema: "general",
                table: "Emails",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_FirstName",
                schema: "general",
                table: "FirstNames",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UI_LastName",
                schema: "general",
                table: "LastNames",
                column: "Value",
                unique: true);

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
                name: "Notes",
                schema: "notebook");

            migrationBuilder.DropTable(
                name: "AboutUsers",
                schema: "notebook");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "notebook");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "sequrity");

            migrationBuilder.DropTable(
                name: "FirstNames",
                schema: "general");

            migrationBuilder.DropTable(
                name: "LastNames",
                schema: "general");

            migrationBuilder.DropTable(
                name: "Emails",
                schema: "general");
        }
    }
}
