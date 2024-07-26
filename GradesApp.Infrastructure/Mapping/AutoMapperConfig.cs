using AutoMapper;
using YourProject.Infrastructure.Mapping;

namespace GradesApp.Infrastructure.Mapping;

public class AutoMapperConfig
{
    public static MapperConfiguration Configure()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserMappingProfile>();
        });
    }
}