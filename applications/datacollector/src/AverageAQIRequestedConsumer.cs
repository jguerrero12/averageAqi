using MassTransit;
using SharedInfrastructure;
using SharedModels;
using src.Models;

namespace src
{
    public class AverageAQIRequestedConsumer : IConsumer<GetAverageAqiRequest>
    {
        private readonly HttpClient client;
        private readonly string apiKey;
        private readonly IContext _context;
        private readonly IRequestClient<ProcessAqiDataRequest> _reqClient;
        private string GetAirPollutionApiUri(GetAverageAqiRequest data) =>
            $"http://api.openweathermap.org/data/2.5/air_pollution/history?lat={data.Location?.Lat}&lon={data.Location?.Long}&start={data.DateRange?.Start}&end={data.DateRange?.End}&appid={apiKey}";
        public AverageAQIRequestedConsumer(IServiceProvider serviceProvider, IRequestClient<ProcessAqiDataRequest> reqClient)
        {
            client = new();
            _context = serviceProvider.GetRequiredService<IContext>();
            _reqClient = reqClient;
            apiKey = Environment.GetEnvironmentVariable("OpenWeatherAPIKey") ?? serviceProvider.GetRequiredService<IConfiguration>().GetValue<string>("OpenWeather:apiKey") ??
            throw new Exception("OpenWeatherAPIKey not found");
        }
        public async Task Consume(ConsumeContext<GetAverageAqiRequest> context)
        {
            // Call out to API
            HttpResponseMessage response = await client.GetAsync(GetAirPollutionApiUri(context.Message));
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<AirPollutionApiResponse>();
                // Save result to db
                if (res!.list != null)
                {
                    _context.AQIDataPoints.AddRange(res.list);
                    await _context.SaveChangesAsync();
                }
                var reqRes = await _reqClient.GetResponse<ProcessAqiDataResponse>(new { res.list });
                await context.RespondAsync(reqRes);
            }
            else
                throw new Exception("Could not get air pollution data status code: " + response.StatusCode);
        }
    }
}