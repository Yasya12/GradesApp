using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    
    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentRepository.GetAllAsync();
        return Ok(students);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound(); 
        }
        return Ok(student);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] Student student)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); 
        }

        await _studentRepository.AddAsync(student);
        
        return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] Student student)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingStudent = await _studentRepository.GetByIdAsync(id);
        if (existingStudent == null)
        {
            return NotFound();
        }

        existingStudent.FullName = student.FullName;
        existingStudent.Email = student.Email;
        existingStudent.Year = student.Year;
        existingStudent.Speciality = student.Speciality;

        await _studentRepository.UpdateAsync(existingStudent);
        return NoContent(); 
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        await _studentRepository.DeleteAsync(id);
        return NoContent(); 
    }
}