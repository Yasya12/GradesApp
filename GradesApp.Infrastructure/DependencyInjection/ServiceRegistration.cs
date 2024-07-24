using GradesApp.Application.Services;
using GradesApp.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GradesApp.Infrastructure.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
}