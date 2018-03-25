using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRPCDemo;
using Grpc.Core;
using Utility;

namespace gRPCServer
{
    class gRPCImpl : gRPC.gRPCBase
    {
        // 实现SayHello方法
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var reply = new HelloReply { Message = "Hello " + request.Name };
            reply.Newslist.Add(new News { Title = "test1", Id = 1 });
            reply.Newslist.Add(new News { Title = "test2", Id = 2 });
            return Task.FromResult(reply);
        }
    }

    class RpcSiteImpl:rpcSite.rpcSiteBase
    {
        public override Task<SitesReply> GetSites(SitesRequest request,ServerCallContext context)
        {
            var reply = new SitesReply { Message = "success" };
            try
            {
                var list = new IISHelper().GetAllSites();
                reply.ListWebSite.AddRange(list.Select(t => new WebSite
                {
                    ID = (int)t.ID,
                    Name = t.Name,
                    PhysicalPath = t.PhysicalPath,
                    BindingInformation = t.BindingInformation,
                    Port = t.Port,
                    Address = t.Address
                }));
            }
            catch (Exception ex)
            {
                reply.Message = ex.Message;
            }
            return Task.FromResult(reply);
        }
    }

    class Program
    {
        const int Port = 9007;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { rpcSite.BindService(new RpcSiteImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
