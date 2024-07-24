using GradesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //LIMITATION FOR THE PROPERTY
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FullName).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
        });
        
        //creating data
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                Email = "john@example.com",
                Year = 2,
                Speciality = "Computer Science"
            },
            new Student
            {
                Id = Guid.NewGuid(),
                FullName = "Jane Smith",
                Email = "jane@example.com",
                Year = 3,
                Speciality = "Mathematics"
            }
        );
    }
}