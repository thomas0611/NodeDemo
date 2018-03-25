using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRPCDemo;

namespace gRPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:9007", ChannelCredentials.Insecure);

            var client = new gRPC.gRPCClient(channel);
            var reply= client.SayHello(new HelloRequest { Name = "Thomas" });
            Console.WriteLine("来自" + reply.Message);
            foreach (var item in reply.Newslist)
            {
                Console.WriteLine($"{item.Id}:{item.Title}");
            }
            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
