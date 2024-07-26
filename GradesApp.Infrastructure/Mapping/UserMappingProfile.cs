using AutoMapper;
using GradesApp.Application.Dtos;
using GradesApp.Common.Dtos.User;
using GradesApp.Domain.Entities;
using GradesApp.Infrastructure.Data;

namespace YourProject.Infrastructure.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => PasswordHasher.HashPassword(src.Password)))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastLogin, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}