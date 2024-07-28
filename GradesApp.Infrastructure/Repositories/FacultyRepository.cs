using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Repositories;

public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(GradesAppDbContext context) : base(context) { }
    
    
    public override async Task<IEnumerable<Faculty>> GetAllAsync()
    {
        return await _context.Faculties
            .Include(f => f.Specialities)
            .ToListAsync();

    }
    
    public override async Task<Faculty> GetByIdAsync(Guid id)
    {
        var faculty = await _context.Faculties
            .Include(f => f.Specialities)
            .FirstOrDefaultAsync(s => s.Id == id);

        // Перевірка, чи спеціальності завантажуються
        if (faculty != null && faculty.Specialities != null)
        {
            Console.WriteLine($"Faculty: {faculty.Name}, Specialities Count: {faculty.Specialities.Count}");
            foreach (var speciality in faculty.Specialities)
            {
                Console.WriteLine($"Speciality: {speciality.Name}");
            }
        }

        return faculty;

    }
}