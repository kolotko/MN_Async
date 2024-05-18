using Microsoft.Extensions.Hosting;
using TipsAndTricks.Abstractions;
using TipsAndTricks.Utility;

namespace TipsAndTricks;

public class AsynchronousManager(IPriorityService priorityService, IForegroundBackgroundService foregroundBackgroundService) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz działanie");
            Console.WriteLine("1. Zmiana priorytetu wątku");
            Console.WriteLine("2. Foreground, Background tasks");
            // Console.WriteLine("3. Zmiana wątku");

            var userInput = Console.ReadLine();
            var strategy = UserInputs.ConvertAndValidateUserInputDuringChoosingStrategy(userInput);
            switch (strategy)
            {
                case 1:
                    priorityService.ChangePriority();
                    break;
                case 2:
                    foregroundBackgroundService.Do();
                    break;
                case 3:
                    // threadSwitch.SwitchThread();
                    break;
            }
            
            
        }
        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}