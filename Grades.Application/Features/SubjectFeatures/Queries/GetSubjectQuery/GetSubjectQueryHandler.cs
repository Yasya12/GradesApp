using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Queries.GetSubjectQuery
{
    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, Subject>
    {
        private readonly ISubjectRepository _subjectRepository;
        public GetSubjectQueryHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _subjectRepository.GetAsync(request.id, request.includeProperties);
        }
    }
}
