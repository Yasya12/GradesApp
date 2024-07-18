using GradesApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private List<Student> students = new List<Student>
    {
        new Student(Guid.NewGuid(), "First", "email@example.com", 3, "CS"),
        new Student(Guid.NewGuid(), "Second", "another@example.com", 4, "UF")
    };
    
    [HttpGet]
    public IEnumerable<Student> GetStudents()
    {
        return students;
    }
}