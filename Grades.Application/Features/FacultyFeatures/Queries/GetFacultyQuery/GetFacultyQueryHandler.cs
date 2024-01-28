using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.FacultyFeatures.Queries.GetFacultyQuery
{
    public class GetFacultyQueryHandler : IRequestHandler<GetFacultyQuery, Faculty>
    {
        private readonly IFacultyRepository _facultyRepository;
        public GetFacultyQueryHandler(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<Faculty> Handle(GetFacultyQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _facultyRepository.GetAsync(request.id, request.includeProperties);
        }
    }
}
