using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.DeleteSubjectCommand
{
    public record DeleteSubjectCommand(Subject subject) : IRequest<Subject> { }
}
