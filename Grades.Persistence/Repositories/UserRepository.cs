using Grades.Application.IRepositories;
using Grades.Domain.Entities;
using Grades.Domain.Entities.Utility;
using Grades.Persistence.Context;
using Inspector.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            Context = context;
            _userManager = userManager;
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
        }

        public async Task DeleteAsync(ApplicationUser entity)
        {
            Context.Update(entity);
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
            return await query.ToListAsync();
        }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task UpdateUserRoleAsync(ApplicationUser entity, string role)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);
            //var user = await _userManager.FindByIdAsync(entity.Id);


            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }

            if (role.Any())
            {
                await _userManager.AddToRolesAsync(user, new List<string> { role });
            }

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string?>> GetRolesAsync()
        {
            return Context.Roles.Select(x => x.Name).ToList();
        }
    }
}
