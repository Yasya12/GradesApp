using System.Linq.Expressions;
using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetUserBYEmailAsync(string userEmail);
}