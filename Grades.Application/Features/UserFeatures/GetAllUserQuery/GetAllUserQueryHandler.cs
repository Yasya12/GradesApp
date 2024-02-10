using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.UserFeatures.GetAllUserQuery
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<ApplicationUser>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _userRepository.GetAllAsync(request.includeProperties);
        }
    }
}
