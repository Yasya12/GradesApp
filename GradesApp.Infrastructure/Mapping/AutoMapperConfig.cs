using AutoMapper;
using GradesApp.Application.Mappings;
using YourProject.Infrastructure.Mapping;

namespace GradesApp.Infrastructure.Mapping;

public class AutoMapperConfig
{
    public static MapperConfiguration Configure()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserMappingProfile>();
            cfg.AddProfile<StudentMapperProfile>();
        });
    }
}