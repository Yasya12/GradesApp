using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Queries.GetGroupQuery
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, Group>
    {
        private readonly IGroupRepository _groupRepository;
        public GetGroupQueryHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _groupRepository.GetAsync(request.id, request.includeProperties);
        }
    }
}
