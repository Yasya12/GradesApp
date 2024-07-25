namespace GradesApp.Domain.Entities;

public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int Credits { get; set; }
    public Guid SemesterId { get; set; }
    public Semester Semester { get; set; }
    public List<Grade> Grades { get; set; }
}