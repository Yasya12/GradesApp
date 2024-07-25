namespace GradesApp.Application.Dtos;

public class UpdateStudentDto
{
    public Guid Id { get; set; }  
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string StudentNumber { get; set; }
    public Guid SpecialityId { get; set; }  
    public Guid GroupId { get; set; }
    public DateTime EnrollmentDate { get; set; }
        
    // User properties
    public string Email { get; set; }
    public string Username => $"{FirstName.ToLower()}_{LastName.ToLower()}";
    
    // password changing is a different operation
}