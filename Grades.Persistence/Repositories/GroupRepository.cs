using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;

namespace Grades.Persistence.Repositories
{
    internal class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        protected readonly ApplicationDbContext Context;

        public GroupRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
