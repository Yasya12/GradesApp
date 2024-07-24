using System.ComponentModel.DataAnnotations.Schema;

namespace GradesApp.Domain.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FullName { get; set; } 
    public int Year { get; set; }
    public string Speciality { get; set; }
    
    [ForeignKey("User")]
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
}