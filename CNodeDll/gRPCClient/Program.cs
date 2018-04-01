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
            //Channel channel = new Channel("127.0.0.1:9007", ChannelCredentials.Insecure);

            //var client = new gRPC.gRPCClient(channel);
            //var reply= client.SayHello(new HelloRequest { Name = "Thomas" });
            //Console.WriteLine("来自" + reply.Message);
            //foreach (var item in reply.Newslist)
            //{
            //    Console.WriteLine($"{item.Id}:{item.Title}");
            //}
            //channel.ShutdownAsync().Wait();
            //Console.WriteLine("任意键退出...");
            //Console.ReadKey();

            //Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            //var client = new rpcSite.rpcSiteClient(channel);
            //var reply = client.GetSites(new SitesRequest { Name = "ApiTest" });
            //foreach (var item in reply.ListWebSite)
            //{
            //    Console.WriteLine($"{item.Name}:{item.Port}");
            //}

            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new rpcSite.rpcSiteClient(channel);
            var reply = client.GetSiteDetail(new SitesRequest { Name = @"E:\web\WebApiDemo\WS.EKA.Portal" });
            if (reply.Message == "success")
            {
                Console.WriteLine($"{reply.Address},{reply.Name},{reply.User},{reply.Pwd}");
            }
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
