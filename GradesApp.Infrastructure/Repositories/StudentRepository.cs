using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(GradesAppDbContext context) : base(context) { }

    private IQueryable<Student> IncludeNavigationProperties(IQueryable<Student> query)
    {
        return query
            .Include(s => s.User)
            .Include(s => s.Group)
            .Include(s => s.Speciality)
            .Include(s => s.Grades);
    }
    
    public override async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await IncludeNavigationProperties(_context.Students)
            .ToListAsync();
    }
    
    public override async Task<Student> GetByIdAsync(Guid id)
    {
        var student = await IncludeNavigationProperties(_dbSet)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {id} not found.");
        }
    
        return student;
    }
}