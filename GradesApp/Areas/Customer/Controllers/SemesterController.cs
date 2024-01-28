using Grades.Application.Features.SemesterFeatures.Queries;
using Grades.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace GradesApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SemesterController : BaseController
	{
        //тут помилка буде при запуску
		public SemesterController(Mediator mediator) : base(mediator){}

        public async Task<IActionResult> Index()
        {
            var semesterList = await _mediator.Send<IEnumerable<Semester>>(new GetAllSemesterQuery());

            ViewBag.SemesterList = new SelectList(semesterList, "Number", "GetSemesterInfo");

            return View(semesterList);
        }

    }
}
