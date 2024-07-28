using AutoMapper;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class GenericController<TEntity, TDto, TResponseDto> : ControllerBase
    where TEntity : class
    where TDto : class
{
    protected readonly IGenericRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    protected GenericController(IGenericRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    protected  TEntity ConvertToEntity(TDto dto)
    {
        return _mapper.Map<TEntity>(dto);
    }
    protected TDto ConvertToDto(TEntity entity)
    {
        return _mapper.Map<TDto>(entity);
    }
    
    protected TResponseDto ConvertToResponseDto(TEntity entity)
    {
        return _mapper.Map<TResponseDto>(entity);
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = entities.Select(ConvertToResponseDto);
        return Ok(dtos);
    }

    [HttpGet("{id:guid}")]
    public virtual async Task<IActionResult> GetById(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = ConvertToResponseDto(entity);
        return Ok(dto);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Add([FromBody] TDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var entity = ConvertToEntity(dto);

        await _repository.AddAsync(entity);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public virtual async Task<IActionResult> Update(Guid id, [FromBody] TDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingEntity = await _repository.GetByIdAsync(id);
        if (existingEntity == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, existingEntity);
        //var entity = ConvertToEntity(dto);
        await _repository.UpdateAsync(existingEntity);
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