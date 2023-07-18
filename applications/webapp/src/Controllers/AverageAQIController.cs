using Microsoft.AspNetCore.Mvc;
using MassTransit;
using SharedModels;

namespace webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class AverageAQIController : ControllerBase
{
    private readonly IRequestClient<GetAverageAqiRequest> _client;

    public AverageAQIController(IRequestClient<GetAverageAqiRequest> client)
    {
        _client = client;
    }

    [HttpPost]
    public async Task<AqiIndex?> GetAverageAQI(GetAverageAqiRequest data)
    {
        var response = await _client.GetResponse<GetAverageAqiResponse>(data);
        return response.Message.AverageAqi;
    }
}
