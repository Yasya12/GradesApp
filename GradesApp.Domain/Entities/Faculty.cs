namespace GradesApp.Domain.Entities;

public class Faculty
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Speciality> Specialities { get; set; }
}