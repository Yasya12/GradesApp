using Microsoft.Extensions.DependencyInjection;

namespace GradesApp.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddRepositories();
        services.AddAutoMapper();
        return services;
    }
    
}