using GradesApp.Common.Dtos.Faculty;
using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Services;

public interface IFacultyService
{
    Task<(ResponseFacultyDto, Guid)> CreateFacultyAsync(CreateFacultyDto dto);
    Task<Faculty> UpdateFacultyAsync(Guid id, CreateFacultyDto dto);
}