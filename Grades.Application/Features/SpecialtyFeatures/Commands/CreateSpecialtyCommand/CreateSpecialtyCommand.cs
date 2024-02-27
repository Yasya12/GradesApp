using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.CreateSpecialtyCommand
{
    public record CreateSpecialtyCommand(Specialty specialty) : IRequest<Specialty> { }
}
