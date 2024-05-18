using AsynchronousTimeline.Abstractions;

namespace AsynchronousTimeline.Services;

public class TapService : ITapService
{
    public async Task DoSomething()
    {
        Console.Clear();
        Console.WriteLine("Symulacja bardzo skomplikowanej i długiej operacji");
        await Task.Delay(2000);
    }
}