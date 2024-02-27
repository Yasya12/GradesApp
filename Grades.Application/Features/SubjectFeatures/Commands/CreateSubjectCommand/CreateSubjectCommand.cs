using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.CreateSubjectCommand
{
    public record CreateSubjectCommand(Subject subject) : IRequest<Subject> { }
}
