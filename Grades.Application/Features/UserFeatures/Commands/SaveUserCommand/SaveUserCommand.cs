using MediatR;

namespace Grades.Application.Features.UserFeatures.Commands.SaveUserCommand
{
    public record SaveUserCommand() : IRequest<Unit> { }
}
