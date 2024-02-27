using Grades.Application.Features.SubjectFeatures.Commands.CreateSubjectCommand;
using Grades.Application.Features.SubjectFeatures.Commands.DeleteSubjectCommand;
using Grades.Application.Features.SubjectFeatures.Commands.SaveSubjectCommand;
using Grades.Application.Features.SubjectFeatures.Commands.UpdateSubjectCommand;
using Grades.Application.Features.SubjectFeatures.Queries.GetAllSubjectQuery;
using Grades.Application.Features.SubjectFeatures.Queries.GetSubjectQuery;
using Grades.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.Areas.Faculty.Controllers
{
    [Area("Faculty")]
    public class SubjectController : Controller
    {
        protected readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public SubjectController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllSubject()
        {
            var subjectList = await _mediator.Send<IEnumerable<Subject>>(new GetAllSubjectQuery());
            return View(subjectList);
        }

        public async Task<IActionResult> Upsert(Guid id)
        {
            Subject subject = new Subject();

            if (id == null || id == Guid.Empty)
            {
                return View(subject);
            }
            else
            {
                subject = await _mediator.Send<Subject>(new GetSubjectQuery(id));
                return View(subject);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Subject subject)
        {
            var user = await _userManager.GetUserAsync(User);
            subject.FacultyId = user.Id;

            if (ModelState.IsValid)
            {
                if (subject.Id == Guid.Empty)
                {
                    await _mediator.Send<Subject>(new CreateSubjectCommand(subject));
                    TempData["success"] = "Faculty created successfully";
                }
                else
                {
                    await _mediator.Send<Subject>(new UpdateSubjectCommand(subject));
                    TempData["success"] = "Faculty update successfully";
                }

                await _mediator.Send(new SaveSubjectCommand());
                return RedirectToAction("GetAllSubject");
            }
            else
            {
                return View(subject);
            }
        }

        public async Task<IActionResult> DeleteSubject(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var subjectToBeDeleted = await _mediator.Send(new GetSubjectQuery(id.Value));

                if (subjectToBeDeleted == null)
                {
                    return NotFound();
                }

                await _mediator.Send(new DeleteSubjectCommand(subjectToBeDeleted));
                await _mediator.Send(new SaveSubjectCommand());

                return RedirectToAction("GetAllSubject");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

