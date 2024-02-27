using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.DeleteSubjectCommand
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, Subject>
    {
        private readonly ISubjectRepository _subjectRepository;
        public DeleteSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            await _subjectRepository.DeleteAsync(request.subject);
            return request.subject;
        }
    }
}
