using Grades.Application.IRepositories;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Commands.SaveGroupCommand
{
    public class SaveGroupCommandHandler : IRequestHandler<SaveGroupCommand, Unit>
    {
        private readonly IGroupRepository _groupRepository;
        public SaveGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Unit> Handle(SaveGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
