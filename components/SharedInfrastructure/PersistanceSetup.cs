using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SharedInfrastructure;

public static class PersistanceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(o =>
        {
            o.UseMySQL(Environment.GetEnvironmentVariable("JAWSDB_URL") ?? "server=localhost;database=aqi;user=root;password=password",
            b => b.MigrationsAssembly("datacollector")); //TODO Generalize this so that any project can use the context
        });
        return services;
    }
}