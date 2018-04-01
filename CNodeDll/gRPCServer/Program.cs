using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRPCDemo;
using Grpc.Core;
using Utility;
using System.Configuration;
using System.Text.RegularExpressions;

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

        public override Task<DbDetail> GetSiteDetail(SitesRequest request, ServerCallContext context)
        {
            try
            {
                string path = request.Name;
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                string filename = $@"{path}\Web.config";
                map.ExeConfigFilename = filename;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                var strCon = "";
                foreach (ConnectionStringSettings item in config.ConnectionStrings.ConnectionStrings)
                {
                    if (item.Name != "DefaultConnection" && item.Name != "LocalSqlServer")
                    {
                        strCon = item.ConnectionString;
                        break;
                    }
                }
                var dbInfo = FormatCon(strCon);
                dbInfo.Message = "success";
                return Task.FromResult(dbInfo);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new DbDetail() { Message = ex.Message});
            }
        }

        /// <summary>
        /// 格式化连接字符串
        /// </summary>
        /// <param name="strCon"></param>
        /// <returns></returns>
        private DbDetail FormatCon(string strCon)
        {
            if (string.IsNullOrEmpty(strCon)) { return new DbDetail(); }
            var dbInfo = new DbDetail();
            dbInfo.Address = Regex.Match(strCon, @"server=([^;]+)").Groups[1].Value;
            dbInfo.Name = Regex.Match(strCon, @"base=([^;]+)").Groups[1].Value;
            dbInfo.User = Regex.Match(strCon, @"(id|user)=([^;]+)").Groups[2].Value;
            dbInfo.Pwd = Regex.Match(strCon, @"(pwd|password)=([^;]+)").Groups[2].Value;
            return dbInfo;
        }
    }

    class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { rpcSite.BindService(new RpcSiteImpl()) },
                Ports = { new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
