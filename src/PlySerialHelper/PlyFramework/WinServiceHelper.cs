
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace PlyFramework
{
    /// <summary>
    /// Windows 服务程序辅助对象
    /// </summary>
    public class WinServiceHelper
    {
        /// <summary>
        /// 判断
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool IsInstall(string serviceName)
        {
            foreach (var s in ServiceController.GetServices())
            {
                if (s.ServiceName.ToLower().Equals(serviceName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 服务安装
        /// </summary>
        /// <param name="servicePath"></param>
        /// <param name="serviceName"></param>
        public static void Install(string serviceName, string servicePath, string serviceDesc)
        {
            TransactedInstaller ti = new TransactedInstaller();
            ti.Installers.Add(new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem });
            ti.Installers.Add(new ServiceInstaller
            {
                DisplayName = serviceName,
                ServiceName = serviceName,
                Description = serviceDesc,
                StartType = ServiceStartMode.Automatic
            });
            ti.Context = new InstallContext();
            ti.Context.Parameters["assemblypath"] = servicePath;// "\"" + ServicePath + "\" /service";
            ti.Install(new Hashtable());
        }

        /// <summary>
        /// 服务删除
        /// </summary>
        /// <param name="servicePath"></param>
        public static string UnInstall(string servicePath)
        {
            var result = string.Empty;
            try
            {
                var comm = string.Format("sc delete {0} &exit", servicePath);

                using (Process p = new Process())
                {
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    p.StandardInput.WriteLine(comm);
                    p.StandardInput.AutoFlush = true;
                    result = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    p.Close();
                }

                //using (AssemblyInstaller Installer = new AssemblyInstaller())
                //{
                // Installer.UseNewContext = true;
                // Installer.Path = ServicePath;
                // Installer.Uninstall(null);
                //}
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Logger.Error("卸载服务异常：" + ex.ToString());
                WinMessageBox.Error(result);
            }
            return result;
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="serviceNames"></param>
        public static void Start(string[] serviceNames)
        {
            foreach (var item in serviceNames)
            {
                WinServiceHelper.Start(item);
            }
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="serviceName"></param>
        public static void Start(string serviceName)
        {
            new Thread(m => {
                if (WinServiceHelper.IsInstall(serviceName) == false)
                    return;

                using (ServiceController Ctr = new ServiceController(serviceName))
                {
                    if (Ctr.Status == ServiceControllerStatus.Stopped || Ctr.Status == ServiceControllerStatus.Paused)
                        Ctr.Start();
                }
            });
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="serviceNames"></param>
        public static bool Stop(string[] serviceNames,out string error)
        {
            error = string.Empty;
            foreach (var item in serviceNames)
            {
                if(WinServiceHelper.Stop(item,out error) == false)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="serviceName"></param>
        public static bool Stop(string serviceName,out string error)
        {
            error = string.Empty;
            if (WinServiceHelper.IsInstall(serviceName) == false)
                return true;

            try
            {
                using (ServiceController Ctr = new ServiceController(serviceName))
                {
                    if (Ctr.Status == ServiceControllerStatus.Running || Ctr.Status == ServiceControllerStatus.Paused)
                        Ctr.Stop();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = "关闭服务异常：" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static ServiceControllerStatus Status(string serviceName)
        {
            ServiceControllerStatus temp = 0;
            using (ServiceController Ctr = new ServiceController(serviceName))
            {
                temp = Ctr.Status;
            }
            return temp;
        }
    }
}
