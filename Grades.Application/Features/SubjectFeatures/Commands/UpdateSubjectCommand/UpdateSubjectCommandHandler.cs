using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.UpdateSubjectCommand
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, Subject>
    {
        private readonly ISubjectRepository _subjectRepository;
        public UpdateSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            await _subjectRepository.UpdateAsync(request.subject);
            return request.subject;
        }
    }
}
