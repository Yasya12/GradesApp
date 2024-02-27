using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.UserFeatures.Commands.DeleteUserCommand
{
    public record DeleteUserCommand(ApplicationUser user) : IRequest<ApplicationUser> { }
}
