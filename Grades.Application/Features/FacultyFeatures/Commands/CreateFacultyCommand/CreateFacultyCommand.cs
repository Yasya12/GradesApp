using Grades.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.FacultyFeatures.Commands.CreateFacultyCommand
{
    public record CreateFacultyCommand(Faculty faculty) : IRequest<Faculty> { }
}
