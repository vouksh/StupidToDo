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
                    RepeatEvery = table.Column<int>(type: "INTEGER", nullable: true),
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
                values: new object[] { 1, 1, "Blah blah blah", false, new DateTime(2020, 11, 13, 15, 1, 10, 282, DateTimeKind.Local).AddTicks(2020), false, null, 4, null, null, null, null, 0, false, "Do something" });

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
