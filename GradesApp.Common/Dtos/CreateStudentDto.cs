namespace GradesApp.Application.Dtos;

public class CreateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string StudentNumber { get; set; }
    public Guid SpecialityId { get; set; }  
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
    public string Username => $"{FirstName.ToLower()}_{LastName.ToLower()}";
}