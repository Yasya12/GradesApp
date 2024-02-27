using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.UpdateSpecialtyCommand
{
    public record UpdateSpecialtyCommand(Specialty specialty) : IRequest<Specialty> { }
}
