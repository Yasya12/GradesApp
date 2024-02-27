using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.UpdateGroupCommand
{
    public record UpdateGroupCommand(Group group) : IRequest<Group> { }
}
