using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Grades.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("aa2bc4b7-141c-4ada-856b-a8536c26e746"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("af0ff420-7ce2-4084-828f-5e6ed8554d2a"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("326a5546-03d0-41fb-9423-6ff6f91f3e74"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("596d79d5-a191-4614-b92f-941bbd58b550"));

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialty_AspNetUsers_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubgroupNumber = table.Column<int>(type: "int", nullable: false),
                    AdmissionYear = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_AspNetUsers_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_AspNetUsers_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("d41b5c42-7e20-4efe-98a8-b6d8407fbb6e"), false, 2, 2022 },
                    { new Guid("f74ebb34-4afb-406a-b2a2-6cf1e6bbce06"), false, 1, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Specialty",
                columns: new[] { "Id", "Code", "DefaultValue", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2"), "051", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Економіка" },
                    { new Guid("b6d2cb2f-8c5a-4ff4-98b2-728c3d0f2c8e"), "075", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Маркетинг" },
                    { new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), "122", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Комп'ютерні науки" }
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
                table: "Subject",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "FacultyId", "Lecturer", "Name", "SpecialtyId" },
                values: new object[,]
                {
                    { new Guid("0b48e854-46f6-440c-985f-c6088fefe905"), "ПР", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Клебан Ю.В.", "Програмування на С#", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") },
                    { new Guid("5986491c-d802-42a3-be59-46e2028040e4"), "АД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Жуковський В.В.", "Алгоритми даних", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") },
                    { new Guid("c949df6e-a06b-4005-b474-5d52055d8a67"), "БД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Коцюк Ю.А.", "Бази Даних", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_FacultyId",
                table: "Group",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_SpecialtyId",
                table: "Group",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_FacultyId",
                table: "Specialty",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_FacultyId",
                table: "Subject",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SpecialtyId",
                table: "Subject",
                column: "SpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("08001d7a-f6b5-48ea-be58-fbf213025393"));

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: new Guid("5c3bad37-9e37-4b93-bcfb-e6e190c47e42"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("d41b5c42-7e20-4efe-98a8-b6d8407fbb6e"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("f74ebb34-4afb-406a-b2a2-6cf1e6bbce06"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4aa70efb-7589-46e7-8f97-8654ede86017");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "60322f30-8fc8-4635-9b42-4e9bd47bd43e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c79353bf-d3f0-46fb-aafd-95c15e65c242");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54f6a7b9-8abc-4979-877b-167bdc78f810", "AQAAAAIAAYagAAAAEFRoKEak3Sa/2TTTMUPRHq2WzwmuIrfNqcmqhsSDMe8ygQYfmY1VbBQ9I8/YY8YkLg==", "64e1b255-1e8e-4fec-8e87-f0332e95451b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6323186-e823-450e-8f4e-1474dc0ad462", "AQAAAAIAAYagAAAAEKuD7olBx4Uhcpd022XLiH2S6hanXy31JwRFOa4PYCOIPzLHdHL6tYwjhkEnnD7b9A==", "ee0c28e5-8810-4e50-b705-c65944a57815" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18e18446-bd5c-460d-86e3-e07fd45a5e4c", "AQAAAAIAAYagAAAAEKuQMi3sFJVTNvvSi2F1EgD2VFw8xwB8DR/RhaOnTLtrYOKv+nOWNUlaOA1DbblQlw==", "81ebc4eb-fb14-4faf-83d2-0040e0bf4f79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "650e82cc-2407-47d9-b2c6-63b894b1f82d", "AQAAAAIAAYagAAAAEPAuxtZ3pL5avPXL1ZVaoRdH9FdN9mclehcr4eUXKfWm/UetlfnQV0ebztzARlZ/Pg==", "12b0ab68-301d-44f9-923b-7307f0a07cdf" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "Name" },
                values: new object[,]
                {
                    { new Guid("aa2bc4b7-141c-4ada-856b-a8536c26e746"), "F2", false, "Faculty 2" },
                    { new Guid("af0ff420-7ce2-4084-828f-5e6ed8554d2a"), "F1", false, "Faculty 1" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "DefaultValue", "Number", "StartYear" },
                values: new object[,]
                {
                    { new Guid("326a5546-03d0-41fb-9423-6ff6f91f3e74"), false, 1, 2022 },
                    { new Guid("596d79d5-a191-4614-b92f-941bbd58b550"), false, 2, 2022 }
                });
        }
    }
}
