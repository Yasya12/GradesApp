using GradesApp.Common.Dtos.User;
using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Services;

public interface IUserService
{
    Task<User> GetUserByCredentialsAsync(string userName, string password);
    Task<(CreateUserDto, Guid)> CreateUserAsync(CreateUserDto createUserDto);
}
