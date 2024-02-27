using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;

namespace Grades.Persistence.Repositories
{
    internal class SpecialtyRepository : BaseRepository<Specialty>, ISpecialtyRepository
    {
        protected readonly ApplicationDbContext Context;

        public SpecialtyRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
