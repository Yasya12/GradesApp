using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(GradesAppDbContext context) : base(context) { }
    
    public override async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(s => s.User)
            .Include(s => s.Group)
            .Include(s => s.Speciality)
            .Include(s => s.Grades)
            .ToListAsync();
        
    }
    
    public override async Task<Student> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Where(s => s.Id == id)
            .Include(s => s.User)
            .Include(s => s.Group)
            .Include(s => s.Speciality)
            .Include(s => s.Grades)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Student> GetByIdWithDetailsAsync(Guid id)
    {
        return await _context.Students
            .Include(s => s.User)
            .Include(s => s.Group)
            .Include(s => s.Speciality)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
    
}