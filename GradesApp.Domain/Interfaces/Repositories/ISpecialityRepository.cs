using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Repositories;

public interface ISpecialityRepository : IGenericRepository<Speciality>
{
    Task<IEnumerable<Speciality>> GetByIdsAsync(IEnumerable<Guid> ids);
}