using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Infrastructure.Repositories;

public class CourseRepository: GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(GradesAppDbContext context) : base(context) { }
}