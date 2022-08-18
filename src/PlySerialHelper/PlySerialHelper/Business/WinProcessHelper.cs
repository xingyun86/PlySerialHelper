
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlyFramework
{
    /// <summary>
    /// Window 进程
    /// </summary>
    public class WinProcessHelper
    {
        /// <summary>
        /// 启动exe程序
        /// </summary>
        /// <param name="ServicePath"></param>
        /// <param name="ServiceName"></param>
        public static void Start(string appFile, bool noWindow = true)
        {
            if (System.IO.File.Exists(appFile) == false)
            {
                Logger.Info("文件：" + appFile + " 不存在！");
                return;
            }
            new Thread(m => {

                Process p = new Process();
                p.StartInfo.FileName = appFile;
                p.StartInfo.CreateNoWindow = noWindow;
                //p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.RedirectStandardInput = true;
                //p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();

            }).Start();
        }
        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="mKillProcess"></param>
        public static bool Kill(string[] mKillProcess,out string error)
        {
            error = string.Empty;
            foreach (var item in mKillProcess)
            {
                if(Kill(item,out error) == false)
                    return false;
            }
            GC.Collect();
            return true;
        }
        /// <summary>
        /// 关闭某个进程
        /// </summary>
        /// <param name="processName"></param>
        public static bool Kill(string processName,out string error)
        {
            error = string.Empty;
            try
            {
                int amount = 3;
                do
                {
                    Process[] process = Process.GetProcessesByName(processName);
                    if (process == null || process.Length <= 0)
                        amount = 0;
                    else
                    {
                        for (int i = 0; i < process.Length; i++)
                        {
                            try
                            {
                                process[i].Kill();
                            }
                            catch (Exception) { }
                        }
                        Thread.Sleep(500);
                        amount = amount - 1;
                    }
                } while (amount > 0);
                return Exists(processName) == false;
            }
            catch (Exception ex)
            {
                error = "关闭进程-"+processName+" 异常：" + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 判断进程是否存在
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static bool Exists(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);
            return (process != null && process.Length > 0);
        }
    }
}
