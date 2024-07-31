using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(GradesAppDbContext context) : base(context) { }

    public async Task<User> GetByUserNameAsync(string userName)
    {
        return await _context.Users
            .SingleOrDefaultAsync(u => u.UserName == userName);
    }

}