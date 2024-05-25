using TipsAndTricks.Abstractions;

namespace TipsAndTricks.Services;

public class SemaphoreService : ISemaphoreService
{
    public void Example()
    {
        SemaphoreDatabase db = new SemaphoreDatabase();
        
        Thread[] threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(db.Connect);
            threads[i].Name = $"Thread {i + 1}";
            threads[i].Start();
        }
        
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine("All threads done.");
        Console.ReadLine();
    }
}

class SemaphoreDatabase
{
    private static Semaphore semaphore = new Semaphore(3, 3); // Maksymalnie 3 jednoczesne połączenia

    public void Connect()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} waiting to connect...");
        
        semaphore.WaitOne();
        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} connected.");
            Thread.Sleep(2000);
            Console.WriteLine($"{Thread.CurrentThread.Name} done.");
        }
        finally
        {
            semaphore.Release();
        }
    }
}