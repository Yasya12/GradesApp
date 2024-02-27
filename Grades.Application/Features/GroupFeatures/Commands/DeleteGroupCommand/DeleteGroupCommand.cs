using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.DeleteGroupCommand
{
    public record DeleteGroupCommand(Group group) : IRequest<Group> { }
}
