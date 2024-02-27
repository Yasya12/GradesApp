using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.UpdateSubjectCommand
{
    public record UpdateSubjectCommand(Subject subject) : IRequest<Subject> { }
}
