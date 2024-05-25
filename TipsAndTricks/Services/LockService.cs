using TipsAndTricks.Abstractions;

namespace TipsAndTricks.Services;


/// <summary>
/// Symuluje stworzenie 10 wątków i na każdym z nich uruchomienie pętli inkrementującej nie thread-safe licznik.
/// Za pomoca lock inkrementacja odbywa się w bezpieczny sposób 
/// </summary>
public class LockService : ILockService
{
    public void UseCounterInsideLock()
    {
        CounterWithLock counter = new CounterWithLock();
        
        Thread[] threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int j = 0; j < 100; j++)
                {
                    counter.Increment();
                }
            });
        }
        
        foreach (Thread t in threads)
        {
            t.Start();
        }
        
        foreach (Thread t in threads)
        {
            t.Join();
        }
        
        Console.WriteLine($"Final count: {counter.GetCount()}");
        Console.ReadLine();
    }
}

class CounterWithLock
{
    private int count = 0;
    private readonly object lockObject = new object();

    public void Increment()
    {
        lock (lockObject)
        {
            count++;
            Console.WriteLine($"Count after increment: {count}");
        }
    }

    public int GetCount()
    {
        return count;
    }
}