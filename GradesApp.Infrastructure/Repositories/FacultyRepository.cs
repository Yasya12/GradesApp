using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Infrastructure.Repositories;

public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(GradesAppDbContext context) : base(context) { }
}