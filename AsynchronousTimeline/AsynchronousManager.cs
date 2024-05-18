using AsynchronousTimeline.Abstractions;
using Microsoft.Extensions.Hosting;

namespace AsynchronousTimeline;

public class AsynchronousManager(IApmService apmService, IEapService eapService) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz sposób wykonania asynchroniczności");
            Console.WriteLine("1. Asynchronous Programming Model (APM)");
            Console.WriteLine("2. Event-based Asynchronous Pattern (EAP)");

            var userInput = Console.ReadLine();
            var strategy = ConvertAndValidateUserInputDuringChoosingStrategy(userInput);
            switch (strategy)
            {
                case 1:
                    apmService.Calculate();
                    break;
                case 2:
                    eapService.DoSomething();
                    break;
            }
            
            
        }
        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
    
    private int ConvertAndValidateUserInputDuringChoosingStrategy(string userInput)
    {
        var success = int.TryParse(userInput, out int userInteager);
        if (success)
            return userInteager;
        return -1;
    }
}
