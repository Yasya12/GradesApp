using Grades.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.SpecialtyFeatures.Queries.GetAllSpecialtyQuery
{
    public class GetAllSpecialtyQueryHandler : IRequestHandler<GetAllSpecialtyQuery, IEnumerable<Specialty>>
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public GetAllSpecialtyQueryHandler(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<IEnumerable<Specialty>> Handle(GetAllSpecialtyQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _specialtyRepository.GetAllAsync(request.includeProperties);
        }
    }
}
