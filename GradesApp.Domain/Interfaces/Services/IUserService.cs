using GradesApp.Common.Dtos.Authentication;
using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Services;

public interface IUserService
{
    Task<User> GetUserByCredentialsAsync(string userName, string password);
}
