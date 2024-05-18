using TipsAndTricks.Abstractions;
using TipsAndTricks.Utility;

namespace TipsAndTricks.Services;

public class ForegroundBackgroundService : IForegroundBackgroundService
{
    public void Do()
    {
        Console.Clear();
        Console.WriteLine("Wybierz rodzaj taska:");
        Console.WriteLine("1. Background");
        Console.WriteLine("2. Foreground");
        
        var userInput = Console.ReadLine();
        var strategy = UserInputs.ConvertAndValidateUserInputDuringChoosingStrategy(userInput);
        Thread thread = new Thread(new ThreadStart(DoInsideTask));
        switch (strategy)
        {
            case 1:
                thread.IsBackground = true;
                break;
            case 2:
                thread.IsBackground = false;
                break;
            default:
                return;
        }
        
        thread.Start();
        thread.Join();
    }

    public static void DoInsideTask()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Task wykonany");
        Thread.Sleep(500);
    }
}