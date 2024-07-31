using AutoMapper;
using GradesApp.Common.Dtos.Authentication;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;
using GradesApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace GradesApp.Application.Services;

using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByCredentialsAsync(string userName, string password)
    {
        var user = await _userRepository.GetByUserNameAsync(userName);
        if (user == null)
        {
            return null; 
        }

        var result =  PasswordHasher.VerifyPassword(password, user.PasswordHash);
        if (!result)
        {
            return null; 
        }

        return user;
    }
}
