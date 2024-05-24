using Microsoft.Extensions.Hosting;
using TipsAndTricks.Abstractions;
using TipsAndTricks.Utility;

namespace TipsAndTricks;

public class AsynchronousManager(IPriorityService priorityService, IForegroundBackgroundService foregroundBackgroundService, IConfigureAwaitService configureAwaitService, IElidingService elidingService, IValueTaskService valueTaskService, IAsyncEnumerableService iAsyncEnumerableService) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz działanie");
            Console.WriteLine("1. Zmiana priorytetu wątku");
            Console.WriteLine("2. Foreground, Background tasks");
            Console.WriteLine("3. Configure Await");
            Console.WriteLine("4. Eliding Service");
            Console.WriteLine("5. Value Task");
            Console.WriteLine("6. IAsyncEnumerableService");

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
                    await configureAwaitService.DoSomething();
                    break;
                case 4:
                    await elidingService.DoSomething();
                    break;
                case 5:
                    var result = await valueTaskService.GetDataAsync();
                    Console.Clear();
                    Console.WriteLine(result);
                    Console.ReadLine();
                    break;
                case 6:
                     await iAsyncEnumerableService.PrintRandomNumberAsync();
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