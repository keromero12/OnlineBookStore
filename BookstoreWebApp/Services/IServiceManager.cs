namespace BookstoreWebApp.Services;

public interface IServiceManager
{
    public T CreateGrpcClient<T>(string address, int port);
}