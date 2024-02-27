using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Domain.Entities
{
    public class Group: BaseFacultity
    {
        public string GroupCode { get; set; } 
        public int SubgroupNumber { get; set; } 
        public int AdmissionYear { get; set; }
        public Guid SpecialtyId { get; set; }

        [ForeignKey("SpecialtyId")]
        [ValidateNever]
        public Specialty Specialty { get; set; }

        public string GroupName
        {
            get
            {
                // Отримуємо назву спеціальності та скорочений рік вступу
                string specialtyName = Specialty?.Name ?? "Unknown";
                string admissionYearString = AdmissionYear.ToString().Substring(Math.Max(0, AdmissionYear.ToString().Length - 2));

                // Повертаємо назву групи у форматі "КодСпеціальності-СкороченийРікВступу-НомерПідгрупи"
                return $"{specialtyName}-{admissionYearString}-{SubgroupNumber}";
            }
        }
    }
}
