using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly GradesAppDbContext _context;

    public UserRepository(GradesAppDbContext context) : base(context) 
    {
        _context = context;
    }

    public async Task<User> GetUserBYEmailAsync(string userEmail)
    {
        return await _context.Users
            .SingleOrDefaultAsync(u => u.Email == userEmail);
    }
}