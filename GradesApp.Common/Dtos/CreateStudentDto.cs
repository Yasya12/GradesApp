namespace GradesApp.Application.Dtos;

public class CreateStudentDto
{
    public string FullName { get; set; }
    public int Year { get; set; }
    public string Speciality { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}