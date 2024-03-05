using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.StudentFeatures.Queries.GetAllStudentQuery
{
    public record GetAllStudentQuery(string? includeProperties = null) : IRequest<IEnumerable<Student>> { }
}
