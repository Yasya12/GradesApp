using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Domain.Entities
{
    public class Subject: BaseFacultity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Lecturer { get; set; }
        public ICollection<SubjectStudent> SubjectStudents { get; set; }
    }
}
