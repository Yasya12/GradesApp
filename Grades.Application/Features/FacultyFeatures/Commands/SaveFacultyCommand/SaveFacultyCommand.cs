using MediatR;

namespace Grades.Application.Features.FacultyFeatures.Commands.SaveFacultyCommand
{
    public record SaveFacultyCommand() : IRequest<Unit> { }
}
