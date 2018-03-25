using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class IISHelper
    {
        public List<IISInfo> GetAllSites()
        {
            //DirectoryEntry rootEntry = new DirectoryEntry("IIS://localhost/w3svc");
            List<IISInfo> list = new List<IISInfo>();
            using (ServerManager sm = new ServerManager())
            {
                foreach (var site in sm.Sites)
                {
                    var iisInfo = new IISInfo();
                    iisInfo.ID = site.Id;
                    iisInfo.Name = site.Name;
                    iisInfo.PhysicalPath = site.Applications["/"].VirtualDirectories["/"].PhysicalPath;
                    iisInfo.ApplicationPoolName = site.Applications["/"].ApplicationPoolName;
                    iisInfo.EnabledProtocols = site.Applications["/"].EnabledProtocols;
                    iisInfo.ServerAutoStart = site.ServerAutoStart;
                    //iisInfo.State = site.State.ToString();
                    iisInfo.Address = site.Bindings[0].EndPoint.Address.MapToIPv4().ToString();
                    iisInfo.Port = site.Bindings[0].EndPoint.Port;
                    iisInfo.BindingInformation = site.Bindings[0].BindingInformation;
                    list.Add(iisInfo);
                }
            }
            return list;
        }
    }

    public class IISInfo
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string PhysicalPath { get; set; }
        public string ApplicationPoolName { get; set; }
        public string FrameworkVersion { get; set; }
        public string EnabledProtocols { get; set; }
        public string State { get; set; }
        public int Port { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 托管模式
        /// Integrated-集成
        /// Classic-经典
        /// </summary>
        public ManagedPipelineMode ManagedPipelineMode { get; set; }
        /// <summary>
        /// 自动启动
        /// </summary>
        public bool AutoStart { get; set; }
        public bool ServerAutoStart { get; set; }
        public string BindingInformation { get; set; }
    }
}
