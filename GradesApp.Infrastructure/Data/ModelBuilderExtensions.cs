using GradesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.Role).IsRequired();
        });

        // Student
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.StudentNumber).IsRequired();
            entity.Property(e => e.DateOfBirth).IsRequired();
            entity.Property(e => e.EnrollmentDate).IsRequired();

            entity.HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);
        });

        // Faculty
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            
            entity.HasMany(f => f.Specialities)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId);
        });

        // Semester
        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();

            entity.HasMany(s => s.Courses)
                .WithOne(c => c.Semester)
                .HasForeignKey(c => c.SemesterId);
        });

        // Speciality
        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Code).IsRequired();

            entity.HasMany(s => s.Groups)
                .WithOne(g => g.Speciality)
                .HasForeignKey(g => g.SpecialityId);
        });

        // Group
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Year).IsRequired();
        });

        // Course
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Code).IsRequired();
            entity.Property(e => e.Credits).IsRequired();

            entity.HasMany(c => c.Grades)
                .WithOne(g => g.Course)
                .HasForeignKey(g => g.CourseId);
        });

        // Grade
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Score).IsRequired();
            entity.Property(e => e.GradeDate).IsRequired();

            entity.HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);
        });

        // Seeds
        var user1Id = Guid.NewGuid();
        var user2Id = Guid.NewGuid();
        var facultyId = Guid.NewGuid();
        var speciality1Id = Guid.NewGuid();
        var speciality2Id = Guid.NewGuid();
        var group1Id = Guid.NewGuid();
        var group2Id = Guid.NewGuid();
        var student1Id = Guid.NewGuid();
        var student2Id = Guid.NewGuid();

        var user1 = new User
        {
            Id = user1Id,
            Username = "john_doe",
            Email = "john@example.com",
            PasswordHash = PasswordHasher.HashPassword("securepass456"), 
            Role = "Student"
        };

        var user2 = new User
        {
            Id = user2Id,
            Username = "jane_smith",
            Email = "jane@example.com",
            PasswordHash = PasswordHasher.HashPassword("password123"),
            Role = "Student"
        };

        modelBuilder.Entity<User>().HasData(user1, user2);

        var faculty = new Faculty { Id = facultyId, Name = "Faculty of Science" };
        modelBuilder.Entity<Faculty>().HasData(faculty);

        var speciality1 = new Speciality { Id = speciality1Id, Name = "Computer Science", Code = "CS", FacultyId = facultyId };
        var speciality2 = new Speciality { Id = speciality2Id, Name = "Mathematics", Code = "MATH", FacultyId = facultyId };
        modelBuilder.Entity<Speciality>().HasData(speciality1, speciality2);

        var group1 = new Group { Id = group1Id, Name = "CS-2", Year = 2, SpecialityId = speciality1Id };
        var group2 = new Group { Id = group2Id, Name = "MATH-3", Year = 3, SpecialityId = speciality2Id };
        modelBuilder.Entity<Group>().HasData(group1, group2);

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = student1Id,
                FirstName = "John",
                LastName = "Doe",
                StudentNumber = "CS001",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(2000, 1, 1), DateTimeKind.Utc),
                EnrollmentDate = DateTime.SpecifyKind(new DateTime(2022, 9, 1), DateTimeKind.Utc),
                SpecialityId = speciality1Id,
                GroupId = group1Id,
                UserId = user1Id
            },
            new Student
            {
                Id = student2Id,
                FirstName = "Jane",
                LastName = "Smith",
                StudentNumber = "MATH001",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1999, 5, 15), DateTimeKind.Utc),
                EnrollmentDate = DateTime.SpecifyKind(new DateTime(2021, 9, 1), DateTimeKind.Utc),
                SpecialityId = speciality2Id,
                GroupId = group2Id,
                UserId = user2Id
            }
        );
    }
}