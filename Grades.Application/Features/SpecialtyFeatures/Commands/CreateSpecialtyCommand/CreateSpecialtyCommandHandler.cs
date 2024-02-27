using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.CreateSpecialtyCommand
{
    public class CreateSpecialtyCommandHandler : IRequestHandler<CreateSpecialtyCommand, Specialty>
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public CreateSpecialtyCommandHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<Specialty> Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
        {
            await _specialtyRepository.CreateAsync(request.specialty);
            return request.specialty;
        }
    }
}
