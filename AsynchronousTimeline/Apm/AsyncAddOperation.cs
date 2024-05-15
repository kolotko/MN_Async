namespace AsynchronousTimeline.Apm;

/// <summary>
/// BeginAdd: Rozpoczyna operację asynchroniczną, uruchamiając zadanie w puli wątków. Zwraca obiekt AsyncAddResult.
//  EndAdd: Kończy operację, zwracając wynik
/// </summary>
public class AsyncAddOperation
{
    public IAsyncResult BeginAdd(int a, int b, AsyncCallback callback, object state)
    {
        var asyncResult = new AsyncAddResult(callback, state);
        ThreadPool.QueueUserWorkItem(_ =>
        {
            // Symulacja długotrwałej operacji
            Thread.Sleep(5000);
            asyncResult.Result = a + b;
        });
        return asyncResult;
    }

    public int EndAdd(IAsyncResult asyncResult)
    {
        if (asyncResult is AsyncAddResult result)
        {
            return result.Result;
        }
        throw new ArgumentException("Invalid IAsyncResult");
    }
}