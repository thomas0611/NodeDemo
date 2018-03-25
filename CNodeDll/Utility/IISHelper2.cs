using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.DirectoryServices; //IIS 6.0 (ISS6.0时代主要以using System.DirectoryServices空间下的DirectoryEntry 对象作为编程访问一个主要载体)
using Microsoft.Web.Administration; //IIS 7.0
using Microsoft.Win32;
using System.Management;
using System.DirectoryServices;
using System.IO;

namespace MyDevelopTool
{

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
    }
    public class IISHelper2
    {

        public static Dictionary<string, IISInfo> GetIISList()
        {
            var dicData = new Dictionary<string, IISInfo>();
            using (ServerManager sm = new ServerManager())
            {
                //IISInfo.FrameworkVersion = sm.ApplicationPoolDefaults.ManagedRuntimeVersion;
                //IISInfo.ManagedPipelineMode = sm.ApplicationPoolDefaults.ManagedPipelineMode.ToString();
                //IISInfo.AutoStart = sm.ApplicationPoolDefaults.AutoStart;
                //IISInfo.ApplicationPoolName = sm.ApplicationDefaults.ApplicationPoolName;
                foreach (var s in sm.Sites)
                {
                    var iisInfo = new IISInfo();
                    iisInfo.ID = s.Id;
                    iisInfo.Name = s.Name;
                    iisInfo.PhysicalPath = s.Applications["/"].VirtualDirectories["/"].PhysicalPath;
                    iisInfo.ApplicationPoolName = s.Applications["/"].ApplicationPoolName;
                    iisInfo.EnabledProtocols = s.Applications["/"].EnabledProtocols;
                    iisInfo.ServerAutoStart = s.ServerAutoStart;
                    iisInfo.State = s.State.ToString();
                    iisInfo.Port = s.Bindings[0].EndPoint.Port;
                    dicData.Add(iisInfo.Name, iisInfo);
                }
            }
            return dicData;
        }

        public static string CreateWebSiete()
        {
            IISInfo iisInfo = new IISInfo
            {
                Name = "测试站点",
                Port = 6666,
                PhysicalPath = @"E:\Workspaces\产品重构\PDRZ.Integration-文轩版\PDRZ.IntegrationSchool",
                ApplicationPoolName = "测试站点",
                FrameworkVersion = "v4.0",
                ManagedPipelineMode = ManagedPipelineMode.Integrated
            };

            EditAppPool(iisInfo);
            DirectoryEntry de = new DirectoryEntry("IIS://localhost/w3svc");   //从活动目录中获取IIS对象。
            int siteID = 1;
            foreach (DirectoryEntry e in de.Children)
            {
                if (e.SchemaClassName == "IIsWebServer")
                {
                    int ID = Convert.ToInt32(e.Name);
                    if (ID >= siteID)
                    {
                        siteID = ID + 1;
                    }
                }
            }
            object[] prams = new object[2] { "IIsWebServer", siteID };
            DirectoryEntry site = (DirectoryEntry)de.Invoke("Create", prams); //创建IISWebServer对象。   
            site.Properties["KeyType"][0] = "IIsWebServer";
            //site.Properties["ServerComment"][0] = "默认应用程序"; //站点说明
            site.Properties["ServerComment"][0] = iisInfo.Name; //站点说明
            site.Properties["ServerState"][0] = 2; //站点初始状态，1.停止，2.启动，3
            site.Properties["ServerSize"][0] = 1;
            site.Properties["ServerBindings"].Add(":" + iisInfo.Port + ":"); //站点端口
            site.CommitChanges(); //保存改变
            de.CommitChanges();
            DirectoryEntry root = site.Children.Add("Root", "IIsWebVirtualDir");   //添加虚拟目录对象   
            root.Invoke("AppCreate", true); //创建IIS应用程序   
            root.Properties["path"][0] = iisInfo.PhysicalPath; //虚拟目录指向的物理目录   
            root.Properties["EnableDirBrowsing"][0] = false;//目录浏览   
            root.Properties["AuthAnonymous"][0] = true;
            root.Properties["AccessExecute"][0] = false;   //可执行权限   
            root.Properties["AccessRead"][0] = true;
            root.Properties["AccessWrite"][0] = false;
            root.Properties["AccessScript"][0] = true;//纯脚本   
            root.Properties["AccessSource"][0] = false;
            root.Properties["FrontPageWeb"][0] = false;
            root.Properties["KeyType"][0] = "IIsWebVirtualDir";
            //root.Properties["AppFriendlyName"][0] = "默认应用程序"; //应用程序名
            root.Properties["AppFriendlyName"][0] = iisInfo.Name; //应用程序名
            root.Properties["AppIsolated"][0] = 2;
            //if (!string.IsNullOrEmpty(defaultDoc) && ("," + DEFAULT_DOC + ",").IndexOf(defaultDoc.ToLower()) == -1)
            //{
            //    root.Properties["DefaultDoc"][0] = defaultDoc + "," + DEFAULT_DOC;//默认文档 
            //}
            //root.Properties["EnableDefaultDoc"][0] = false; //是否启用默认文档
            //设置网站asp.net版本为2.0
            //string rdf = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            //StringBuilder ScriptMapsList = new StringBuilder();
            //ScriptMapsList.AppendLine(@".aspx," + Path.Combine(rdf, "aspnet_isapi.dll") + ",1,GET,HEAD,POST,DEBUG");
            //ScriptMapsList.AppendLine(@".ashx," + Path.Combine(rdf, "aspnet_isapi.dll") + ",1,GET,HEAD,POST,DEBUG");
            //ScriptMapsList.AppendLine(@".asax," + Path.Combine(rdf, "aspnet_isapi.dll") + ",5,GET,HEAD,POST,DEBUG");
            //ScriptMapsList.AppendLine(@".config," + Path.Combine(rdf, "aspnet_isapi.dll") + ",5,GET,HEAD,POST,DEBUG");
            //ScriptMapsList.AppendLine(@".ascx," + Path.Combine(rdf, "aspnet_isapi.dll") + ",5,GET,HEAD,POST,DEBUG");
            //root.Properties["ScriptMaps"].Value = ScriptMapsList.ToString();
            root.CommitChanges();
            site.CommitChanges();
            root.Close();
            site.Close();
            de.CommitChanges(); //保存   
            site.Invoke("Start", null); //除了在创建过程中置初始状态外，也可在此调用方法改变状态
            return "";
        }

        public static bool DeleteSite(string SiteName)
        {
            DirectoryEntry deRoot = new DirectoryEntry("IIS://localhost/W3SVC/" + SiteName);
            deRoot.RefreshCache();
            deRoot.DeleteTree();
            deRoot.Close();
            return true;


        }

        /// <summary>
        /// 编辑 应用程序池，并返回 最大ID
        /// </summary>
        /// <param name="iisInfo"></param>
        /// <returns></returns>
        public static int EditAppPool(IISInfo iisInfo)
        {
            using (ServerManager sm = new ServerManager())
            {
                if (sm.ApplicationPools[iisInfo.ApplicationPoolName] == null)
                {
                    sm.ApplicationPools.Add(iisInfo.ApplicationPoolName);
                    ApplicationPool apppool = sm.ApplicationPools[iisInfo.ApplicationPoolName];
                    apppool.ManagedPipelineMode = iisInfo.ManagedPipelineMode;
                    apppool.ManagedRuntimeVersion = iisInfo.FrameworkVersion;
                    sm.CommitChanges();
                    apppool.Recycle();
                }
                else
                {
                    sm.ApplicationPools[iisInfo.ApplicationPoolName].ManagedRuntimeVersion = iisInfo.FrameworkVersion;
                    sm.ApplicationPools[iisInfo.ApplicationPoolName].ManagedPipelineMode = iisInfo.ManagedPipelineMode; //托管模式Integrated为集成 Classic为经典
                    sm.CommitChanges();
                }
                return (int)sm.Sites.Max(t => t.Id);
            }
        }

        /// <summary>
        ///  判断程序池是否存在
        /// </summary>
        /// <param name="AppPoolName">引用程序池名称</param>
        /// <returns></returns>
        private static bool HaveAppPoolName(string AppPoolName)
        {
            bool result = false;
            DirectoryEntry appPools = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
            foreach (DirectoryEntry getdir in appPools.Children)
            {
                if (getdir.Name.Equals(AppPoolName))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 删除指定程序池
        /// </summary>
        /// <param name="AppPoolName">程序池名称</param>
        /// <returns>true删除成功 false删除失败</returns>
        private bool DeleteAppPool(string AppPoolName)
        {
            bool result = false;
            DirectoryEntry appPools = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
            foreach (DirectoryEntry getdir in appPools.Children)
            {
                if (getdir.Name.Equals(AppPoolName))
                {
                    try
                    {
                        getdir.DeleteTree();
                        result = true;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        #region 检查IIS版本,注册表方式
        /// <summary>
        /// 检查IIS版本,注册表方式
        /// </summary>
        /// <returns></returns>
        private static int GetIISVersion()
        {
            try
            {
                string mjValue = GetLocalMachineKeyValue("SOFTWARE\\Microsoft\\InetStp", "MajorVersion");

                if (string.IsNullOrEmpty(mjValue))
                {
                    throw new Exception("本地服务器未安装IIS。");
                }

                int mjInt = -1;
                if (int.TryParse(mjValue, out mjInt))
                {
                    return mjInt;
                }
                throw new Exception("本地服务器未安装IIS。");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string GetLocalMachineKeyValue(string path, string keyName)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(path, true);
            object key = reg.GetValue(keyName);
            return key == null ? "" : key.ToString();
        }
        #endregion




    }


    #region 备用

    //private void Main_Load()
    //{
    //    ServerManager sm = new ServerManager();
    //    System.Console.WriteLine("应用程序池默认设置：");
    //    System.Console.WriteLine("\t常规：");
    //    System.Console.WriteLine("\t\t.NET Framework 版本：{0}", sm.ApplicationPoolDefaults.ManagedRuntimeVersion);
    //    System.Console.WriteLine("\t\t队列长度：{0}", sm.ApplicationPoolDefaults.QueueLength);
    //    System.Console.WriteLine("\t\t托管管道模式：{0}", sm.ApplicationPoolDefaults.ManagedPipelineMode.ToString());
    //    System.Console.WriteLine("\t\t自动启动：{0}", sm.ApplicationPoolDefaults.AutoStart);

    //    System.Console.WriteLine("\tCPU：");
    //    System.Console.WriteLine("\t\t处理器关联掩码：{0}", sm.ApplicationPoolDefaults.Cpu.SmpProcessorAffinityMask);
    //    System.Console.WriteLine("\t\t限制：{0}", sm.ApplicationPoolDefaults.Cpu.Limit);
    //    System.Console.WriteLine("\t\t限制操作：{0}", sm.ApplicationPoolDefaults.Cpu.Action.ToString());
    //    System.Console.WriteLine("\t\t限制间隔（分钟）：{0}", sm.ApplicationPoolDefaults.Cpu.ResetInterval.TotalMinutes);
    //    System.Console.WriteLine("\t\t已启用处理器关联：{0}", sm.ApplicationPoolDefaults.Cpu.SmpAffinitized);

    //    System.Console.WriteLine("\t回收：");
    //    System.Console.WriteLine("\t\t发生配置更改时禁止回收：{0}", sm.ApplicationPoolDefaults.Recycling.DisallowRotationOnConfigChange);
    //    System.Console.WriteLine("\t\t固定时间间隔（分钟）：{0}", sm.ApplicationPoolDefaults.Recycling.PeriodicRestart.Time.TotalMinutes);
    //    System.Console.WriteLine("\t\t禁用重叠回收：{0}", sm.ApplicationPoolDefaults.Recycling.DisallowOverlappingRotation);
    //    System.Console.WriteLine("\t\t请求限制：{0}", sm.ApplicationPoolDefaults.Recycling.PeriodicRestart.Requests);
    //    System.Console.WriteLine("\t\t虚拟内存限制（KB）：{0}", sm.ApplicationPoolDefaults.Recycling.PeriodicRestart.Memory);
    //    System.Console.WriteLine("\t\t专用内存限制（KB）：{0}", sm.ApplicationPoolDefaults.Recycling.PeriodicRestart.PrivateMemory);
    //    System.Console.WriteLine("\t\t特定时间：{0}", sm.ApplicationPoolDefaults.Recycling.PeriodicRestart.Schedule.ToString());
    //    System.Console.WriteLine("\t\t生成回收事件日志条目：{0}", sm.ApplicationPoolDefaults.Recycling.LogEventOnRecycle.ToString());

    //    System.Console.WriteLine("\t进程孤立：");
    //    System.Console.WriteLine("\t\t可执行文件：{0}", sm.ApplicationPoolDefaults.Failure.OrphanActionExe);
    //    System.Console.WriteLine("\t\t可执行文件参数：{0}", sm.ApplicationPoolDefaults.Failure.OrphanActionParams);
    //    System.Console.WriteLine("\t\t已启用：{0}", sm.ApplicationPoolDefaults.Failure.OrphanWorkerProcess);

    //    System.Console.WriteLine("\t进程模型：");
    //    System.Console.WriteLine("\t\tPing 间隔（秒）：{0}", sm.ApplicationPoolDefaults.ProcessModel.PingInterval.TotalSeconds);
    //    System.Console.WriteLine("\t\tPing 最大响应时间（秒）：{0}", sm.ApplicationPoolDefaults.ProcessModel.PingResponseTime.TotalSeconds);
    //    System.Console.WriteLine("\t\t标识：{0}", sm.ApplicationPoolDefaults.ProcessModel.IdentityType);
    //    System.Console.WriteLine("\t\t用户名：{0}", sm.ApplicationPoolDefaults.ProcessModel.UserName);
    //    System.Console.WriteLine("\t\t密码：{0}", sm.ApplicationPoolDefaults.ProcessModel.Password);
    //    System.Console.WriteLine("\t\t关闭时间限制（秒）：{0}", sm.ApplicationPoolDefaults.ProcessModel.ShutdownTimeLimit.TotalSeconds);
    //    System.Console.WriteLine("\t\t加载用户配置文件：{0}", sm.ApplicationPoolDefaults.ProcessModel.LoadUserProfile);
    //    System.Console.WriteLine("\t\t启动时间限制（秒）：{0}", sm.ApplicationPoolDefaults.ProcessModel.StartupTimeLimit.TotalSeconds);
    //    System.Console.WriteLine("\t\t允许 Ping：{0}", sm.ApplicationPoolDefaults.ProcessModel.PingingEnabled);
    //    System.Console.WriteLine("\t\t闲置超时（分钟）：{0}", sm.ApplicationPoolDefaults.ProcessModel.IdleTimeout.TotalMinutes);
    //    System.Console.WriteLine("\t\t最大工作进程数：{0}", sm.ApplicationPoolDefaults.ProcessModel.MaxProcesses);

    //    System.Console.WriteLine("\t快速故障防护：");
    //    System.Console.WriteLine("\t\t“服务不可用”响应类型：{0}", sm.ApplicationPoolDefaults.Failure.LoadBalancerCapabilities.ToString());
    //    System.Console.WriteLine("\t\t故障间隔（分钟）：{0}", sm.ApplicationPoolDefaults.Failure.RapidFailProtectionInterval.TotalMinutes);
    //    System.Console.WriteLine("\t\t关闭可执行文件：{0}", sm.ApplicationPoolDefaults.Failure.AutoShutdownExe);
    //    System.Console.WriteLine("\t\t关闭可执行文件参数：{0}", sm.ApplicationPoolDefaults.Failure.AutoShutdownParams);
    //    System.Console.WriteLine("\t\t已启用：{0}", sm.ApplicationPoolDefaults.Failure.RapidFailProtection);
    //    System.Console.WriteLine("\t\t最大故障数：{0}", sm.ApplicationPoolDefaults.Failure.RapidFailProtectionMaxCrashes);
    //    System.Console.WriteLine("\t\t允许32位应用程序运行在64位 Windows 上：{0}", sm.ApplicationPoolDefaults.Enable32BitAppOnWin64);

    //    System.Console.WriteLine();
    //    System.Console.WriteLine("网站默认设置：");
    //    System.Console.WriteLine("\t常规：");
    //    System.Console.WriteLine("\t\t物理路径凭据：UserName={0}, Password={1}", sm.VirtualDirectoryDefaults.UserName, sm.VirtualDirectoryDefaults.Password);
    //    System.Console.WriteLine("\t\t物理路径凭据登录类型：{0}", sm.VirtualDirectoryDefaults.LogonMethod.ToString());
    //    System.Console.WriteLine("\t\t应用程序池：{0}", sm.ApplicationDefaults.ApplicationPoolName);
    //    System.Console.WriteLine("\t\t自动启动：{0}", sm.SiteDefaults.ServerAutoStart);
    //    System.Console.WriteLine("\t行为：");
    //    System.Console.WriteLine("\t\t连接限制：");
    //    System.Console.WriteLine("\t\t\t连接超时（秒）：{0}", sm.SiteDefaults.Limits.ConnectionTimeout.TotalSeconds);
    //    System.Console.WriteLine("\t\t\t最大并发连接数：{0}", sm.SiteDefaults.Limits.MaxConnections);
    //    System.Console.WriteLine("\t\t\t最大带宽（字节/秒）：{0}", sm.SiteDefaults.Limits.MaxBandwidth);
    //    System.Console.WriteLine("\t\t失败请求跟踪：");
    //    System.Console.WriteLine("\t\t\t跟踪文件的最大数量：{0}", sm.SiteDefaults.TraceFailedRequestsLogging.MaxLogFiles);
    //    System.Console.WriteLine("\t\t\t目录：{0}", sm.SiteDefaults.TraceFailedRequestsLogging.Directory);
    //    System.Console.WriteLine("\t\t\t已启用：{0}", sm.SiteDefaults.TraceFailedRequestsLogging.Enabled);
    //    System.Console.WriteLine("\t\t已启用的协议：{0}", sm.ApplicationDefaults.EnabledProtocols);

    //    foreach (var s in sm.Sites)//遍历网站
    //    {
    //        System.Console.WriteLine();
    //        System.Console.WriteLine("模式名：{0}", s.Schema.Name);
    //        System.Console.WriteLine("编号：{0}", s.Id);
    //        System.Console.WriteLine("网站名称：{0}", s.Name);
    //        System.Console.WriteLine("物理路径：{0}", s.Applications["/"].VirtualDirectories["/"].PhysicalPath);
    //        System.Console.WriteLine("物理路径凭据：{0}", s.Methods.ToString());
    //        System.Console.WriteLine("应用程序池：{0}", s.Applications["/"].ApplicationPoolName);
    //        System.Console.WriteLine("已启用的协议：{0}", s.Applications["/"].EnabledProtocols);
    //        System.Console.WriteLine("自动启动：{0}", s.ServerAutoStart);
    //        System.Console.WriteLine("运行状态：{0}", s.State.ToString());

    //        System.Console.WriteLine("网站绑定：");
    //        foreach (var tmp in s.Bindings)
    //        {
    //   "\t类型：{0}", tmp.Protocol);
    //   "\tIP 地址：{0}", tmp.EndPoint.Address.ToString());
    //   "\t端口：{0}", tmp.EndPoint.Port.ToString());
    //   "\t主机名：{0}", tmp.Host);
    //            //System.Console.WriteLine(tmp.BindingInformation);
    //            //System.Console.WriteLine(tmp.CertificateStoreName);
    //            //System.Console.WriteLine(tmp.IsIPPortHostBinding);
    //            //System.Console.WriteLine(tmp.IsLocallyStored);
    //            //System.Console.WriteLine(tmp.UseDsMapper);
    //        }

    //        System.Console.WriteLine("连接限制：");
    //        System.Console.WriteLine("\t连接超时（秒）：{0}", s.Limits.ConnectionTimeout.TotalSeconds);
    //        System.Console.WriteLine("\t最大并发连接数：{0}", s.Limits.MaxConnections);
    //        System.Console.WriteLine("\t最大带宽（字节/秒）：{0}", s.Limits.MaxBandwidth);

    //        System.Console.WriteLine("失败请求跟踪：");
    //        System.Console.WriteLine("\t跟踪文件的最大数量：{0}", s.TraceFailedRequestsLogging.MaxLogFiles);
    //        System.Console.WriteLine("\t目录：{0}", s.TraceFailedRequestsLogging.Directory);
    //        System.Console.WriteLine("\t已启用：{0}", s.TraceFailedRequestsLogging.Enabled);

    //        System.Console.WriteLine("日志：");
    //        //System.Console.WriteLine("\t启用日志服务：{0}", s.LogFile.Enabled);
    //        System.Console.WriteLine("\t格式：{0}", s.LogFile.LogFormat.ToString());
    //        System.Console.WriteLine("\t目录：{0}", s.LogFile.Directory);
    //        System.Console.WriteLine("\t文件包含字段：{0}", s.LogFile.LogExtFileFlags.ToString());
    //        System.Console.WriteLine("\t计划：{0}", s.LogFile.Period.ToString());
    //        System.Console.WriteLine("\t最大文件大小（字节）：{0}", s.LogFile.TruncateSize);
    //        System.Console.WriteLine("\t使用本地时间进行文件命名和滚动更新：{0}", s.LogFile.LocalTimeRollover);

    //        System.Console.WriteLine("----应用程序的默认应用程序池：{0}", s.ApplicationDefaults.ApplicationPoolName);
    //        System.Console.WriteLine("----应用程序的默认已启用的协议：{0}", s.ApplicationDefaults.EnabledProtocols);
    //        //System.Console.WriteLine("----应用程序的默认物理路径凭据：{0}", s.ApplicationDefaults.Methods.ToString());
    //        //System.Console.WriteLine("----虚拟目录的默认物理路径凭据：{0}", s.VirtualDirectoryDefaults.Methods.ToString());
    //        System.Console.WriteLine("----虚拟目录的默认物理路径凭据登录类型：{0}", s.VirtualDirectoryDefaults.LogonMethod.ToString());
    //        System.Console.WriteLine("----虚拟目录的默认用户名：{0}", s.VirtualDirectoryDefaults.UserName);
    //        System.Console.WriteLine("----虚拟目录的默认用户密码：{0}", s.VirtualDirectoryDefaults.Password);
    //        System.Console.WriteLine("应用程序 列表：");
    //        foreach (var tmp in s.Applications)
    //        {
    //            if (tmp.Path != "/")
    //            {
    //       "\t模式名：{0}", tmp.Schema.Name);
    //       "\t虚拟路径：{0}", tmp.Path);
    //       "\t物理路径：{0}", tmp.VirtualDirectories["/"].PhysicalPath);
    //                //System.Console.WriteLine("\t物理路径凭据：{0}", tmp.Methods.ToString());
    //       "\t应用程序池：{0}", tmp.ApplicationPoolName);
    //       "\t已启用的协议：{0}", tmp.EnabledProtocols);
    //            }
    //   "\t虚拟目录 列表：");
    //            foreach (var tmp2 in tmp.VirtualDirectories)
    //            {
    //                if (tmp2.Path != "/")
    //                {
    //           "\t\t模式名：{0}", tmp2.Schema.Name);
    //           "\t\t虚拟路径：{0}", tmp2.Path);
    //           "\t\t物理路径：{0}", tmp2.PhysicalPath);
    //                    //System.Console.WriteLine("\t\t物理路径凭据：{0}", tmp2.Methods.ToString());
    //           "\t\t物理路径凭据登录类型：{0}", tmp2.LogonMethod.ToString());
    //                }
    //            }
    //        }
    //    }
    //}

    #endregion 备用

}

