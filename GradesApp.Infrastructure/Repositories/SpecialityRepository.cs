using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Repositories;

public class SpecialityRepository: GenericRepository<Speciality>, ISpecialityRepository
{
    public SpecialityRepository(GradesAppDbContext context) : base(context) { }
    
    public async Task<IEnumerable<Speciality>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _context.Set<Speciality>()
            .Where(s => ids.Contains(s.Id))
            .ToListAsync();
        }
}