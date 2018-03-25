using Grpc.Core;
using GRPCDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace RPCWinService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            const int Port = 9007;
            Server server = new Server
            {
                Services = { rpcSite.BindService(new RpcSiteImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();
        }

        protected override void OnStop()
        {
        }
    }

    class RpcSiteImpl : rpcSite.rpcSiteBase
    {
        public override Task<SitesReply> GetSites(SitesRequest request, ServerCallContext context)
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
}
