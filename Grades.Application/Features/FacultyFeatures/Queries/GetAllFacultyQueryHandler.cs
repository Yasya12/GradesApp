using Grades.Application.Features.SemesterFeatures.Queries;
using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.FacultyFeatures.Queries
{
    public class GetAllFacultyQueryHandler : IRequestHandler<GetAllFacultyQuery, IEnumerable<Faculty>>
    {
        private readonly IFacultyRepository _facultyRepository;
        public GetAllFacultyQueryHandler(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<Faculty>> Handle(GetAllFacultyQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _facultyRepository.GetAllAsync(request.includeProperties);
        }
    }
}
