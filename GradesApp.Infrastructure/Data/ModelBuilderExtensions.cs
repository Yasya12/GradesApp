using GradesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //LIMITATION 
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FullName).IsRequired();
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired();
            entity.Property(e => e.Email).IsRequired();
        });
        
        // CONNECTION
        modelBuilder.Entity<Student>()
            .HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<Student>(s => s.UserId);
        
        //urer connect only with one student 
        modelBuilder.Entity<Student>()
            .HasIndex(s => s.UserId)
            .IsUnique();
        
        //CRWATING
        var user1 = new User
        {
            Id = Guid.NewGuid(),
            Username = "john_doe",
            Email = "john@example.com",
            PasswordHash = PasswordHasher.HashPassword("securepass456"), 
            Role = "Student"
        };

        var user2 = new User
        {
            Id = Guid.NewGuid(),
            Username = "jane_smith",
            Email = "jane@example.com",
            PasswordHash = PasswordHasher.HashPassword("password123"),
            Role = "Student"
        };

        modelBuilder.Entity<User>().HasData(user1, user2);
        
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                Year = 2,
                Speciality = "Computer Science",
                UserId = user1.Id
            },
            new Student
            {
                Id = Guid.NewGuid(),
                FullName = "Jane Smith",
                Year = 3,
                Speciality = "Mathematics",
                UserId = user2.Id
            }
        );
    }
}