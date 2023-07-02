using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SharedInfrastructure;

public static class MigrationsSetup
{
    public static async Task Migrate(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IContext>();

        Console.WriteLine("Running migrations...");
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("Migrations applied succesfully");
    }
}