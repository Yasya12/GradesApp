using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Infrastructure.Repositories;

public class SemesterRepository: GenericRepository<Semester>, ISemesterRepository
{
    public SemesterRepository(GradesAppDbContext context) : base(context) { }
}