using TipsAndTricks.Abstractions;

namespace TipsAndTricks.Services;

public class AsyncEnumerableService : IAsyncEnumerableService
{
    public async Task PrintRandomNumberAsync()
    {
        Console.Clear();
        await foreach (var number in GetNumbersAsync())
        {
            Console.WriteLine(number);
        }

        Console.ReadLine();
    }
    
    private async IAsyncEnumerable<int> GetNumbersAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000);
            yield return i;
        }
    }
}