using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GradesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Speciality = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("0254284e-def0-4daa-a221-0ac1dc48616c"), "jane@example.com", "$2a$11$d1j2dIPr2NVeg3O3qDE/8.NbHCGhzUMtXdUqPt9cWWvxgfHu590CG", "Student", "jane_smith" },
                    { new Guid("5e4a1dee-ea7a-4dbc-a8e5-0c8f99c95496"), "john@example.com", "$2a$11$jgAEEJLsavkSIu.YtVWv9.DCQFq2IonZ9ScMc5X4GYoxg1F81HNmW", "Student", "john_doe" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FullName", "Speciality", "UserId", "Year" },
                values: new object[,]
                {
                    { new Guid("6fad6572-d860-41e1-b201-faf3739330c9"), "Jane Smith", "Mathematics", new Guid("0254284e-def0-4daa-a221-0ac1dc48616c"), 3 },
                    { new Guid("e5f6d5df-7be0-4992-a1e7-5e7d2289650f"), "John Doe", "Computer Science", new Guid("5e4a1dee-ea7a-4dbc-a8e5-0c8f99c95496"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
