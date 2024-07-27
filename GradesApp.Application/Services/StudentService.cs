using AutoMapper;
using GradesApp.Application.Dtos;
using GradesApp.Common.Exceptions;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;

namespace GradesApp.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IUserRepository userRepository,  IMapper mapper)
    {
        _studentRepository = studentRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<StudentResponseDto>>(students);
    }
    
    public async Task<StudentResponseDto> GetStudentByIdAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
       return _mapper.Map<StudentResponseDto>(student);
    }


    public async Task<(StudentResponseDto, Guid)> CreateStudentAsync(CreateStudentDto dto)
    {
        var user = _mapper.Map<User>(dto);
        await _userRepository.AddAsync(user);
    
        var student = _mapper.Map<Student>(dto);
        student.UserId = user.Id;
        await _studentRepository.AddAsync(student);

        //for including properties group + speciality, doesn`t include without it
        student = await _studentRepository.GetByIdAsync(student.Id);

        var responseDto = _mapper.Map<StudentResponseDto>(student);
        return (responseDto, student.Id);
    }

    
    public async Task<Student> UpdateStudentAsync(Guid Id, UpdateStudentDto dto)
    {
        var student = await _studentRepository.GetByIdAsync(Id);
        if (student == null)
        {
            throw new NotFoundException($"Student with id {Id} not found");
        }
        
        _mapper.Map(dto, student);
        await _studentRepository.UpdateAsync(student);

        var user = await _userRepository.GetByIdAsync(student.UserId);
        if (user == null)
        {
            throw new NotFoundException($"User associated with student id {Id} not found");
        }
        
        _mapper.Map(dto, user);
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