using AutoMapper;
using GradesApp.Domain.Entities;
using GradesApp.Application.Dtos;
using GradesApp.Infrastructure.Data;

namespace GradesApp.Application.Mappings
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<Student, StudentResponseDto>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.Name))
                .ForMember(dest => dest.SpecialityName, opt => opt.MapFrom(src => src.Speciality.Name));

            CreateMap<CreateStudentDto, Student>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.Speciality, opt => opt.Ignore());
            
            CreateMap<CreateStudentDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.FirstName.ToLower()}_{src.LastName.ToLower()}"))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => PasswordHasher.HashPassword(src.Password)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "Student"));

            CreateMap<UpdateStudentDto, User>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => $"{src.FirstName.ToLower()}_{src.LastName.ToLower()}"));

        }
    }
}