using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.CreateGroupCommand
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Group>
    {
        private readonly IGroupRepository _groupRepository;
        public CreateGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.CreateAsync(request.group);
            return request.group;
        }
    }
}
