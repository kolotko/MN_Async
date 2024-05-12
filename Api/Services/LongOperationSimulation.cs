using Api.Abstractions;

namespace Api.Services;

public class LongOperationSimulation : ILongOperationSimulation
{
    public int LongTimeOperation1()
    {
        Thread.Sleep(500);
        return 1;
    }
    
    public int LongTimeOperation2()
    {
        Thread.Sleep(1000);
        return 1;
    }

    public async Task<int> LongTimeOperation1Async()
    {
        await Task.Delay(500);
        return 1;
    }

    public async Task<int> LongTimeOperation2Async()
    {
        await Task.Delay(1000);
        return 1;
    }
}