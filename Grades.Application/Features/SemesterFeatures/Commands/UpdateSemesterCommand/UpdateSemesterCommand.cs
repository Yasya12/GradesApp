using Grades.Persistence.Repositories;
using MediatR;

namespace Grades.Application.Features.SemesterFeatures.Commands.UpdateSemesterCommand
{
    public record UpdateSemesterCommand(Semester semester) : IRequest<Semester> { }
}
