using Grades.Domain.Entities;
using MediatR;

namespace Grades.Application.Features.SpecialtyFeatures.Commands.DeleteSpecialtyCommand
{
    public record DeleteSpecialtyCommand(Specialty specialty) : IRequest<Specialty> { }
}
