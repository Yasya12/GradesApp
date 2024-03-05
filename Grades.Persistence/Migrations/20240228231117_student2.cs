using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Grades.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class student2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("18ce82a0-21ce-473a-82f2-d8e3ffafadc4"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("2a13698c-e07a-4034-9cba-78682462e836"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("93049f33-864d-429c-bd11-9523734880e2"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("ed6c3181-fa1e-4b38-8ef1-fa56bd71c795"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("8f3826cf-01f5-4924-b9d9-8c3441e219f9"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("d4008063-8e45-4849-95af-ecf8b6a94894"));

            migrationBuilder.DeleteData(
                table: "SubjectStudent",
                keyColumn: "Id",
                keyValue: new Guid("d8cab743-80ad-4a1f-9dbc-5fa65864114c"));

            migrationBuilder.AddColumn<float>(
                name: "Grade",
                table: "SubjectStudent",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "SubjectStudent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3d4fdb03-92c3-4124-85a7-2f116f865602");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "14b9640c-7239-48eb-9c03-ace78edf9d9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8a56e8ea-0b9d-41cd-8901-a642569c62bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4bffa93-fb52-4c24-899e-b8af349fada1", "AQAAAAIAAYagAAAAEJFMX4NFd1m7hOgQx3oEadBKKOnUoDwnMdYuR4BRiUV08xuZOM478O+VJeeFNBXaiQ==", "d703b1b6-e49c-465a-bd2e-6892f895be1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1913ac87-b24b-46ae-b283-5fbb8963e0e8", "AQAAAAIAAYagAAAAEEkyWtG0WIhUloP5GztTCn85D6AZGKBuZe62pbgjvii8BCnHCB0c0kcr6YIRXRurFQ==", "778d3f0f-2af0-4509-9044-7aa82135ba82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7500e0b8-908c-4414-ae4b-b8f0e8ab7c07", "AQAAAAIAAYagAAAAEIi6Frmkn9xCXYq7X+vqB5rs2TOAJAhjDlu+3D/W8HtnOvw2XONwbAxUABrKJ37bnQ==", "13100d08-e170-4ae5-993d-88522c5e9ac9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb7b8067-1b87-4e30-8985-9893e1ff1cc6", "AQAAAAIAAYagAAAAEAOkpL89zbaXCY1n2/+vQkieDAg/YVOQFIZ5Ikl5fUx4qLEQAgP0xsZ1WdBIdwndGw==", "1075af1a-c4d8-4c71-87ef-ca2c24b3e5a2" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("18ce82a0-21ce-473a-82f2-d8e3ffafadc4"), "F1", false, "Faculty 1" },
                    { new Guid("2a13698c-e07a-4034-9cba-78682462e836"), "F2", false, "Faculty 2" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("93049f33-864d-429c-bd11-9523734880e2"), false, 1, 2022 },
                    { new Guid("ed6c3181-fa1e-4b38-8ef1-fa56bd71c795"), false, 2, 2022 }
                });

            migrationBuilder.InsertData(
                table: "SubjectStudent",
                columns: new[] { "Id", "DefaultValue", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("8f3826cf-01f5-4924-b9d9-8c3441e219f9"), false, new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), new Guid("7b96a6c2-8469-4d58-a3f0-bbb1aef4907c") },
                    { new Guid("d4008063-8e45-4849-95af-ecf8b6a94894"), false, new Guid("fbcbb0a9-85e0-45a3-93c8-b1a057e4f062"), new Guid("dc57160e-d37e-4d81-a048-245106c4854b") },
                    { new Guid("d8cab743-80ad-4a1f-9dbc-5fa65864114c"), false, new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), new Guid("a9e449e0-d8a1-4bfa-8dc5-3ec0d8b9a68d") }
                });
        }
    }
}
