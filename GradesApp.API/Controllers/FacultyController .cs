using AutoMapper;
using GradesApp.Common.Dtos.Faculty;
using GradesApp.Common.Exceptions;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultyController : GenericController<Faculty, CreateFacultyDto, ResponseFacultyDto>
{
    private readonly IFacultyService _facultyService;
    private readonly IFacultyRepository _facultyRepository;
    
    public FacultyController(IGenericRepository<Faculty> repository, IMapper mapper, IFacultyRepository facultyRepository, IFacultyService facultyService) : base(repository, mapper)
    {
        _facultyService = facultyService;
        _facultyRepository = facultyRepository;
    }
    
    [HttpGet]
    public override async Task<IActionResult> GetAll()
    {
        var entities = await _facultyRepository.GetAllAsync(); // Виклик саме з IFacultyRepository
        var dtos = entities.Select(ConvertToResponseDto);
        return Ok(dtos);
    }
    
    [HttpGet("{id:guid}")]
    public override async Task<IActionResult> GetById(Guid id)
    {
        var entity = await _facultyRepository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = ConvertToResponseDto(entity);
        return Ok(dto);
    }
    
    
    [HttpPost]
    public override async Task<IActionResult> Add([FromBody] CreateFacultyDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var (createdFaculty, facultyId) = await _facultyService.CreateFacultyAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = facultyId }, createdFaculty);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            // Логування помилки
            return StatusCode(500, "An error occurred while creating the faculty");
        }
    }
    
    [HttpPut("{id:guid}")]
    public override async Task<IActionResult> Update(Guid id, [FromBody] CreateFacultyDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var updatedStudent = await _facultyService.UpdateFacultyAsync(id, dto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}