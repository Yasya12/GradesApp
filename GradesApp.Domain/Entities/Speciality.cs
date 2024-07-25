namespace GradesApp.Domain.Entities;

public class Speciality
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public List<Group> Groups { get; set; }
}