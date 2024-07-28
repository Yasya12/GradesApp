using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GradesApp.Infrastructure.DependencyInjection;

public static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<ISpecialityRepository, SpecialityRepository>();
        return services;
    }
}