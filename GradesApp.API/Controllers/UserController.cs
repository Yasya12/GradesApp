using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : GenericController<User>
{
    public UserController(IGenericRepository<User> repository) : base(repository)
    {
    }

    [HttpPut("{id:guid}")]
    public override async Task<IActionResult> Update(Guid id, [FromBody] User updatedUser)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingUser = await _repository.GetByIdAsync(id);
        if (existingUser == null) return NotFound();

        existingUser.Email = updatedUser.Email;
        existingUser.UserName = updatedUser.UserName;
        existingUser.Role = updatedUser.Role;

        await _repository.UpdateAsync(existingUser);
        return NoContent();
    }
}