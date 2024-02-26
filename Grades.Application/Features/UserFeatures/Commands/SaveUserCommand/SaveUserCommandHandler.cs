using Grades.Application.IRepositories;
using MediatR;

namespace Grades.Application.Features.UserFeatures.Commands.SaveUserCommand
{
    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public SaveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
