using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Domain.Entities.Utility;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext Context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(ApplicationUser entity)
        {
            entity.Email = entity.Name.ToLower() + "@gmail.com";
            entity.UserName = entity.Email;
            entity.NormalizedUserName = entity.Email.ToUpper();
            entity.NormalizedEmail = entity.NormalizedUserName;
            entity.EmailConfirmed = true;

            string password = $"{char.ToUpper(entity.Name[0])}{entity.Name.Substring(1).ToLower()}123!";
            entity.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, password);


            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            await _userManager.AddToRoleAsync(entity, SD.Role_Faculty);

            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  Create", currentUser);
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            var existingUser = await Context.Users.FindAsync(entity.Id);
            if (existingUser != null)
            {
                // Оновлюємо дані користувача
                existingUser.Name = entity.Name;
                existingUser.Abbreviation = entity.Abbreviation;
                // Оновлюємо пароль, якщо потрібно
                /*string password = $"{char.ToUpper(entity.Name[0])}{entity.Name.Substring(1).ToLower()}123!";
                existingUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, password);*/
                await Context.SaveChangesAsync();
            }
            else
            {
                // Обробка помилки: користувач не знайдений
            }

            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  Update", currentUser);
        }

        public async Task DeleteAsync(ApplicationUser entity)
        {
            Context.Remove(entity);
            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  Delete", currentUser);
        }

        public async Task<ApplicationUser> GetAsync(Guid id, string? includeProperties = null)
        {
            var query = Context.Set<ApplicationUser>().AsQueryable();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  Get", currentUser);

            return await query.FirstOrDefaultAsync(x => x.Id == id.ToString());     
        }

        public async Task<List<ApplicationUser>> GetAllAsync(string? includeProperties = null)
        {           
            IQueryable<ApplicationUser> query = Context.Set<ApplicationUser>();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  GetAll", currentUser);
            return await query.ToListAsync();
        }
        public async Task SaveAsync()
        {            
            await Context.SaveChangesAsync();
            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  Save", currentUser);
        }

        public async Task UpdateUserRoleAsync(ApplicationUser entity, string role)
        {            
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }

            if (role.Any())
            {
                await _userManager.AddToRolesAsync(user, new List<string> { role });
            }

            await Context.SaveChangesAsync();
            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  Update Role", currentUser);
        }

        public async Task<IEnumerable<string?>> GetRolesAsync()
        {
            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;
            Log.Information("{User} -  Get Roles", currentUser);
            return Context.Roles.Select(x => x.Name).ToList();
        }
    }
}
