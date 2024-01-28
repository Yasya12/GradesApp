using Grades.Application.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.FacultyFeatures.Commands.SaveFacultyCommand
{
    public class SaveFacultyCommandHandler : IRequestHandler<SaveFacultyCommand, Unit>
    {
        private readonly IFacultyRepository _facultyRepository;
        public SaveFacultyCommandHandler(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<Unit> Handle(SaveFacultyCommand request, CancellationToken cancellationToken)
        {
            await _facultyRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
