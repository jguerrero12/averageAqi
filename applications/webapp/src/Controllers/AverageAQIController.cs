using Microsoft.AspNetCore.Mvc;
using MassTransit;
using SharedModels;

namespace webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class AverageAQIController : ControllerBase
{
    private readonly ILogger<AverageAQIController> _logger;
    private readonly IRequestClient<GetAverageAqiRequest> _client;

    public AverageAQIController(ILogger<AverageAQIController> logger, IRequestClient<GetAverageAqiRequest> client)
    {
        _logger = logger;
        _client = client;
    }

    [HttpGet]
    public async Task<AqiIndex?> GetAverageAQI(GetAverageAqiRequest data)
    {
        var response = await _client.GetResponse<GetAverageAqiResponse>(data);
        return response.Message.AverageAqi;
    }
}
