using Grades.Application.Features.UserFeatures.Commands.SaveUserCommand;
using Grades.Application.IRepositories;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.SaveSpecialtyCommand
{
    public class SaveSpecialtyCommandHandler : IRequestHandler<SaveSpecialtyCommand, Unit>
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SaveSpecialtyCommandHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<Unit> Handle(SaveSpecialtyCommand request, CancellationToken cancellationToken)
        {
            await _specialtyRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
