using Grades.Application.Features.SemesterFeatures.Queries;
using Grades.Application.Features.UserFeatures.Commands.CreateUserCommand;
using Grades.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using Grades.Application.Features.UserFeatures.Commands.SaveUserCommand;
using Grades.Application.Features.UserFeatures.Commands.UpdateUserCommand;
using Grades.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using Grades.Application.Features.UserFeatures.Queries.GetUserQuery;
using Grades.Domain.Entities;
using Grades.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacultyController : Controller
    {
        protected readonly IMediator _mediator;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public FacultyController(IMediator mediator, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllFaculties()
        {
            var userList = await _mediator.Send<IEnumerable<ApplicationUser>>(new GetAllUserQuery());
            return View(userList);
        }

        public async Task<IActionResult> Upsert(string? id)
        {
            ApplicationUser faculty = new ApplicationUser();

            if (string.IsNullOrEmpty(id))
            {
                //create
                faculty.Id = null;
                return View(faculty);
            }
            else
            {
                //update
                if (Guid.TryParse(id, out Guid idGuid))
                {
                    faculty = await _mediator.Send<ApplicationUser>(new GetUserQuery(idGuid));
                }
                else
                {
                    Console.WriteLine("Неможливо перетворити рядок на тип Guid.");
                }
                return View(faculty);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ApplicationUser? faculty)
        {
            var userList = await _mediator.Send<IEnumerable<ApplicationUser>>(new GetAllUserQuery());

            bool isUserExit = userList.Any(i => i.Id == faculty.Id);

            if (ModelState.IsValid)
            {
                if (!isUserExit)
                {
                    await _mediator.Send<ApplicationUser>(new CreateUserCommand(faculty));
                    TempData["success"] = "Faculty created successfully";
                }
                else
                {
                    await _mediator.Send<ApplicationUser>(new UpdateUserCommand(faculty));
                    TempData["success"] = "Faculty update successfully";
                }

                await _mediator.Send(new SaveUserCommand());
                return RedirectToAction("GetAllFaculties");
            }
            else
            {
                return View(faculty);
            }
        }

        public async Task<IActionResult> DeleteFaculty(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var userToBeDeleted = await _mediator.Send(new GetUserQuery(id.Value));

                if (userToBeDeleted == null)
                {
                    return NotFound();
                }

                await _mediator.Send(new DeleteUserCommand(userToBeDeleted));
                await _mediator.Send(new SaveUserCommand());

                return RedirectToAction("GetAllFaculties"); 
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
