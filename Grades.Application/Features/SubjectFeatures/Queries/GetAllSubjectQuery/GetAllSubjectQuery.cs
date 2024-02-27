using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Queries.GetAllSubjectQuery
{
    public record GetAllSubjectQuery(string? includeProperties = null) : IRequest<IEnumerable<Subject>> { }
}
