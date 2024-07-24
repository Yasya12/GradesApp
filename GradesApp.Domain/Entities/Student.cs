namespace GradesApp.Domain.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FullName { get; set; } 
    public string Email { get; set; } 
    public int Year { get; set; }
    public string Speciality { get; set; }
}