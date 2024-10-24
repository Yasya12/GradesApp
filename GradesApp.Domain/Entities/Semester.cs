namespace GradesApp.Domain.Entities;

public class Semester
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Course> Courses { get; set; }
}