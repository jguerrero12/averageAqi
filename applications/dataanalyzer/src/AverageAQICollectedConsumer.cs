using MassTransit;
using SharedModels;

namespace src
{
    public class AverageAQICollectedConsumer: IConsumer<ProcessAqiDataRequest>
    {
        public async Task Consume(ConsumeContext<ProcessAqiDataRequest> context){
            var averageAqi = (int?)context.Message.AQIDataPoints?.Average(p=>(int)p.main);
            await context.RespondAsync(new { averageAqi });
        }
    }
}