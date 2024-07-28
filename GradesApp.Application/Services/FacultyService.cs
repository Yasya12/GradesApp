using AutoMapper;
using GradesApp.Common.Dtos.Faculty;
using GradesApp.Common.Exceptions;
using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Domain.Interfaces.Services;

namespace GradesApp.Application.Services;

public class FacultyService : IFacultyService
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly ISpecialityRepository _specialityRepository;
    private readonly IMapper _mapper;
    
    public FacultyService(IFacultyRepository facultyRepository, ISpecialityRepository specialityRepository, IMapper mapper)
    {
        _facultyRepository = facultyRepository;
        _specialityRepository = specialityRepository;
        _mapper = mapper;
    }
    public async Task<(ResponseFacultyDto, Guid)> CreateFacultyAsync(CreateFacultyDto dto)
    {
        var faculty = _mapper.Map<Faculty>(dto);

        if (dto.SpecialityIds != null && dto.SpecialityIds.Any())
        {
            var specialities = await _specialityRepository.GetByIdsAsync(dto.SpecialityIds);
        
            if (!specialities.Any())
            {
                throw new NotFoundException($"No specialities found with the provided ids: {string.Join(", ", dto.SpecialityIds)}");
            }

            faculty.Specialities = specialities.ToList();
        }
        else
        {
            faculty.Specialities = new List<Speciality>();
        }

        await _facultyRepository.AddAsync(faculty);

        var responseDto = _mapper.Map<ResponseFacultyDto>(faculty);

        return (responseDto, faculty.Id);
    }
    
    
    public async Task<Faculty> UpdateFacultyAsync(Guid id, CreateFacultyDto dto)
    {
        var existingFaculty = await _facultyRepository.GetByIdAsync(id);
        if (existingFaculty == null)
        {
            throw new NotFoundException($"Faculty with id {id} not found");
        }

        _mapper.Map(dto, existingFaculty);
        if (dto.SpecialityIds != null)
        {
            existingFaculty.Specialities = (await _specialityRepository.GetByIdsAsync(dto.SpecialityIds)).ToList();
        }
        else
        {
            existingFaculty.Specialities = new List<Speciality>();
        }

        await _facultyRepository.UpdateAsync(existingFaculty);
        return existingFaculty;
    }

}