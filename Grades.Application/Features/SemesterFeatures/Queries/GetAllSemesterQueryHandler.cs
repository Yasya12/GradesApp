using Grades.Application.IRepositories;
using Grades.Persistence.Repositories;
using MediatR;

namespace Grades.Application.Features.SemesterFeatures.Queries
{
	public class GetAllSemesterQueryHandler : IRequestHandler<GetAllSemesterQuery, IEnumerable<Semester>>
	{
		private readonly ISemesterRepository _semesterRepository;
		public GetAllSemesterQueryHandler(ISemesterRepository semesterRepository)
		{
			_semesterRepository = semesterRepository;
		}

		public async Task<IEnumerable<Semester>> Handle(GetAllSemesterQuery request, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
			return await _semesterRepository.GetAllAsync(request.includeProperties);
		}
	}

}
