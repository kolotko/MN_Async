using TipsAndTricks.Abstractions;

namespace TipsAndTricks.Services;

public class ElidingService : IElidingService
{
    public Task DoSomething()
    {
        Console.Clear();
        Console.WriteLine("Pierwsze zadanie bez await");
        return GetTask();
    }

    private Task GetTask()
    {
        Console.WriteLine("Drugie zadanie bez await");
        return GetTaskAsync();
    }

    private async Task GetTaskAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine("Rezultat z zadania");
        Console.ReadLine();
    }
}