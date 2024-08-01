using AutoMapper;
using GradesApp.Common.Dtos.User;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User> GetUserByCredentialsAsync(string userEmail, string password)
    {
        var user = await _userRepository.GetUserBYEmailAsync(userEmail);
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
    
    public async Task<(CreateUserDto, Guid)> CreateUserAsync(CreateUserDto createUserDto)
    {
        var existingUser = await _userRepository.GetUserBYEmailAsync(createUserDto.Email);
        if (existingUser != null)
        {
            throw new ApplicationException("User with such email already exist.");
        }

        var user = _mapper.Map<User>(createUserDto);
        await _userRepository.AddAsync(user);

        return (_mapper.Map<CreateUserDto>(user), user.Id);
    }
}
