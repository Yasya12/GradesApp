using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Queries.GetGroupQuery
{
    public record GetGroupQuery(Guid id, string? includeProperties = null) : IRequest<Group> { }
}
