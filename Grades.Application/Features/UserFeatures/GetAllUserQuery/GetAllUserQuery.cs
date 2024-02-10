using Grades.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.Features.UserFeatures.GetAllUserQuery
{
    public record GetAllUserQuery(string? includeProperties = null) : IRequest<IEnumerable<ApplicationUser>> { }
}
