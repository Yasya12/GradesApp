namespace GradesApp.Application.Dtos;

public class UpdateStudentDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public int Year { get; set; }
    public string Speciality { get; set; }
    
    // user
    public string Username { get; set; }
    public string Email { get; set; }
    
    // password changing is a different operation
}