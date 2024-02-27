using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Queries.GetSpecialtyQuery
{
    public class GetSpecialtyQueryHandler : IRequestHandler<GetSpecialtyQuery, Specialty>
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public GetSpecialtyQueryHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<Specialty> Handle(GetSpecialtyQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _specialtyRepository.GetAsync(request.id, request.includeProperties);
        }
    }
}
