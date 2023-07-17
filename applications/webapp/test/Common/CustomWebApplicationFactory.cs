using System.Collections.Immutable;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Data.Common;
using System.Net.Http;
using MassTransit;
using SharedModels;
using Mocks;

namespace webAppTests.Common;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddMassTransitTestHarness(
                x =>
            {
                x.AddConsumer<AverageAQIRequestedConsumer>().Endpoint(e => e.Name = "average-aqi-requested");
                x.AddRequestClient<GetAverageAQIController>(new Uri("exchange:average-aqi-requested"));
            }
            );
        });

        builder.UseEnvironment("Development");
    }
}