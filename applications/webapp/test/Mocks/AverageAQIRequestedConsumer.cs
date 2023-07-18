using MassTransit;
using SharedModels;

namespace Mocks
{
    public class AverageAQIRequestedConsumer : IConsumer<GetAverageAqiRequest>
    {
        public AverageAQIRequestedConsumer()
        {
        }
        public async Task Consume(ConsumeContext<GetAverageAqiRequest> context)
        {
            // Call out to API
            if (!(context.Message.Location?.Lat == 0 && context.Message.Location.Long == 0))
            {
                await context.RespondAsync(new GetAverageAqiResponse(){});
            }
            else
                throw new Exception("Could not get air pollution data status code: " + 500);
        }
    }
}