using Grades.Application.Features.FacultyFeatures.Queries;
using Grades.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GradesApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class FacultyController : Controller
    {
        protected readonly IMediator _mediator;

        public FacultyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetAllFaculties()
        {
            var facultyList = await _mediator.Send<IEnumerable<Faculty>>(new GetAllFacultyQuery());

            return View(facultyList);
        }

        public async Task<IActionResult> Upsert(Guid? id)
        {
            Faculty faculty = new Faculty();

            if (id == null || id == Guid.Empty)
            {
                //create
                return View(faculty);
            }
            else
            {
                //update
                /*complaintVM.Complaint = await _mediator.Send<Complaint>(new GetComplaintQuery(id.Value, "ComplaintFiles"));
                return View(complaintVM);*/
                return View(faculty);
            }
        }
    }
}
