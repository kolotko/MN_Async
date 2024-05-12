namespace Api.Abstractions;

public interface ILongOperationSimulation
{
    int LongTimeOperation1();
    int LongTimeOperation2();
    
    Task<int> LongTimeOperation1Async();
    Task<int> LongTimeOperation2Async();
}