using Grades.Domain.Entities;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;
using Grades.Application.IRepositories;

namespace Grades.Persistence.Repositories
{
	public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
	{
		protected readonly ApplicationDbContext Context;

		public FacultyRepository(ApplicationDbContext context) : base(context)
		{
			Context = context;
		}
	}
}
