using Grades.Application.Features.FacultyFeatures.Commands.SaveFacultyCommand;
using Grades.Application.Features.FacultyFeatures.Commands.UpdateFacultyCommand;
using Grades.Application.Features.SemesterFeatures.Commands.SaveSemesterCommand;
using Grades.Application.Features.SemesterFeatures.Commands.UpdateSemesterCommand;
using Grades.Application.Features.SemesterFeatures.Queries;
using Grades.Domain.Entities;
using Grades.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SettingsController : Controller
    {
        protected readonly IMediator _mediator;

        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var semesterList = await _mediator.Send<IEnumerable<Semester>>(new GetAllSemesterQuery());

            return View(semesterList);
        }

        [HttpPost]
        public async Task<IActionResult> Set(int semester, int year)
        {
            var semesterList = await _mediator.Send<IEnumerable<Semester>>(new GetAllSemesterQuery());
            foreach (var item in semesterList)
            {
                item.DefaultValue = false;
            }

            var defaultSemester = semesterList.Where(i => semester == i.Number && year == i.StartYear).FirstOrDefault();
            defaultSemester.DefaultValue = true;

            await _mediator.Send<Semester>(new UpdateSemesterCommand(defaultSemester));
            await _mediator.Send(new SaveSemesterCommand());
            TempData["success"] = "Default semester was set";
            return RedirectToAction("Index");
        }
    }
}
