using AsynchronousTimeline.Abstractions;

namespace AsynchronousTimeline.Services;

public class EapService : IEapService
{
    public void Calculate()
    {
        
        var userNumbers = GetNumberFromUser();
        
        // background worker
        
        
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