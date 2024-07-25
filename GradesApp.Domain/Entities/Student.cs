using System.ComponentModel.DataAnnotations.Schema;

namespace GradesApp.Domain.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string StudentNumber { get; set; }
    
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    [ForeignKey("Group")]
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    
    [ForeignKey("Speciality")]
    public Guid SpecialityId { get; set; }
    public Speciality Speciality { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public List<Grade> Grades { get; set; }
}