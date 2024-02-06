using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Grades.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("eedaa917-8ceb-46b5-b766-f947a503bbf2"), "F1", false, "Faculty 1" },
                    { new Guid("f70c779c-cc69-4699-af24-d59f5a410680"), "F2", false, "Faculty 2" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("6ecdc5f3-cbb4-494d-a735-712d7e9ab48e"), false, 2, 2022 },
                    { new Guid("b9e1f4de-6164-4542-8b6e-94db86a269ee"), false, 1, 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Semesters");
        }
    }
}
