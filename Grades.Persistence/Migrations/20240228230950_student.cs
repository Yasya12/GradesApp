using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Grades.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialty_AspNetUsers_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lecturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_AspNetUsers_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_AspNetUsers_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Group_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageGrade = table.Column<float>(type: "real", nullable: false),
                    SpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultValue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectStudent_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "3d4fdb03-92c3-4124-85a7-2f116f865602", "Admin", "ADMIN" },
                    { "2", "14b9640c-7239-48eb-9c03-ace78edf9d9d", "Faculty", "FACULTY" },
                    { "3", "8a56e8ea-0b9d-41cd-8901-a642569c62bd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "Abbreviation", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "49b754b0-8831-4b1a-a44f-8e18a0c2578e", "A", 0, "f4bffa93-fb52-4c24-899e-b8af349fada1", "ApplicationUser", "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJFMX4NFd1m7hOgQx3oEadBKKOnUoDwnMdYuR4BRiUV08xuZOM478O+VJeeFNBXaiQ==", null, false, "d703b1b6-e49c-465a-bd2e-6892f895be1b", false, "admin@gmail.com" },
                    { "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45", "LF", 0, "1913ac87-b24b-46ae-b283-5fbb8963e0e8", "ApplicationUser", "law@gmail.com", true, false, null, "Law Faculty", "LAW@GMAIL.COM", "LAW@GMAIL.COM", "AQAAAAIAAYagAAAAEEkyWtG0WIhUloP5GztTCn85D6AZGKBuZe62pbgjvii8BCnHCB0c0kcr6YIRXRurFQ==", null, false, "778d3f0f-2af0-4509-9044-7aa82135ba82", false, "law@gmail.com" },
                    { "c8b05623-d42b-4a9f-947e-dcd54538ee1d", "U", 0, "7500e0b8-908c-4414-ae4b-b8f0e8ab7c07", "ApplicationUser", "user@gmail.com", true, false, null, "User", "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEIi6Frmkn9xCXYq7X+vqB5rs2TOAJAhjDlu+3D/W8HtnOvw2XONwbAxUABrKJ37bnQ==", null, false, "13100d08-e170-4ae5-993d-88522c5e9ac9", false, "user@gmail.com" },
                    { "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "EC", 0, "cb7b8067-1b87-4e30-8985-9893e1ff1cc6", "ApplicationUser", "economy@gmail.com", true, false, null, "Economy Faculty", "ECONOMY@GMAIL.COM", "ECONOMY@GMAIL.COM", "AQAAAAIAAYagAAAAEAOkpL89zbaXCY1n2/+vQkieDAg/YVOQFIZ5Ikl5fUx4qLEQAgP0xsZ1WdBIdwndGw==", null, false, "1075af1a-c4d8-4c71-87ef-ca2c24b3e5a2", false, "economy@gmail.com" }
                });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "49b754b0-8831-4b1a-a44f-8e18a0c2578e" },
                    { "2", "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45" },
                    { "3", "c8b05623-d42b-4a9f-947e-dcd54538ee1d" },
                    { "2", "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" }
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
                table: "Subject",
                columns: new[] { "Id", "Abbreviation", "DefaultValue", "FacultyId", "Lecturer", "Name" },
                values: new object[,]
                {
                    { new Guid("7b96a6c2-8469-4d58-a3f0-bbb1aef4907c"), "БД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Коцюк Ю.А.", "Бази Даних" },
                    { new Guid("a9e449e0-d8a1-4bfa-8dc5-3ec0d8b9a68d"), "ПР", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Клебан Ю.В.", "Програмування на С#" },
                    { new Guid("dc57160e-d37e-4d81-a048-245106c4854b"), "АД", false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "Жуковський В.В.", "Алгоритми даних" }
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "AdmissionYear", "DefaultValue", "FacultyId", "GroupCode", "SpecialtyId", "SubgroupNumber" },
                values: new object[,]
                {
                    { new Guid("2d78dc28-25c1-4e52-a08d-5a78a8f81c5d"), 2021, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 1 },
                    { new Guid("4c09d510-2ef3-417a-b36a-41b82d39b159"), 2022, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "КН", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), 2 },
                    { new Guid("69f6d9a2-3a21-48f0-aa59-2bc982b367c3"), 2020, false, "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", "ЕК", new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AverageGrade", "DefaultValue", "Grades", "GroupId", "LastName", "Name", "SpecialtyId" },
                values: new object[,]
                {
                    { new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), 0f, false, "[89,100]", new Guid("2d78dc28-25c1-4e52-a08d-5a78a8f81c5d"), "Лайтер", "Ярина", new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc") },
                    { new Guid("fbcbb0a9-85e0-45a3-93c8-b1a057e4f062"), 0f, false, "[79,95]", new Guid("69f6d9a2-3a21-48f0-aa59-2bc982b367c3"), "Пильпака", "Альона", new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2") }
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Student_GroupId",
                table: "Student",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SpecialtyId",
                table: "Student",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_FacultyId",
                table: "Subject",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStudent_StudentId",
                table: "SubjectStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStudent_SubjectId",
                table: "SubjectStudent",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "SubjectStudent");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
