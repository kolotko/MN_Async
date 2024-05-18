using TipsAndTricks.Abstractions;
using TipsAndTricks.Utility;

namespace TipsAndTricks.Services;

public class PriorityService : IPriorityService
{
    public void ChangePriority()
    {
        Console.Clear();
        Console.WriteLine("Wybierz priorytet:");
        Console.WriteLine("1. Wysoki");
        Console.WriteLine("2. Powyżej normalnego");
        Console.WriteLine("3. Normalny");
        Console.WriteLine("4. Poniżej normalnego");
        Console.WriteLine("5. Niski");
        Console.WriteLine("");
        Console.WriteLine($"Aktualny priorytet: {Thread.CurrentThread.Priority}");

        var userInput = Console.ReadLine();
        var strategy = UserInputs.ConvertAndValidateUserInputDuringChoosingStrategy(userInput);
        switch (strategy)
        {
            case 1:
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                return;
            case 2:
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                return;
            case 3:
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
                return;
            case 4:
                Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
                return;
            case 5:
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                return;
            default:
                return;
        }
    }
}