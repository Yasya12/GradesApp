using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Queries.GetSubjectQuery
{
    public record GetSubjectQuery(Guid id, string? includeProperties = null) : IRequest<Subject> { }
}
