using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageBookInformation.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "NumberOfPages", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { new Guid("169eaa41-0d5c-415b-9c32-4f7bb692460b"), "Sample Author 2", "0987654321", 300, 2024, "Sample Book 2" },
                    { new Guid("568f0ec0-f4b0-4eee-be3f-f8966bf248b2"), "Sample Author 1", "1234567890", 200, 2023, "Sample Book 1" },
                    { new Guid("9bf341fc-2727-475c-a226-1135fed3c713"), "Sample Author 3", "1212121212", 400, 2025, "Sample Book 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
