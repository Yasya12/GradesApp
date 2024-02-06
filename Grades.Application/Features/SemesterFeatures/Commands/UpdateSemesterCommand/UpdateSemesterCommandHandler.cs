using Grades.Application.IRepositories;
using Grades.Persistence.Repositories;
using MediatR;

namespace Grades.Application.Features.SemesterFeatures.Commands.UpdateSemesterCommand
{
    public class UpdateSemesterCommandHandler : IRequestHandler<UpdateSemesterCommand, Semester>
    {
        private readonly ISemesterRepository _semesterRepository;
        public UpdateSemesterCommandHandler(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        public async Task<Semester> Handle(UpdateSemesterCommand request, CancellationToken cancellationToken)
        {
            await _semesterRepository.UpdateAsync(request.semester);
            return request.semester;
        }
    }
}
