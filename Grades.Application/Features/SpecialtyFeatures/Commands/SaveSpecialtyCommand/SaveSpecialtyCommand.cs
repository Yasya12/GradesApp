using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.SaveSpecialtyCommand
{
    public record SaveSpecialtyCommand() : IRequest<Unit> { }
}
