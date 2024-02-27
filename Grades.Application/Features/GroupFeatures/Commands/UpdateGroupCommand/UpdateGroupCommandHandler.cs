using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.UpdateGroupCommand
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Group>
    {
        private readonly IGroupRepository _groupRepository;
        public UpdateGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.UpdateAsync(request.group);
            return request.group;
        }
    }
}
