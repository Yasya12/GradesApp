using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Persistence.Repositories
{

    internal class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        protected readonly ApplicationDbContext Context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
