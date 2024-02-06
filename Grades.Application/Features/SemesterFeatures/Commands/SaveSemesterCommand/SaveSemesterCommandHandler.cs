using Grades.Application.IRepositories;
using MediatR;

namespace Grades.Application.Features.SemesterFeatures.Commands.SaveSemesterCommand
{
    public class SaveSemesterCommandHandler : IRequestHandler<SaveSemesterCommand, Unit>
    {
        private readonly ISemesterRepository _semesterRepository;
        public SaveSemesterCommandHandler(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }
        public async Task<Unit> Handle(SaveSemesterCommand request, CancellationToken cancellationToken)
        {
            await _semesterRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
