using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Queries.GetSpecialtyQuery
{
    public record GetSpecialtyQuery(Guid id, string? includeProperties = null) : IRequest<Specialty> { }
}
