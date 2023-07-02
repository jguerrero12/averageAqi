using Microsoft.Extensions.DependencyInjection;

namespace SharedInfrastructure;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
    {
        services.AddScoped<IContext, ApplicationDbContext>();

        return services;
    }
}