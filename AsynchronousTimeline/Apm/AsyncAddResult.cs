namespace AsynchronousTimeline.Apm;

/// <summary>
/// Implementuje interfejs IAsyncResult.
//  Przechowuje wynik operacji i obsługuje synchronizację za pomocą ManualResetEvent
/// </summary>
public class AsyncAddResult : IAsyncResult
{
    private readonly ManualResetEvent _waitHandle;
    private readonly AsyncCallback _callback;
    private readonly object _state;
    private bool _completed;
    private int _result;

    public AsyncAddResult(AsyncCallback callback, object state)
    {
        _callback = callback;
        _state = state;
        _waitHandle = new ManualResetEvent(false);
    }

    public bool IsCompleted => _completed;
    public WaitHandle AsyncWaitHandle => _waitHandle;
    public object AsyncState => _state;
    public bool CompletedSynchronously => false;

    public int Result
    {
        get
        {
            _waitHandle.WaitOne();
            return _result;
        }
        internal set
        {
            _result = value;
            _completed = true;
            _waitHandle.Set();
            _callback?.Invoke(this);
        }
    }
}