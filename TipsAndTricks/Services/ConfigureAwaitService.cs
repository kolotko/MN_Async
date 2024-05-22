using TipsAndTricks.Abstractions;

namespace TipsAndTricks.Services;

public class ConfigureAwaitService : IConfigureAwaitService
{
    public async Task DoSomething()
    {
        Console.Clear();
        var result = await SomeAsyncOperation().ConfigureAwait(false);
        ProcessResult(result);
        Console.ReadLine();
    }
    
    private async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(1000);
        return "Finished";
    }

    private void ProcessResult(string result)
    {
        Console.WriteLine(result);
    }
}