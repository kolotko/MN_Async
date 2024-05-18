using AsynchronousTimeline;
using AsynchronousTimeline.Abstractions;
using AsynchronousTimeline.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = CreateHostBuilder(args).Build();
await builder.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices(serviceBuilder =>
        {

            serviceBuilder.AddHostedService<AsynchronousManager>();
            serviceBuilder.AddScoped<IApmService, ApmService>();
            serviceBuilder.AddScoped<IEapService, EapService>();
        });