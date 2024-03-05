using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Grades.Domain.Entities
{
        public class Student: BaseEntity
        {
            public string Name { get; set; }
            public string LastName { get; set; }

            public ICollection<SubjectStudent> SubjectStudents { get; set; }
            public List<float> Grades { get; set; } // це видалити, бо воно не ті оцінки показує
            public float AverageGrade { get; set; }

            public Guid SpecialtyId { get; set; }

            [ForeignKey("SpecialtyId")]
            [ValidateNever]
            public Specialty Specialty { get; set; }
            public Guid GroupId { get; set; }

            [ForeignKey("GroupId")]
            [ValidateNever]
            public Group Group { get; set; }
        }
}
