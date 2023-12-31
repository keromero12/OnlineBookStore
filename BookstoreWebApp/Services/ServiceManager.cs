using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace BookstoreWebApp.Services;

public class ServiceManager : IServiceManager
{
    public TClient CreateGrpcClient<TClient>(string address, int port)
    {
        var fullAddress = $"http://{address}:{port}";
        var grpcWebHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
        var channel = GrpcChannel.ForAddress(fullAddress, new GrpcChannelOptions { HttpHandler = grpcWebHandler });
        return (TClient)typeof(TClient).GetConstructors().Single(x =>
                x.GetParameters().Length == 1 &&
                x.GetParameters().Single().ParameterType.IsAssignableFrom(typeof(GrpcChannel)))
            .Invoke(new object[] { channel });
    }
}