using System.Collections.Immutable;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Data.Common;
using System.Net.Http;
using MassTransit;

namespace webAppTests.Common;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {

            services.AddMassTransitTestHarness();


        });

        builder.UseEnvironment("Development");
    }
}