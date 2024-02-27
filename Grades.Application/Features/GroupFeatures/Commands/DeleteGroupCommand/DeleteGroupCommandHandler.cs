using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.DeleteGroupCommand
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Group>
    {
        private readonly IGroupRepository _groupRepository;
        public DeleteGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.DeleteAsync(request.group);
            return request.group;
        }
    }
}
