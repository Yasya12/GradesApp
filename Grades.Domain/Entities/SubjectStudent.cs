using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Grades.Domain.Entities
{
    public class SubjectStudent: BaseEntity
    {
        public Guid SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        [ValidateNever]
        [JsonIgnore]
        public Student Student { get; set; }

        public float Grade { get; set; }
    }
}
