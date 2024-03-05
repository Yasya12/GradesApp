using Grades.Application.Features.GroupFeatures.Commands.SaveGroupCommand;
using Grades.Application.Features.GroupFeatures.Queries.GetAllGroupQuery;
using Grades.Application.Features.StudentFeatures.Commands.SaveStudentCommand;
using Grades.Application.Features.StudentFeatures.Queries.GetAllStudentQuery;
using Grades.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using Grades.Application.Features.UserFeatures.Commands.SaveUserCommand;
using Grades.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using Grades.Application.Features.UserFeatures.Queries.GetUserQuery;
using Grades.Domain.Entities;
using Grades.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        protected readonly IMediator _mediator;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public StudentController(IMediator mediator, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllGroup()
        {
            var groupList = await _mediator.Send(new GetAllGroupQuery() { includeProperties = "Specialty" });
            return View(groupList);
        }
        public async Task<IActionResult> GetAllStudents(Guid Id)
        {
            var studentList = await _mediator.Send<IEnumerable<Student>>(new GetAllStudentQuery() { includeProperties = "SubjectStudents.Subject" });
            var list = studentList.Where(i => Id == i.GroupId).ToList();
            foreach (var student in studentList) 
            {
                CalculateAndSetAverageGrade(student);
            }
            await _mediator.Send(new SaveStudentCommand());
            return View(list);
        }

        public void CalculateAndSetAverageGrade(Student student)
        {
            if (student.SubjectStudents == null || !student.SubjectStudents.Any())
            {
                student.AverageGrade = 0; 
                return;
            }

            float totalGrade = 0;
            int numberOfGrades = 0;

            foreach (var subjectStudent in student.SubjectStudents)
            {
                totalGrade += subjectStudent.Grade;
                numberOfGrades++;
            }

            student.AverageGrade = numberOfGrades == 0 ? 0 : totalGrade / numberOfGrades;
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentList = await _mediator.Send<IEnumerable<Student>>(new GetAllStudentQuery() { includeProperties = "SubjectStudents" });
            return Json(new { data = studentList });
        }

        /*[HttpDelete]
        public async Task<IActionResult> Delete(Guid? id)
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

                return Json(new { success = true, message = "Faculty files deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }*/
        #endregion
    }
}
