using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Grades.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitFaculty2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_AspNetUsers_FacultyId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_AspNetUsers_FacultyId",
                table: "Specialty");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_FacultyId",
                table: "Subject");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("08001d7a-f6b5-48ea-be58-fbf213025393"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("5c3bad37-9e37-4b93-bcfb-e6e190c47e42"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("6baa21a2-8095-4884-8ff0-3358260bfb42"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("82927e12-f832-424d-bbb1-8978c94c897f"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("fc0df677-74bb-4099-b868-eea8f9c76380"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("d41b5c42-7e20-4efe-98a8-b6d8407fbb6e"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("f74ebb34-4afb-406a-b2a2-6cf1e6bbce06"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("0b48e854-46f6-440c-985f-c6088fefe905"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("5986491c-d802-42a3-be59-46e2028040e4"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: new Guid("c949df6e-a06b-4005-b474-5d52055d8a67"));

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Specialty",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Group",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Group_AspNetUsers_FacultyId",
                table: "Group",
                column: "FacultyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_AspNetUsers_FacultyId",
                table: "Specialty",
                column: "FacultyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_FacultyId",
                table: "Subject",
                column: "FacultyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_AspNetUsers_FacultyId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_AspNetUsers_FacultyId",
                table: "Specialty");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_FacultyId",
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

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Specialty",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Group",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "01d141fe-537d-46a7-824e-e33d2f9f1f03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e497c9ef-886a-4c9a-b873-39a6c35127fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "90c3dd3b-e8c4-4285-96f7-e82d078acb7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9782eeb9-6315-4aaa-854c-66f0c95b21a2", "AQAAAAIAAYagAAAAEF7t5bwnRJ6mTsl6SoyWIonn7+MMUSm9Bq3qgjvHV26UTpkUwRhFTOp9TzYmnMxhkQ==", "c6997e68-296b-4ddb-9b2e-8fbbefc872c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6eeb7a91-bcf2-40b8-a6b4-27bbf7e5c468", "AQAAAAIAAYagAAAAECEvi8DtuZjxjY9xYCmtl36AsjTbhcEgsG8lriMiaRLqjIFWESBD0obXKi/THjlkgg==", "c7a23cdf-de03-4ea2-a09e-91d72ed08ae2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7036d82a-8460-4698-ae58-979f27894257", "AQAAAAIAAYagAAAAEMN9Xw02kW+Cgmcx8EQH4CpwUTqlFWPGcAKMqHJILfc4imaPjyOkzQNGVr9FSTlh2w==", "2b58baa3-ab70-4426-8002-a694682edc1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "695afa48-d95c-4ea3-b062-b00250195b07", "AQAAAAIAAYagAAAAEEs/bRH85aDa58K5uJuHzVIPVe+36/3lLOR8FsktJzcnVogXaRanhODLo47qTvExPg==", "5979f356-c58b-427b-ad04-ecf646a4235a" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("08001d7a-f6b5-48ea-be58-fbf213025393"), "F2", false, "Faculty 2" },
                    { new Guid("5c3bad37-9e37-4b93-bcfb-e6e190c47e42"), "F1", false, "Faculty 1" }
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "AdmissionYear", "DefaultValue", "FacultyId", "GroupCode", "SpecialtyId", "SubgroupNumber" },
                values: new object[,]
                {
                    { new Guid("6baa21a2-8095-4884-8ff0-3358260bfb42"), 2020, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "ЕК", new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2"), 2 },
                    { new Guid("82927e12-f832-424d-bbb1-8978c94c897f"), 2022, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 2 },
                    { new Guid("fc0df677-74bb-4099-b868-eea8f9c76380"), 2021, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("d41b5c42-7e20-4efe-98a8-b6d8407fbb6e"), false, 2, 2022 },
                    { new Guid("f74ebb34-4afb-406a-b2a2-6cf1e6bbce06"), false, 1, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "FacultyId", "Lecturer", "Name", "SpecialtyId" },
                values: new object[,]
                {
                    { new Guid("0b48e854-46f6-440c-985f-c6088fefe905"), "ПР", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Клебан Ю.В.", "Програмування на С#", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") },
                    { new Guid("5986491c-d802-42a3-be59-46e2028040e4"), "АД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Жуковський В.В.", "Алгоритми даних", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") },
                    { new Guid("c949df6e-a06b-4005-b474-5d52055d8a67"), "БД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Коцюк Ю.А.", "Бази Даних", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Group_AspNetUsers_FacultyId",
                table: "Group",
                column: "FacultyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_AspNetUsers_FacultyId",
                table: "Specialty",
                column: "FacultyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_FacultyId",
                table: "Subject",
                column: "FacultyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
