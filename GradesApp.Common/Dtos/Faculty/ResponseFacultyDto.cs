using GradesApp.Common.Dtos.Speciality;

namespace GradesApp.Common.Dtos.Faculty;

public class ResponseFacultyDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<SpecialityDto> Specialities { get; set; }
}