using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : GenericController<Student>
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository repository) : base(repository)
    {
        _studentRepository = repository;
    }

    [HttpPut("{id:guid}")]
    public override async Task<IActionResult> Update(Guid id, [FromBody] Student student)
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
        existingStudent.Year = student.Year;
        existingStudent.Speciality = student.Speciality;

        await _studentRepository.UpdateAsync(existingStudent);
        return NoContent();
    }
}