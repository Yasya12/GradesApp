using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.FacultyFeatures.Queries.GetAllFacultyQuery
{
    public record GetAllFacultyQuery(string? includeProperties = null) : IRequest<IEnumerable<Faculty>> { }
}
