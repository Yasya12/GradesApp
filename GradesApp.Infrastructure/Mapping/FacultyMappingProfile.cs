using AutoMapper;
using GradesApp.Common.Dtos.Faculty;
using GradesApp.Common.Dtos.Speciality;
using GradesApp.Domain.Entities;

namespace GradesApp.Infrastructure.Mapping;

public class FacultyMappingProfile : Profile
{
    public FacultyMappingProfile()
    {
        CreateMap<CreateFacultyDto, Faculty>()
            .ForMember(dest => dest.Specialities, opt => opt.Ignore());
        
        CreateMap<Faculty, CreateFacultyDto>();
        CreateMap<Faculty, ResponseFacultyDto>()
            .ForMember(dest => dest.Specialities, opt => opt.MapFrom(src => src.Specialities));
        
        CreateMap<Speciality, SpecialityDto>().ReverseMap();
    }
}