using Grpc.Net.Client;
using System;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            // The port number(5001) must match the port of the gRPC server.
            httpClient.BaseAddress = new Uri("https://localhost:20000");
            var client = GrpcClient.Create<ServerRpcService.ServerRpcServiceClient>(httpClient);
            var reply = client.GetServerInfo(new ServerRpcRequest { Id = 1 });
            Console.WriteLine("Greeting: " + reply.Header.Description);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
