using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Infrastructure.Repositories;

public class GradeRepository: GenericRepository<Grade>, IGradeRepository
{
    public GradeRepository(GradesAppDbContext context) : base(context) { }
}