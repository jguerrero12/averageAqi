using MassTransit;
using SharedInfrastructure;
using src;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceSetup(builder.Configuration);
builder.Services.AddApplicationSetup();
builder.Configuration
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
.AddEnvironmentVariables();
builder.Services.AddMassTransit(x =>
    {
        x.SetKebabCaseEndpointNameFormatter();
        x.AddConsumer<AverageAQICollectedConsumer>().Endpoint(e => e.Name = "process-average-aqi-request");
        x.AddRequestClient<AverageAQIRequestedConsumer>(new Uri("exchange:process-average-aqi-request"));
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("localhost", "/", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
            cfg.ConfigureEndpoints(context);
        });
    }
);
var app = builder.Build();
await app.Migrate();
await app.StartAsync();

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("get-average-aqi-request", e =>
        {
            e.Consumer<AverageAQIRequestedConsumer>(app.Services);
        }
    );
}
);
await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}
