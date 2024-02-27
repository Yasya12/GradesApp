using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Grades.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitFaculty3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Specialty_SpecialtyId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_SpecialtyId",
                table: "Subject");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("c221ac94-157f-4ee1-b053-4bf9f0b0067a"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("dbd59de2-3bc1-4bd7-a0af-46bfedc5f0dc"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("384c3d4d-ecc5-4d5a-96cd-fce5f241c8dd"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("67583a96-d014-4b7e-b7e7-423ce0c489cc"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("cce0212b-fbaf-4c87-8c46-3f476576256a"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("0e8e3daa-c991-4762-992b-3c836b91f196"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("a90adf2d-7c5d-4300-b5dc-2735bd84654e"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("172e5a52-df51-4fb0-b062-bd2864185d8e"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("2050ae9f-d8dc-4f30-ae8d-d153cda3e44d"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("35e62777-dc20-402c-b9d6-82a300d645c4"));

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Subject");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6b8a6c45-6e5d-4c69-b5c1-ab9cc7f245f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5ebcc620-64f6-4b52-bdd0-1ecdab038bcf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "b2f24d3e-5d99-48fb-b308-d25db5548a47");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5c57b50-a762-4b8f-b060-cc649bf789db", "AQAAAAIAAYagAAAAEE7jQfWr+mWfHy6908ygaXrfJNzAR6amvp/CzbtjbV3WfKEZIQk+M1rWp/fAhjY2gw==", "924b95cf-a5ea-4206-a34f-6efd0eb0d2b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0ad22c0-b9ab-467a-978c-2c8417438fd5", "AQAAAAIAAYagAAAAEBGEitqJ6r8QnsBah8wbHlGXM0f0nxzZvMei5fu66BqglxGIdjjy6j3Ocz8DBOMUoQ==", "80ea0e8a-46b9-4de7-934d-3ece8b9d00ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57822bf1-2965-44a8-970c-5dfd61b0fd02", "AQAAAAIAAYagAAAAEMiq3VtpZen9y2Db4db1fbdgFRpm8pXr7SrTguG0KlFi90/RXJz5mB/E0EJRINkjMg==", "7a7ab475-4005-424a-8df3-67af3b5c2c71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbd24a9a-fee9-4d5d-9716-a43ad5f47d24", "AQAAAAIAAYagAAAAECZhOrXAKy2CuONa9qVdrHN7FuC4wZBFsrnXxV1N+9pi4OXfRouiMAsdWxvGDYgZpQ==", "1b89c0ac-23d1-4419-9a95-d6b8dd9de539" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("095aac06-3cd3-47ec-8b10-9903d8c0676d"), "F1", false, "Faculty 1" },
                    { new Guid("5f3be4fd-d81a-4a69-afae-849dfc9a1949"), "F2", false, "Faculty 2" }
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "AdmissionYear", "DefaultValue", "FacultyId", "GroupCode", "SpecialtyId", "SubgroupNumber" },
                values: new object[,]
                {
                    { new Guid("63340841-5aba-48ce-a529-267cb276aaff"), 2020, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "ЕК", new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2"), 2 },
                    { new Guid("b01c0e24-d93a-49dd-9322-3535f02a0c07"), 2021, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 1 },
                    { new Guid("d417d298-6453-40f3-874c-eaf83ba09eaa"), 2022, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("a1c652af-da44-470d-90de-e2a751902a07"), false, 1, 2022 },
                    { new Guid("fa5d83a8-5790-487c-a637-160255a00057"), false, 2, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "FacultyId", "Lecturer", "Name" },
                values: new object[,]
                {
                    { new Guid("0cd21408-3c32-478e-ad9c-873be837a264"), "ПР", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Клебан Ю.В.", "Програмування на С#" },
                    { new Guid("5c1cb489-2eb4-4895-a269-14aeb8c8bb58"), "АД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Жуковський В.В.", "Алгоритми даних" },
                    { new Guid("7b2f8fce-e3e0-4e04-aef5-0e9957d1fede"), "БД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Коцюк Ю.А.", "Бази Даних" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("095aac06-3cd3-47ec-8b10-9903d8c0676d"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("5f3be4fd-d81a-4a69-afae-849dfc9a1949"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("63340841-5aba-48ce-a529-267cb276aaff"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("b01c0e24-d93a-49dd-9322-3535f02a0c07"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("d417d298-6453-40f3-874c-eaf83ba09eaa"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("a1c652af-da44-470d-90de-e2a751902a07"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("fa5d83a8-5790-487c-a637-160255a00057"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("0cd21408-3c32-478e-ad9c-873be837a264"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("5c1cb489-2eb4-4895-a269-14aeb8c8bb58"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("7b2f8fce-e3e0-4e04-aef5-0e9957d1fede"));

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialtyId",
                table: "Subject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "024af808-9b34-4839-85b6-adda7b042ac4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d8021dcd-e854-4618-a11a-2dd00450899f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "bdcb3ed4-f0db-4fd9-8585-cbd4707219bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cabbe1d-01b9-4a43-8f46-d6661b2062a0", "AQAAAAIAAYagAAAAEMbVhC9q+eJwulMepHSiHRtwAePm21xBerJAb+7lGt/H8YiR6MdI2++PHd6dECVgdA==", "8af9605c-07d5-4a8c-a68b-86d6a8943c3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90bf3aa0-3933-4e59-8d5e-f86cac37a8e0", "AQAAAAIAAYagAAAAEHBT1H+mYLqiKteoTIGnbSOAkP6dHcNSwRsOQCOYFuXObR2YLC3vxqfkGzwISSEK5w==", "1eae1b2f-4dee-4e84-86a9-09d676f2602c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dcfb0cf-3a08-4621-817c-9e458ff83278", "AQAAAAIAAYagAAAAEKhIQy1vDyT59VtK4TdYAOXaSfxILE2sdVhst+2lJWwbOmiZKg0IabByWtOiOjegaw==", "06f424cd-6ec8-4f54-84ca-427da05e59ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddda02ed-230c-4a5f-8ab0-c4e4d06260b8", "AQAAAAIAAYagAAAAELMzqY7dn9kYwrSCgTLUqc6WDQ1UAxpQAWZtgeo57XpIcrNSvZXqlsEL19EOpK+hvg==", "0c8e7094-8aad-4304-ac46-b42b9887925f" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("c221ac94-157f-4ee1-b053-4bf9f0b0067a"), "F2", false, "Faculty 2" },
                    { new Guid("dbd59de2-3bc1-4bd7-a0af-46bfedc5f0dc"), "F1", false, "Faculty 1" }
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "AdmissionYear", "DefaultValue", "FacultyId", "GroupCode", "SpecialtyId", "SubgroupNumber" },
                values: new object[,]
                {
                    { new Guid("384c3d4d-ecc5-4d5a-96cd-fce5f241c8dd"), 2020, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "ЕК", new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2"), 2 },
                    { new Guid("67583a96-d014-4b7e-b7e7-423ce0c489cc"), 2021, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 1 },
                    { new Guid("cce0212b-fbaf-4c87-8c46-3f476576256a"), 2022, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("0e8e3daa-c991-4762-992b-3c836b91f196"), false, 2, 2022 },
                    { new Guid("a90adf2d-7c5d-4300-b5dc-2735bd84654e"), false, 1, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "FacultyId", "Lecturer", "Name", "SpecialtyId" },
                values: new object[,]
                {
                    { new Guid("172e5a52-df51-4fb0-b062-bd2864185d8e"), "БД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Коцюк Ю.А.", "Бази Даних", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") },
                    { new Guid("2050ae9f-d8dc-4f30-ae8d-d153cda3e44d"), "АД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Жуковський В.В.", "Алгоритми даних", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") },
                    { new Guid("35e62777-dc20-402c-b9d6-82a300d645c4"), "ПР", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Клебан Ю.В.", "Програмування на С#", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SpecialtyId",
                table: "Subject",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Specialty_SpecialtyId",
                table: "Subject",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
