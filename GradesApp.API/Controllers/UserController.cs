using AutoMapper;
using GradesApp.Common.Dtos.User;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : GenericController<User, CreateUserDto, CreateUserDto >
{
    private readonly IUserService _userService;
    public UserController(IGenericRepository<User> repository, IMapper mapper, IUserService userService) : base(repository, mapper)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public override async Task<IActionResult> Add([FromBody] CreateUserDto createUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var (createdUser, userId) = await _userService.CreateUserAsync(createUserDto);
            return CreatedAtAction(nameof(GetById), new { id = userId }, createdUser);
        }
        catch (ApplicationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public override async Task<IActionResult> Update(Guid id, [FromBody] CreateUserDto updatedUserDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingUser = await _repository.GetByIdAsync(id);
        if (existingUser == null) return NotFound();

        _mapper.Map(updatedUserDto, existingUser);

        await _repository.UpdateAsync(existingUser);
        return NoContent();
    }
}