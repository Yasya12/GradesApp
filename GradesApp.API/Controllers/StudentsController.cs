using GradesApp.Application.Dtos;
using GradesApp.Application.Identity;
using GradesApp.Common.Exceptions;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController( IStudentService studentService)
    {
        _studentService = studentService;
    }

    [Authorize]
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
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            var (createdStudent, studentId) = await _studentService.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = studentId }, createdStudent);
        }
        catch (ApplicationException ex)
        {
            return Conflict(ex.Message);
        }
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStudentDto dto)
    {
        //if (id != dto.Id) return BadRequest("Id mismatch");
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, dto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var adminClaim = User.FindFirst(IdentityData.AdminUserClaimName);
        if (adminClaim == null || adminClaim.Value != "true")
        {
            return Forbid(); 
        }

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