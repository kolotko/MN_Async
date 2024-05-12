using Api.Abstractions;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ILongOperationSimulation, LongOperationSimulation>();
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/LongOperationSync", (ILongOperationSimulation longOperationSimulation) =>
    {
        longOperationSimulation.LongTimeOperation1();
        longOperationSimulation.LongTimeOperation2();
        return 1;
    })
.WithName("LongOperationSync");

app.MapGet("/LongOperationAsync", async (ILongOperationSimulation longOperationSimulation) =>
    {
        await longOperationSimulation.LongTimeOperation1Async();
        await longOperationSimulation.LongTimeOperation2Async();
        return 1;
    })
    .WithName("LongOperationAsync");

app.Run();

