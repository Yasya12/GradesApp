using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Queries.GetAllSpecialtyQuery
{
    public record GetAllSpecialtyQuery(string? includeProperties = null) : IRequest<IEnumerable<Specialty>> { }
}
