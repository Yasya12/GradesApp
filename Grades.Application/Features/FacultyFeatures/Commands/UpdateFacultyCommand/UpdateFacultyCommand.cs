using Grades.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.FacultyFeatures.Commands.UpdateFacultyCommand
{
    public record UpdateFacultyCommand(Faculty faculty) : IRequest<Faculty> { }
}
