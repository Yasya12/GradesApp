using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Domain.Entities
{
    public abstract class BaseFacultity: BaseEntity
    {
        public string? FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        [ValidateNever]
        public ApplicationUser Faculty { get; set; }
    }
}
