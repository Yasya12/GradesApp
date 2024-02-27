using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.GroupFeatures.Queries.GetAllGroupQuery
{
    public class GetAllGroupQueryHandler : IRequestHandler<GetAllGroupQuery, IEnumerable<Group>>
    {
        private readonly IGroupRepository _groupRepository;
        public GetAllGroupQueryHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<Group>> Handle(GetAllGroupQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _groupRepository.GetAllAsync(request.includeProperties);
        }
    }
}
