using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.FacultyFeatures.Queries.GetFacultyQuery
{
    public record GetFacultyQuery(Guid id, string? includeProperties = null) : IRequest<Faculty> { }
}
