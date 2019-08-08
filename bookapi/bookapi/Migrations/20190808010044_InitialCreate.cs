using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookapi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1902, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Steinbeck" });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen", "King" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Category", "Title" },
                values: new object[] { 1, 1, "a", "The Grapes of Wrath" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Category", "Title" },
                values: new object[] { 2, 1, "b", "Cannery Row" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Category", "Title" },
                values: new object[] { 3, 2, "c", "The Shining" });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
