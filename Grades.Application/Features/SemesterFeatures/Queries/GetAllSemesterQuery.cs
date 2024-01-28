using Grades.Persistence.Repositories;
using MediatR;

namespace Grades.Application.Features.SemesterFeatures.Queries
{
	public record GetAllSemesterQuery(string? includeProperties = null) : IRequest<IEnumerable<Semester>> { }
}
