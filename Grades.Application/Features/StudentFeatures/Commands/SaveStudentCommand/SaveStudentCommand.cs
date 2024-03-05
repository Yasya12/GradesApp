using MediatR;

namespace Grades.Application.Features.StudentFeatures.Commands.SaveStudentCommand
{
    public record SaveStudentCommand() : IRequest<Unit> { }
}
