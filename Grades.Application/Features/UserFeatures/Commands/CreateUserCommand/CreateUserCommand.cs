using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.UserFeatures.Commands.CreateUserCommand
{
    public record CreateUserCommand(ApplicationUser faculty) : IRequest<ApplicationUser> { }
}
