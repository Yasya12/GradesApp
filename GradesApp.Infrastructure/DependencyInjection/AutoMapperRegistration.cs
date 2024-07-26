using System.Reflection;
using GradesApp.Infrastructure.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace GradesApp.Infrastructure.DependencyInjection;

public static class AutoMapperRegistration
{
    public  static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}