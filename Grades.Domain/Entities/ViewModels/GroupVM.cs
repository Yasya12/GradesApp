using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Grades.Domain.Entities.ViewModels
{
    public class GroupVM
    {
        public Group Group { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SpecialtyList { get; set; }
    }
    
}
