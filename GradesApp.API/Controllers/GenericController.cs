using GradesApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class GenericController<T> : ControllerBase where T : class
{
    protected readonly IGenericRepository<T> _repository;

    protected GenericController(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        var entities = await _repository.GetAllAsync();
        return Ok(entities);
    }

    [HttpGet("{id:guid}")]
    public virtual async Task<IActionResult> GetById(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Add([FromBody] T entity)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _repository.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = (entity as dynamic).Id }, entity);
    }

    [HttpPut("{id:guid}")]
    public virtual async Task<IActionResult> Update(Guid id, [FromBody] T entity)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingEntity = await _repository.GetByIdAsync(id);
        if (existingEntity == null)
        {
            return NotFound();
        }
        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}