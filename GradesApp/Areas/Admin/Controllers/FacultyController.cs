using Grades.Application.Features.FacultyFeatures.Commands.CreateFacultyCommand;
using Grades.Application.Features.FacultyFeatures.Commands.SaveFacultyCommand;
using Grades.Application.Features.FacultyFeatures.Commands.UpdateFacultyCommand;
using Grades.Application.Features.FacultyFeatures.Queries;
using Grades.Application.Features.FacultyFeatures.Queries.GetAllFacultyQuery;
using Grades.Application.Features.FacultyFeatures.Queries.GetFacultyQuery;
using Grades.Application.Features.UserFeatures.GetAllUserQuery;
using Grades.Domain.Entities;
using Grades.Domain.Entities.Utility;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            /*var allRoles = await _roleManager.Roles.ToListAsync();
            var facultyRoleId = allRoles.FirstOrDefault(r => r.Name == "Faculty")?.Id;

            if (facultyRoleId != null)
            {
                var facultyList = await _userManager.GetUsersInRoleAsync("Faculty");
                return View(facultyList);

            }
            else
            {
                return View(userList);
            }*/
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
