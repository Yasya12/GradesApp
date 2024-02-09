using Grades.Application.Features.FacultyFeatures.Commands.CreateFacultyCommand;
using Grades.Application.Features.FacultyFeatures.Commands.SaveFacultyCommand;
using Grades.Application.Features.FacultyFeatures.Commands.UpdateFacultyCommand;
using Grades.Application.Features.FacultyFeatures.Queries;
using Grades.Application.Features.FacultyFeatures.Queries.GetAllFacultyQuery;
using Grades.Application.Features.FacultyFeatures.Queries.GetFacultyQuery;
using Grades.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                faculty = await _mediator.Send<Faculty>(new GetFacultyQuery(id.Value));
                return View(faculty);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                if (faculty.Id == Guid.Empty)
                {
                    await _mediator.Send<Faculty>(new CreateFacultyCommand(faculty));
                    TempData["success"] = "Faculty created successfully";
                }
                else
                {               
                    await _mediator.Send<Faculty>(new UpdateFacultyCommand(faculty));
                    TempData["success"] = "Faculty update successfully";
                }

                await _mediator.Send(new SaveFacultyCommand());
                return RedirectToAction("GetAllFaculties");
            }
            else
            {
                return View(faculty);
            }
        }
    }
}
