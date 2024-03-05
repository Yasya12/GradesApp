using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Grades.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class grade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("b93ac11f-e410-4e93-8291-c19be7ac5993"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("b9e7343e-a7fa-475e-8b9a-14f191c8e70e"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("1854ba4d-f1f9-4155-a4f4-fb7eca90b11f"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("ef3018ed-0da7-4c69-8bc2-2f69361d95ac"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("3b12b51e-54ad-461c-bdca-2bcbf03010e6"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("cebaafd2-1800-4f23-9b0e-d0fca405dbae"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("e0bfe523-d69f-47e5-99c9-b6a4c074b097"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0f403f76-052b-4d39-a098-fc3f8f6f74c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b9e87728-db6a-4cdb-bbd4-acead77ec023");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "0719e8b7-b000-43f0-b4d3-e6752407ae2e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89f89d6a-6073-4e2b-9fcf-4d9f5378907b", "AQAAAAIAAYagAAAAEO0vhHWZJBwIRHAQ/0yWxGt+iaoUXc0K1uLxt70bli4ZDv20HABFUl+OHTZAEELAmQ==", "eea19680-06a3-47e9-88cc-ec07f8481fa3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46460def-d10e-4893-9b83-e4c399863e00", "AQAAAAIAAYagAAAAEHlN2OnVr6p8Cip7MgsD2XMEbBfx1Sy39KGnXdF3jTbPCrAQ2Ok4AyZndwnVYFHSFQ==", "b7e74266-0dd5-43a1-8a73-6f9346bbca03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55b4af70-7d4f-4df9-bf4c-9e48d74330c1", "AQAAAAIAAYagAAAAELt9Xr0zXlLxPkhulTUqYl3BYKC3JXl+yyT+h9YN9rPcF2Ch7zn0Ty86pj4MP8tYlQ==", "78597025-b02a-41a3-9765-69c3460f5935" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b90ae517-7bd9-4333-a9bd-75bbebb7fd65", "AQAAAAIAAYagAAAAEHCsrJ+CJqrjIpe5YNlAeNQLw0kwdkwEhbC4mw7ct422MgGb+rywozbUdZ1rGiCuHg==", "f9c1fde4-7f06-4530-b563-5b60b8c95c62" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("7d26e99c-9c1b-420c-b561-5e4bc34c8add"), "F1", false, "Faculty 1" },
                    { new Guid("f2dd857c-30e3-4362-8cbf-5faf4f84e9df"), "F2", false, "Faculty 2" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("073d98da-c2cf-40e0-9277-17e1e7e0009a"), false, 1, 2022 },
                    { new Guid("4921af78-66ea-4d41-a029-e494aee3d10b"), false, 2, 2022 }
                });

            migrationBuilder.InsertData(
                table: "SubjectStudent",
                columns: new[] { "Id", "DefaultValue", "Grade", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("11da4969-0c08-4e87-b694-31d71e8aa32b"), false, 89f, new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), new Guid("a9e449e0-d8a1-4bfa-8dc5-3ec0d8b9a68d") },
                    { new Guid("d502f5b4-cf9d-46c7-ba58-5ebeb79537b1"), false, 96f, new Guid("fbcbb0a9-85e0-45a3-93c8-b1a057e4f062"), new Guid("dc57160e-d37e-4d81-a048-245106c4854b") },
                    { new Guid("f3e4b0b0-2f0d-43d4-b4ee-623de6ce7ae4"), false, 100f, new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), new Guid("7b96a6c2-8469-4d58-a3f0-bbb1aef4907c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("7d26e99c-9c1b-420c-b561-5e4bc34c8add"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("f2dd857c-30e3-4362-8cbf-5faf4f84e9df"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("073d98da-c2cf-40e0-9277-17e1e7e0009a"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("4921af78-66ea-4d41-a029-e494aee3d10b"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("11da4969-0c08-4e87-b694-31d71e8aa32b"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("d502f5b4-cf9d-46c7-ba58-5ebeb79537b1"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("f3e4b0b0-2f0d-43d4-b4ee-623de6ce7ae4"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1eeef829-f30f-4f3f-b932-4fa9893585ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6bc9e281-ea5a-4a42-b546-8970dc2f1181");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "cfd51137-0220-4e2a-8544-0306797dcd3f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42c0865f-f405-44ad-9028-68cfa6589b44", "AQAAAAIAAYagAAAAED00Oqyv+6+/jE2oUrXhZtXvlnZQ1B4+AN/5OKIqlyInVTbe1EXbHbSmAGEsMwGy+Q==", "eaf3beb6-878a-4fb2-9b5b-076cfae88836" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96a6df39-4de3-442a-b8ac-323dc4f861d6", "AQAAAAIAAYagAAAAEBQm0B23QYrghTIJhBugNkX4Lo7cFUKs5XeUBWbcwztMBBXH5WkxuA/Z8yCqVprJtQ==", "fc573d0f-40fc-4d55-b607-58c989a5980d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79ae9788-825b-4eb8-8be4-91c7d088de15", "AQAAAAIAAYagAAAAELZtOolt0MhiMQwY9U3AnAn18ANgyoAB6m8K3c+EYL5p77BGwChmATju9QjpEhEEXw==", "5b952364-de1d-4751-b719-74dfd7f21539" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29f91421-700d-49d2-9447-622bf56585c3", "AQAAAAIAAYagAAAAENU0qMFLPvYfMyh5OFPy3KFRXaFshG+pPq4m23O9B4CTwH44MYm7rNy+BsiVPQjTMg==", "617c21b4-c469-4158-bc04-3f6e5cf74201" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("b93ac11f-e410-4e93-8291-c19be7ac5993"), "F1", false, "Faculty 1" },
                    { new Guid("b9e7343e-a7fa-475e-8b9a-14f191c8e70e"), "F2", false, "Faculty 2" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("1854ba4d-f1f9-4155-a4f4-fb7eca90b11f"), false, 2, 2022 },
                    { new Guid("ef3018ed-0da7-4c69-8bc2-2f69361d95ac"), false, 1, 2022 }
                });

            migrationBuilder.InsertData(
                table: "SubjectStudent",
                columns: new[] { "Id", "DefaultValue", "Grade", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("3b12b51e-54ad-461c-bdca-2bcbf03010e6"), false, 89f, new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), new Guid("a9e449e0-d8a1-4bfa-8dc5-3ec0d8b9a68d") },
                    { new Guid("cebaafd2-1800-4f23-9b0e-d0fca405dbae"), false, 96f, new Guid("fbcbb0a9-85e0-45a3-93c8-b1a057e4f062"), new Guid("dc57160e-d37e-4d81-a048-245106c4854b") },
                    { new Guid("e0bfe523-d69f-47e5-99c9-b6a4c074b097"), false, 100f, new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), new Guid("7b96a6c2-8469-4d58-a3f0-bbb1aef4907c") }
                });
        }
    }
}
