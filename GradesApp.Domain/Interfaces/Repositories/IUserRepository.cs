using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByUserNameAsync(string userName);
}