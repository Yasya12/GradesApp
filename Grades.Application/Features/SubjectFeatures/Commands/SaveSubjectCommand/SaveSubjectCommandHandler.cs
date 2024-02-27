using Grades.Application.IRepositories;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.SaveSubjectCommand
{
    public class SaveSubjectCommandHandler : IRequestHandler<SaveSubjectCommand, Unit>
    {
        private readonly ISubjectRepository _subjectRepository;
        public SaveSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Unit> Handle(SaveSubjectCommand request, CancellationToken cancellationToken)
        {
            await _subjectRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
