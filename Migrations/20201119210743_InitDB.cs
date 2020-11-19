using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StupidToDo.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignedListID = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    DoReminder = table.Column<bool>(type: "INTEGER", nullable: false),
                    Repeats = table.Column<bool>(type: "INTEGER", nullable: false),
                    RemindDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RemindTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    RepeatEvery = table.Column<decimal>(type: "TEXT", nullable: true),
                    RepeatOnDay = table.Column<int>(type: "INTEGER", nullable: false),
                    LastRepeat = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Edited = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Lists_AssignedListID",
                        column: x => x.AssignedListID,
                        principalTable: "Lists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Default" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ID", "AssignedListID", "Body", "Completed", "Created", "DoReminder", "Edited", "Frequency", "LastRepeat", "RemindDate", "RemindTime", "RepeatEvery", "RepeatOnDay", "Repeats", "Title" },
                values: new object[] { 1, 1, "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}{\\f1\\fnil Segoe UI;}}\r\n{\\colortbl ;\\red255\\green128\\blue0;\\red0\\green128\\blue0;\\red0\\green0\\blue255;\\red255\\green0\\blue128;\\red255\\green0\\blue0;\\red128\\green0\\blue255;\\red0\\green0\\blue0;}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\b\\f0\\fs18 Bold\\par\r\n\\b0\\i Italic\\par\r\n\\ul\\i0 Underline\\par\r\n\\b Bold Underline\\par\r\n\\i Bold Underline Italic\\par\r\n\\cf1\\ulnone\\b0\\i0 P\\cf2 r\\cf3 et\\cf4 t\\cf5 y \\cf6\\b COLORS\\par\r\n{\\cf7\\b0{\\field{\\*\\fldinst{HYPERLINK http://www.google.com/ }}{\\fldrslt{http://www.google.com/\\ul0\\cf0}}}}\\cf7\\b0\\f0\\fs18  Even hyperlinks!\\cf0\\f1\\par\r\n}\r\n", false, new DateTime(2020, 11, 19, 16, 7, 43, 321, DateTimeKind.Local).AddTicks(3936), false, null, 5, null, null, null, null, 0, false, "First example!" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_AssignedListID",
                table: "Items",
                column: "AssignedListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Lists");
        }
    }
}
