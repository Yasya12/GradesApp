using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.UserFeatures.Queries.GetUserQuery
{
    public record GetUserQuery(Guid id, string? includeProperties = null) : IRequest<ApplicationUser> { }
}
