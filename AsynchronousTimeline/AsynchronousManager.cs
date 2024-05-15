using AsynchronousTimeline.Abstractions;
using Microsoft.Extensions.Hosting;

namespace AsynchronousTimeline;

public class AsynchronousManager(IApmServices apmServices) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz sposób wykonania asynchroniczności");
            Console.WriteLine("1. Asynchronous Programming Model (APM)");

            var userInput = Console.ReadLine();
            var strategy = ConvertAndValidateUserInputDuringChoosingStrategy(userInput);
            switch (strategy)
            {
                case 1:
                    apmServices.Calculate();
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
