using AsynchronousTimeline.Abstractions;
using AsynchronousTimeline.Apm;

namespace AsynchronousTimeline.Services;

/// <summary>
/// BeginAdd: Rozpoczyna operację asynchroniczną, uruchamiając zadanie w puli wątków. Zwraca obiekt AsyncAddResult.
//  EndAdd: Kończy operację, zwracając wynik
/// </summary>
public class ApmService : IApmService
{
    public void Calculate()
    {
        var userNumbers = GetNumberFromUser();
        
        var addOperation = new AsyncAddOperation();

        // Rozpoczęcie operacji asynchronicznej
        IAsyncResult asyncResult = addOperation.BeginAdd(userNumbers.firstNumber, userNumbers.secondNumber, AddCompleted, "Operacja dodawania zakończona");

        // Oczekiwanie na zakończenie operacji w razie potrzeby
        asyncResult.AsyncWaitHandle.WaitOne();

        // Zakończenie operacji i pobranie wyniku
        int result = addOperation.EndAdd(asyncResult);
    }
    
    //Callback po wykonaniu operacji asynchronicznej
    private static void AddCompleted(IAsyncResult asyncResult)
    {
        if (asyncResult.AsyncState is string message)
        {
            Console.WriteLine(message);
        }

        var addOperation = new AsyncAddOperation();
        int result = addOperation.EndAdd(asyncResult);
        Console.WriteLine($"Wynik w callbacku: {result}");
    }

    private (int firstNumber, int secondNumber) GetNumberFromUser()
    {
        var firstNumber = 0;
        var secondNumber = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Podal liczbę:");
            var userInput = Console.ReadLine();
            firstNumber = ConvertAndValidateUserInputDuringChoosingStrategy(userInput);
            if (firstNumber == -1)
            {
                continue;
            }

            break;
        }
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Podal drugą liczbę:");
            var userInput = Console.ReadLine();
            secondNumber = ConvertAndValidateUserInputDuringChoosingStrategy(userInput);
            if (secondNumber == -1)
            {
                continue;
            }
            break;
        }

        return (firstNumber, secondNumber);
    }
    
    private int ConvertAndValidateUserInputDuringChoosingStrategy(string userInput)
    {
        var success = int.TryParse(userInput, out int userInteager);
        if (success)
            return userInteager;
        return -1;
    }
}