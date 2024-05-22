using TipsAndTricks.Abstractions;

namespace TipsAndTricks.Services;

public class ValueTaskService : IValueTaskService
{
    private static readonly string CachedValue = "Cached Data";

    public async ValueTask<string> GetDataAsync()
    {
        Console.Clear();
        Console.WriteLine("pobrać wartość z cahce? y/n");
        var userInput = Console.ReadLine();
        
        if (userInput == "y")
        {
            return CachedValue;
        }
        
        return await FetchDataFromDatabaseAsync();
    }

    private async Task<string> FetchDataFromDatabaseAsync()
    {
        await Task.Delay(2000);
        return "Fetched Data";
    }
}