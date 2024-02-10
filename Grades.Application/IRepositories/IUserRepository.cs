using Grades.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Application.IRepositories
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
    }
}
