using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Queries.GetAllSubjectQuery
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQuery, IEnumerable<Subject>>
    {
        private readonly ISubjectRepository _subjectRepository;
        public GetAllSubjectQueryHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _subjectRepository.GetAllAsync(request.includeProperties);
        }
    }
}
