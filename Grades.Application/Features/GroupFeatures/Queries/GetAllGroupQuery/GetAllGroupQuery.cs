using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Queries.GetAllGroupQuery
{
    public record GetAllGroupQuery(string? includeProperties = null) : IRequest<IEnumerable<Group>> { }
}
