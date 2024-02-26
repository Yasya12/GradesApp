using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.UserFeatures.Commands.UpdateUserCommand
{
    public record UpdateUserCommand(ApplicationUser faculty) : IRequest<ApplicationUser> { }
}
