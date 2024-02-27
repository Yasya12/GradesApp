using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.UpdateSpecialtyCommand
{
    public class UpdateSpecialtyCommandHandler : IRequestHandler<UpdateSpecialtyCommand, Specialty>
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public UpdateSpecialtyCommandHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<Specialty> Handle(UpdateSpecialtyCommand request, CancellationToken cancellationToken)
        {
            await _specialtyRepository.UpdateAsync(request.specialty);
            return request.specialty;
        }
    }
}
