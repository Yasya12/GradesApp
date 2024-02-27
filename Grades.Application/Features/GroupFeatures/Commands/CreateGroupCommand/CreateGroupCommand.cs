using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.CreateGroupCommand
{
    public record CreateGroupCommand(Group group) : IRequest<Group> { }
}
