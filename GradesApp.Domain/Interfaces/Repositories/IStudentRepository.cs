using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Repositories;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<Student> GetByIdWithDetailsAsync(Guid id);
}