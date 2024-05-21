using AsynchronousTimeline.Abstractions;

namespace AsynchronousTimeline.Services;

public class TplService : ITplService
{
    public async Task DoSomething()
    {
        Console.Clear();
        Parallel.For(0, (long)10, i =>
        {
            Console.WriteLine($"Wartośc pętli{i}");
        });

        Console.ReadLine();
    }
}