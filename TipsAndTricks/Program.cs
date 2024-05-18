using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TipsAndTricks;
using TipsAndTricks.Abstractions;
using TipsAndTricks.Services;

var builder = CreateHostBuilder(args).Build();
await builder.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices(serviceBuilder =>
        {

            serviceBuilder.AddHostedService<AsynchronousManager>();
            serviceBuilder.AddScoped<IPriorityService, PriorityService>();
            serviceBuilder.AddScoped<IForegroundBackgroundService, ForegroundBackgroundService>();
            // serviceBuilder.AddScoped<IThreadSwitch, ThreadSwitch>();
            // serviceBuilder.AddSingleton<LongCalcSimulationService>();

        });