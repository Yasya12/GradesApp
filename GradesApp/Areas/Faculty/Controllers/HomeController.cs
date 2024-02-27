using Grades.Application.Features.SpecialtyFeatures.Commands.CreateSpecialtyCommand;
using Grades.Application.Features.SpecialtyFeatures.Commands.DeleteSpecialtyCommand;
using Grades.Application.Features.SpecialtyFeatures.Commands.SaveSpecialtyCommand;
using Grades.Application.Features.SpecialtyFeatures.Commands.UpdateSpecialtyCommand;
using Grades.Application.Features.SpecialtyFeatures.Queries.GetAllSpecialtyQuery;
using Grades.Application.Features.SpecialtyFeatures.Queries.GetSpecialtyQuery;
using Grades.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using Grades.Application.Features.UserFeatures.Commands.SaveUserCommand;
using Grades.Application.Features.UserFeatures.Queries.GetUserQuery;
using Grades.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GradesApp.Areas.Faculty.Controllers
{
    [Area("Faculty")]
    public class HomeController : Controller
    {
        protected readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllSpecialty()
        {
            var specialityList = await _mediator.Send<IEnumerable<Specialty>>(new GetAllSpecialtyQuery());
            return View(specialityList);
        }

        public async Task<IActionResult> Upsert(Guid id)
        {
            Specialty specialty = new Specialty();

            if (id == null || id == Guid.Empty)
            {
                return View(specialty);
            }
            else
            {
                specialty = await _mediator.Send<Specialty>(new GetSpecialtyQuery(id));
                return View(specialty);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Specialty specialty)
        {
            var user = await _userManager.GetUserAsync(User);
            specialty.FacultyId = user.Id;

            if (ModelState.IsValid)
            {
                if (specialty.Id == Guid.Empty)
                {                    
                    await _mediator.Send<Specialty>(new CreateSpecialtyCommand(specialty));
                    TempData["success"] = "Faculty created successfully";
                }
                else
                {
                    await _mediator.Send<Specialty>(new UpdateSpecialtyCommand(specialty));
                    TempData["success"] = "Faculty update successfully";
                }

                await _mediator.Send(new SaveSpecialtyCommand());
                return RedirectToAction("GetAllSpecialty");
            }
            else
            {
                return View(specialty);
            }
        }

        public async Task<IActionResult> DeleteSpecialty(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var specialtyToBeDeleted = await _mediator.Send(new GetSpecialtyQuery(id.Value));

                if (specialtyToBeDeleted == null)
                {
                    return NotFound();
                }

                await _mediator.Send(new DeleteSpecialtyCommand(specialtyToBeDeleted));
                await _mediator.Send(new SaveSpecialtyCommand());

                return RedirectToAction("GetAllSpecialty");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
