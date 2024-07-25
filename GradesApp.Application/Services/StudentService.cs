using GradesApp.Application.Dtos;
using GradesApp.Common.Exceptions;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUserRepository _userRepository;

    public StudentService(IStudentRepository studentRepository, IUserRepository userRepository)
    {
        _studentRepository = studentRepository;
        _userRepository = userRepository;
    }

    public async Task<Student> CreateStudentAsync(CreateStudentDto dto)
    {
        var user = new User
        {
            Username = $"{dto.FirstName.ToLower()}_{dto.LastName.ToLower()}",
            Email = dto.Email,
            PasswordHash = PasswordHasher.HashPassword(dto.Password),
            Role = "Student"
        };

        await _userRepository.AddAsync(user);

        var student = new Student
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            StudentNumber = dto.StudentNumber,
            SpecialityId = dto.SpecialityId,
            EnrollmentDate = dto.EnrollmentDate,
            UserId = user.Id
        };

        await _studentRepository.AddAsync(student);
        return student;  
    }
    
    public async Task<Student> UpdateStudentAsync(UpdateStudentDto dto)
    {
        var student = await _studentRepository.GetByIdAsync(dto.Id);
        if (student == null)
        {
            throw new NotFoundException($"Student with id {dto.Id} not found");
        }

        student.FirstName = dto.FirstName;
        student.LastName = dto.LastName;
        student.DateOfBirth = dto.DateOfBirth;
        student.StudentNumber = dto.StudentNumber;
        student.SpecialityId = dto.SpecialityId;
        student.EnrollmentDate = dto.EnrollmentDate;

        await _studentRepository.UpdateAsync(student);

        var user = await _userRepository.GetByIdAsync(student.UserId);
        if (user == null)
        {
            throw new NotFoundException($"User associated with student id {dto.Id} not found");
        }

        user.Username = $"{dto.FirstName.ToLower()}_{dto.LastName.ToLower()}";
        user.Email = dto.Email;

        await _userRepository.UpdateAsync(user);

        return student;
    }
    
    public async Task DeleteStudentAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
        {
            throw new NotFoundException($"Student with id {id} not found");
        }

        await _studentRepository.DeleteAsync(id);

        await _userRepository.DeleteAsync(student.UserId);
    }
}