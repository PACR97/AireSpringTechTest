using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AireSpring.Application;

/// <summary>
/// Static class that contains all the services registration for Application project
/// </summary>
public static class ApplicationServicesRegistration
{
    /// <summary>
    /// Add AireSpring Application services to DI container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
