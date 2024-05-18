using System.ComponentModel;
using AsynchronousTimeline.Abstractions;

namespace AsynchronousTimeline.Services;

public class EapService : IEapService
{
    public void DoSomething()
    {
        Console.Clear();
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += Worker_DoWork;
        worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        worker.ProgressChanged += Worker_ProgressChanged;
        worker.WorkerReportsProgress = true;
        worker.WorkerSupportsCancellation = true;

        Console.WriteLine("Rozpoczęcie operacji w tle");
        worker.RunWorkerAsync();

        Console.WriteLine("Naciśnij 'c' aby zakończyć operację lub dowolny inny klawisz by kontynuować");
        if (Console.ReadKey(true).KeyChar == 'c')
        {
            worker.CancelAsync();
        }
        
        Console.ReadKey();
    }
    
    private static void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;

        for (int i = 0; i <= 100; i++)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                break;
            }

            // Simulate long-running operation
            Thread.Sleep(100);

            // Report progress
            worker.ReportProgress(i);
        }
    }

    private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            Console.WriteLine("Operacja zakończona niepowodzeniem.");
        }
        else if (e.Error != null)
        {
            Console.WriteLine("Błąd: " + e.Error.Message);
        }
        else
        {
            Console.WriteLine("Operacja zakończona pomyślnie.");
        }
    }

    private static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Console.WriteLine($"Progress: {e.ProgressPercentage}%");
    }
}