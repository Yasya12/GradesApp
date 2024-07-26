using GradesApp.Application.Dtos;
using GradesApp.Common.Exceptions;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentService _studentService;

    public StudentsController(IStudentRepository repository, IStudentService studentService)
    {
        _studentRepository = repository;
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return Ok(student);
        // var student = await _studentRepository.GetByIdAsync(id);
        // if (student == null) return NotFound();
        // return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
    
        var (createdStudent, studentId) = await _studentService.CreateStudentAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = studentId }, createdStudent);
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStudentDto dto)
    {
        if (id != dto.Id) return BadRequest("Id mismatch");
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(dto);
            return Ok(updatedStudent);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
    }
}