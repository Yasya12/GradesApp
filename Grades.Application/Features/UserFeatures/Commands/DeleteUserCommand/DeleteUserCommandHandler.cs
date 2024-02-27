using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.UserFeatures.Commands.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(request.user);
            return request.user;
        }
    }
}
