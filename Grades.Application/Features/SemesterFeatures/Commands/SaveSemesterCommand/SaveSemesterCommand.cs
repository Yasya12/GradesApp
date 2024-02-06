using MediatR;

namespace Grades.Application.Features.SemesterFeatures.Commands.SaveSemesterCommand
{
    public record SaveSemesterCommand() : IRequest<Unit> { }
}
