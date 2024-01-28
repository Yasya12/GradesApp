using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.FacultyFeatures.Commands.CreateFacultyCommand
{
    public class CreateFacultyCommandHandler : IRequestHandler<CreateFacultyCommand, Faculty>
    {
        private readonly IFacultyRepository _facultyRepository;
        public CreateFacultyCommandHandler(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<Faculty> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            await _facultyRepository.CreateAsync(request.faculty);
            return request.faculty;
        }
    }
}
