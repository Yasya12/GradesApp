namespace GradesApp.Domain.Entities;

public class Speciality
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public List<Group> Groups { get; set; }
}