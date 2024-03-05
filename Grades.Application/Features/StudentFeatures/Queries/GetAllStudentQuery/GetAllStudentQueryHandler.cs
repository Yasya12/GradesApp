using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.StudentFeatures.Queries.GetAllStudentQuery
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetAllStudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _studentRepository.GetAllAsync(request.includeProperties);
        }
    }
}
