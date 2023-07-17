using SharedModels;
using FluentAssertions;
using webAppTests.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using MassTransit;
using MassTransit.Testing;
using System.Net.Http.Json;
using src;

namespace webAppTests;

public class GetAverageAQIControllerT
{
    public GetAverageAQIControllerT()
    {
    }

    [Fact]
    public async Task Should_Get_AverageAQIAsync()
    {
        await using var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => builder.ConfigureServices(services =>
            services.AddMassTransitTestHarness(x =>
            {
                x.AddConsumer<AverageAQIRequestedConsumer>().Endpoint(e => e.Name = "average-aqi-requested");
                x.AddRequestClient<GetAverageAQIController>(new Uri("exchange:average-aqi-requested"));
            })
            ));

        var testHarness = application.Services.GetTestHarness();

        using var client = application.CreateClient();


        const string submitOrderUrl = "/AverageAQI";

        var submitOrderResponse = await client.PostAsync(submitOrderUrl, JsonContent.Create(new GetAverageAqiRequest()
        {
            Location = new Location()
            {
                Long = 39.775379f, // indianapolis
                Lat = -86.161407f
            },
            DateRange = new DateRange(
                new DateTime(2020, 01, 01),
                new DateTime(2020, 12, 31)
            )
        }));

        submitOrderResponse.EnsureSuccessStatusCode();
        var orderStatus = await submitOrderResponse.Content.ReadFromJsonAsync<GetAverageAqiRequest>();

        orderStatus.Should().NotBeNull();

    }

}