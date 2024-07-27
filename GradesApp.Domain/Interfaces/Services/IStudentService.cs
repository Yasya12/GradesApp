using GradesApp.Application.Dtos;
using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Services;

public interface IStudentService
{
    Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync();
    Task<StudentResponseDto> GetStudentByIdAsync(Guid id);
    Task<(StudentResponseDto, Guid)>  CreateStudentAsync(CreateStudentDto dto);
    Task<Student> UpdateStudentAsync(Guid id, UpdateStudentDto dto);
    Task DeleteStudentAsync(Guid id);

}