using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Infrastructure.Repositories;

public class SpecialityRepository: GenericRepository<Speciality>, ISpecialityRepository
{
    public SpecialityRepository(GradesAppDbContext context) : base(context) { }
}