namespace GradesApp.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid SpecialityId { get; set; }
    public Speciality Speciality { get; set; }
    public int Year { get; set; }
    public List<Student> Students { get; set; }
}