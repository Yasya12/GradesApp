using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;

namespace Grades.Persistence.Repositories
{
    internal class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        protected readonly ApplicationDbContext Context;

        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
