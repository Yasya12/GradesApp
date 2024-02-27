using MediatR;

namespace Grades.Application.Features.SubjectFeatures.Commands.SaveSubjectCommand
{
    public record SaveSubjectCommand() : IRequest<Unit> { }
}
