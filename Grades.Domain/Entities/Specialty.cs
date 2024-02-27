using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Domain.Entities
{
    public class Specialty: BaseFacultity
    {
        public string Name { get; set; }
        public string Code { get; set; } 
    }
}
