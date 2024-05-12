using System.Net;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using Xunit;

namespace TestApi;

public class ApiTests
{
    [Fact]
    public void sync_api_request_performance()
    {
        using var httpClient = new HttpClient();
        int copies = 50;
        int duration = 5;            
        var scenario = Scenario.Create("scenario", async context =>
            {
                try
                {
                    var request = Http.CreateRequest("GET", "http://localhost:5000/LongOperationSync");
                    return await Http.Send(httpClient, request);
                }
                catch (Exception e)
                {
                    return Response.Fail();
                }
            })
            .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            .WithLoadSimulations(
                Simulation.KeepConstant(copies: copies, during: TimeSpan.FromSeconds(duration))
            );
        
        NBomberRunner.RegisterScenarios(scenario).Run();
    }
    
    [Fact]
    public void async_api_request_performance()
    {
        using var httpClient = new HttpClient();
        int copies = 50;
        int duration = 5;            
        var scenario = Scenario.Create("scenario", async context =>
            {
                try
                {
                    var request = Http.CreateRequest("GET", "http://localhost:5000/LongOperationAsync");
                    return await Http.Send(httpClient, request);
                }
                catch (Exception e)
                {
                    return Response.Fail();
                }
            })
            .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            .WithLoadSimulations(
                Simulation.KeepConstant(copies: copies, during: TimeSpan.FromSeconds(duration))
            );
        
        NBomberRunner.RegisterScenarios(scenario).Run();
    }
}