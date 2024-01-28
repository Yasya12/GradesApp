using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.FacultyFeatures.Commands.UpdateFacultyCommand
{
    public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand, Faculty>
    {
        private readonly IFacultyRepository _facultyRepository;
        public UpdateFacultyCommandHandler(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<Faculty> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
        {
            await _facultyRepository.UpdateAsync(request.faculty);
            return request.faculty;
        }
    }
}
