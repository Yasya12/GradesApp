using AutoMapper;
using GradesApp.Application.Dtos;
using GradesApp.Common.Dtos.User;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : GenericController<User, CreateUserDto>
{
    public UserController(IGenericRepository<User> repository, IMapper mapper) : base(repository, mapper)
    {
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