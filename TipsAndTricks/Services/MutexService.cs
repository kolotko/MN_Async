using TipsAndTricks.Abstractions;

namespace TipsAndTricks.Services;

/// <summary>
/// Symuluje stworzenie 10 wątków i na każdym z nich uruchomienie pętli inkrementującej nie thread-safe licznik.
/// Za pomoca mutex inkrementacja odbywa się w bezpieczny sposób 
/// </summary>
public class MutexService : IMutexService
{
    public void UseCounterInsideLock()
    {
        CounterWithMutex counter = new CounterWithMutex();
        
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

class CounterWithMutex
{
    private int count = 0;
    private static Mutex mutex = new Mutex();

    public void Increment()
    {
        mutex.WaitOne();

        try
        {
            count++;
            Console.WriteLine($"Count after increment: {count}");
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }

    public int GetCount()
    {
        return count;
    }
}