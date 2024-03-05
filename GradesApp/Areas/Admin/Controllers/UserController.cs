using Grades.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using Grades.Domain.Entities;
using Grades.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        protected readonly IMediator _mediator;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;


        public UserController(IMediator mediator, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _mediator = mediator;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;

        }
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _mediator.Send<IEnumerable<ApplicationUser>>(new GetAllUserQuery());
            ViewBag.UserManager = _userManager;
            ViewBag.RoleManager = _roleManager;
            return View(userList);
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges(Dictionary<string, string> userRoleChanges)
        {
            foreach (var kvp in userRoleChanges)
            {
                var userId = kvp.Key;
                var roleName = kvp.Value;

                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var roleExists = await _roleManager.RoleExistsAsync(roleName);
                    if (roleExists)
                    {
                        await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                        await _userManager.AddToRoleAsync(user, roleName);
                    }
                    else
                    {
                        // Обробка помилки, якщо роль не існує
                    }
                }
                else
                {
                    // Обробка помилки, якщо користувача не знайдено
                }
            }
            await _context.SaveChangesAsync();
            TempData["success"] = "Role update successfully";
            return RedirectToAction("GetAllUsers", "User");
        }
    }
}
