using AireSpring.Application.Contracts;
using AireSpring.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AireSpring.Infrastructure;

/// <summary>
/// Static class that contains all the services registration for Infrastructure project
/// </summary>
public static class ServicesRegistration
{
    /// <summary>
    /// Add AireSpring Infrastructure services to DI container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }
}
