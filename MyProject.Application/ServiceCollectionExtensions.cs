using Microsoft.Extensions.DependencyInjection;
using MyProject.Application.HomeChores;

namespace MyProject.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IHomeChoreService, HomeChoreService>();
    }
}
