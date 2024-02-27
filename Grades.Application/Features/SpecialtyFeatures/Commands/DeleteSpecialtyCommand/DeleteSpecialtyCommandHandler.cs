using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.DeleteSpecialtyCommand
{
    public class DeleteSpecialtyCommandHandler : IRequestHandler<DeleteSpecialtyCommand, Specialty>
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public DeleteSpecialtyCommandHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<Specialty> Handle(DeleteSpecialtyCommand request, CancellationToken cancellationToken)
        {
            await _specialtyRepository.DeleteAsync(request.specialty);
            return request.specialty;
        }
    }
}
