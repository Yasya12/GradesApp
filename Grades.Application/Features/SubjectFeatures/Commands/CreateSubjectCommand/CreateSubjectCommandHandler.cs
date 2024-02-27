using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.CreateSubjectCommand
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Subject>
    {
        private readonly ISubjectRepository _subjectRepository;
        public CreateSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            await _subjectRepository.CreateAsync(request.subject);
            return request.subject;
        }
    }
}
