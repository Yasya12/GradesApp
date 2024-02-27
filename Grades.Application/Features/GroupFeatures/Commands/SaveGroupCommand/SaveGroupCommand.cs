using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.SaveGroupCommand
{
    public record SaveGroupCommand() : IRequest<Unit> { }
}
