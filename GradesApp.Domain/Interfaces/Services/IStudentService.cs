using GradesApp.Application.Dtos;
using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Services;

public interface IStudentService
{
    Task<Student> CreateStudentAsync(CreateStudentDto dto);
    Task<Student> UpdateStudentAsync(UpdateStudentDto dto);
    Task DeleteStudentAsync(Guid id);

}