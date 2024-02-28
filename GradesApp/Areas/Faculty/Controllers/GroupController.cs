using Grades.Application.Features.GroupFeatures.Commands.CreateGroupCommand;
using Grades.Application.Features.GroupFeatures.Commands.DeleteGroupCommand;
using Grades.Application.Features.GroupFeatures.Commands.SaveGroupCommand;
using Grades.Application.Features.GroupFeatures.Commands.UpdateGroupCommand;
using Grades.Application.Features.GroupFeatures.Queries.GetAllGroupQuery;
using Grades.Application.Features.GroupFeatures.Queries.GetGroupQuery;
using Grades.Application.Features.SpecialtyFeatures.Queries.GetAllSpecialtyQuery;
using Grades.Application.Features.SubjectFeatures.Commands.DeleteSubjectCommand;
using Grades.Application.Features.SubjectFeatures.Commands.SaveSubjectCommand;
using Grades.Application.Features.SubjectFeatures.Queries.GetAllSubjectQuery;
using Grades.Application.Features.SubjectFeatures.Queries.GetSubjectQuery;
using Grades.Domain.Entities;
using Grades.Domain.Entities.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GradesApp.Areas.Faculty.Controllers
{
    [Area("Faculty")]
    public class GroupController : Controller
    {
        protected readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllGroup()
        {
            var groupList = await _mediator.Send(new GetAllGroupQuery() { includeProperties = "Specialty" });
            return View(groupList);
        }

        public async Task<IActionResult> Upsert(Guid id)
        {
            GroupVM groupVM = new()
            {
                SpecialtyList = (await _mediator.Send<IEnumerable<Specialty >>(new GetAllSpecialtyQuery()))
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Group = new Group()
            };

            if (id == null || id == Guid.Empty)
            {
                return View(groupVM);
            }
            else
            {
                groupVM.Group = await _mediator.Send<Group>(new GetGroupQuery(id));
                return View(groupVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(GroupVM groupVM)
        {
            var user = await _userManager.GetUserAsync(User);
            groupVM.Group.FacultyId = user.Id;

            if (ModelState.IsValid)
            {
                if (groupVM.Group.Id == Guid.Empty)
                {
                    await _mediator.Send<Group>(new CreateGroupCommand(groupVM.Group));
                    TempData["success"] = "Group created successfully";
                }
                else
                {
                    await _mediator.Send<Group>(new UpdateGroupCommand(groupVM.Group));
                    TempData["success"] = "Group update successfully";
                }

                await _mediator.Send(new SaveGroupCommand());
                return RedirectToAction("GetAllGroup");
            }
            else
            {
                groupVM.SpecialtyList = (await _mediator.Send<IEnumerable<Specialty>>(new GetAllSpecialtyQuery()))
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(groupVM);
            }
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groupList = await _mediator.Send(new GetAllGroupQuery() { includeProperties = "Specialty" });
            return Json(new { data = groupList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var groupToBeDeleted = await _mediator.Send(new GetGroupQuery(id.Value));

                if (groupToBeDeleted == null)
                {
                    return NotFound();
                }

                await _mediator.Send(new DeleteGroupCommand(groupToBeDeleted));
                await _mediator.Send(new SaveGroupCommand());

                return Json(new { success = true, message = "Complaint and related files deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion
    }
}

