using Grades.Application.IRepositories;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;

namespace Grades.Persistence.Repositories
{
	internal class SemesterRepository : BaseRepository<Semester>, ISemesterRepository
	{
		protected readonly ApplicationDbContext Context;

		public SemesterRepository(ApplicationDbContext context) : base(context)
		{
			Context = context;
		}
	}
}
