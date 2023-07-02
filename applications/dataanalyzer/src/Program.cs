using MassTransit;
using src;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    cfg.ReceiveEndpoint("process-average-aqi-request", e =>
        {
            e.Consumer<AverageAQICollectedConsumer>();
        }
    )
);
await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(()=>Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}
