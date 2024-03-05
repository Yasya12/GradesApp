using Grades.Domain.Entities;
using Grades.Domain.Entities.Utility;
using Grades.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grades.Persistence.Context
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Semester> Semesters { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<SubjectStudent> SubjectStudent { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
           .HasDiscriminator<string>("Discriminator")
           .HasValue<ApplicationUser>("ApplicationUser");

            modelBuilder.Entity<Group>()
            .HasOne(g => g.Specialty)
            .WithMany()
            .HasForeignKey(g => g.SpecialtyId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id = Guid.NewGuid(), Name = "Faculty 1", Abbreviation = "F1" },
                new Faculty { Id = Guid.NewGuid(), Name = "Faculty 2", Abbreviation = "F2" }
            );

            modelBuilder.Entity<Semester>().HasData(
                new Semester(1, 2022) { Id = Guid.NewGuid() },
                new Semester(2, 2022) { Id = Guid.NewGuid() }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                  new ApplicationUser
                  {
                      Id = "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                      Name = "Admin",
                      Abbreviation = "A",
                      Email = "admin@gmail.com",
                      UserName = "admin@gmail.com",
                      NormalizedUserName = "ADMIN@GMAIL.COM",
                      NormalizedEmail = "ADMIN@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin123!")
                  },
                  new ApplicationUser
                  {
                      Id = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                      Name = "Economy Faculty",
                      Abbreviation = "EC",
                      Email = "economy@gmail.com",
                      UserName = "economy@gmail.com",
                      NormalizedUserName = "ECONOMY@GMAIL.COM",
                      NormalizedEmail = "ECONOMY@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Economy123!")
                  },
                  new ApplicationUser
                  {
                      Id = "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                      Name = "Law Faculty",
                      Abbreviation = "LF",
                      Email = "law@gmail.com",
                      UserName = "law@gmail.com",
                      NormalizedUserName = "LAW@GMAIL.COM",
                      NormalizedEmail = "LAW@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Law123!")
                  },
                  new ApplicationUser
                  {
                      Id = "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                      Name = "User",
                      Abbreviation = "U",
                      Email = "user@gmail.com",
                      UserName = "user@gmail.com",
                      NormalizedUserName = "USER@GMAIL.COM",
                      NormalizedEmail = "USER@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "User123!")
                  });

            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole
                 {
                     Id = "1",
                     Name = SD.Role_Admin,
                     NormalizedName = SD.Role_Admin.ToUpper(),
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 },
                 new IdentityRole
                 {
                     Id = "2",
                     Name = SD.Role_Faculty,
                     NormalizedName = SD.Role_Faculty.ToUpper(),
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 },
                 new IdentityRole
                 {
                     Id = "3",
                     Name = SD.Role_User,
                     NormalizedName = SD.Role_User.ToUpper(),
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                  new IdentityUserRole<string> { UserId = "49b754b0-8831-4b1a-a44f-8e18a0c2578e", RoleId = "1" },
                  new IdentityUserRole<string> { UserId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", RoleId = "2" },
                  new IdentityUserRole<string> { UserId = "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45", RoleId = "2" },
                  new IdentityUserRole<string> { UserId = "c8b05623-d42b-4a9f-947e-dcd54538ee1d", RoleId = "3" });

                modelBuilder.Entity<Specialty>().HasData(
                    new Specialty { Id = new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"), Name = "Комп'ютерні науки", Code = "122", FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" },
                    new Specialty { Id = new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2"), Name = "Економіка", Code = "051", FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" },
                    new Specialty { Id = new Guid("b6d2cb2f-8c5a-4ff4-98b2-728c3d0f2c8e"), Name = "Маркетинг", Code = "075", FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" }
                );

            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    Id = new Guid("2d78dc28-25c1-4e52-a08d-5a78a8f81c5d"),
                    GroupCode = "КН",
                    SubgroupNumber = 1,
                    AdmissionYear = 2021,
                    SpecialtyId = new Guid ("e0d30663-5fc2-4aa4-bd12-9f325db791dc"),
                    FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d"
                },
                new Group
                {
                    Id = new Guid("69f6d9a2-3a21-48f0-aa59-2bc982b367c3"),
                    GroupCode = "ЕК",
                    SubgroupNumber = 2,
                    AdmissionYear = 2020,
                    SpecialtyId = new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2") ,
                    FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d"
                },
                new Group
                {
                    Id = new Guid("4c09d510-2ef3-417a-b36a-41b82d39b159"),
                    GroupCode = "КН",
                    SubgroupNumber = 2,
                    AdmissionYear = 2022,
                    SpecialtyId = new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"),
                    FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d"
                }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = new Guid("a9e449e0-d8a1-4bfa-8dc5-3ec0d8b9a68d"), Name = "Програмування на С#", Abbreviation = "ПР", Lecturer = "Клебан Ю.В.", FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" },
                new Subject { Id = new Guid("7b96a6c2-8469-4d58-a3f0-bbb1aef4907c"), Name = "Бази Даних", Abbreviation = "БД", Lecturer = "Коцюк Ю.А.", FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" },
                new Subject { Id = new Guid("dc57160e-d37e-4d81-a048-245106c4854b"), Name = "Алгоритми даних", Abbreviation = "АД", Lecturer = "Жуковський В.В.", FacultyId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"),
                    Name = "Ярина",
                    LastName = "Лайтер",
                    SpecialtyId = new Guid("e0d30663-5fc2-4aa4-bd12-9f325db791dc"),
                    GroupId = new Guid("2d78dc28-25c1-4e52-a08d-5a78a8f81c5d"),
                    Grades = new List<float> { 89.00f, 100.00f }
                },
                new Student
                {
                    Id = new Guid("fbcbb0a9-85e0-45a3-93c8-b1a057e4f062"),
                    Name = "Альона",
                    LastName = "Пильпака",
                    SpecialtyId = new Guid("aee59fc8-92f4-4bb7-a0a7-4f812f74a4c2"),
                    GroupId = new Guid("69f6d9a2-3a21-48f0-aa59-2bc982b367c3"),
                    Grades = new List<float> { 79.00f, 95.00f }
                }
            );

            modelBuilder.Entity<SubjectStudent>().HasData(
                new SubjectStudent { Id = Guid.NewGuid(), SubjectId = new Guid("a9e449e0-d8a1-4bfa-8dc5-3ec0d8b9a68d"), StudentId = new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), Grade = 89.00f },
                new SubjectStudent { Id = Guid.NewGuid(), SubjectId = new Guid("7b96a6c2-8469-4d58-a3f0-bbb1aef4907c"), StudentId = new Guid("e25c7423-5a53-4c27-81d0-917b5e10b8e7"), Grade = 100.00f },
                new SubjectStudent { Id = Guid.NewGuid(), SubjectId = new Guid("dc57160e-d37e-4d81-a048-245106c4854b"), StudentId = new Guid("fbcbb0a9-85e0-45a3-93c8-b1a057e4f062"), Grade = 96.00f }
            );


        }
    }
}
