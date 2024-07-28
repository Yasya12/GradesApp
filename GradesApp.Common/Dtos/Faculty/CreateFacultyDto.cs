namespace GradesApp.Common.Dtos.Faculty;

public class CreateFacultyDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Guid>? SpecialityIds { get; set; }
}