namespace TipsAndTricks.Abstractions;

public interface IValueTaskService
{
    ValueTask<string> GetDataAsync();
}