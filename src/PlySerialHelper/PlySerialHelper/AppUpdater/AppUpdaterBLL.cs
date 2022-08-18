using PlyFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PlySerialHelper
{
    class AppUpdaterBLL
    {
        /// <summary>
        /// 检查更新
        /// </summary>
        public static void CheckUpdate()
        {
            //更新更新程序
            try
            {
                //
                string mSourcePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content\\AppUpdater");
                if (System.IO.Directory.Exists(mSourcePath))
                {
                    string mDestPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppUpdater");
                    if (System.IO.Directory.Exists(mDestPath) == false)
                        System.IO.Directory.CreateDirectory(mDestPath);
                    /*判断更新进程是否关闭*/
                    if (PlyFramework.WinProcessHelper.Exists("PlyAppUpdater"))
                    {
                        WinMessageBox.Show("PlyAppUpdater 正在运行！");
                        return;
                    }
                    string[] files = System.IO.Directory.GetFiles(mSourcePath);
                    for (int index = 0; index < files.Length; index++)
                    {
                        string fileName = System.IO.Path.GetFileName(files[index]);
                        string saveFile = System.IO.Path.Combine(mDestPath, fileName);
                        System.IO.File.Copy(files[index], saveFile, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新更新程序异常：" + ex.ToString());
                return;
            }
            new Thread(m =>
            {
                string fileName = System.IO.Path.Combine(Application.StartupPath, "AppUpdater\\PlyAppUpdater.exe");
                if (System.IO.File.Exists(fileName))
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.Arguments = "AppPath=" + Application.StartupPath;
                    processInfo.FileName = fileName;
                    Process.Start(processInfo);
                }

            }).Start();
        }

        private static AppUpdaterInfo _AppUpdaterInfo = null;
        /// <summary>
        /// 获取本地程序信息
        /// </summary>
        /// <param name="appPath"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static AppUpdaterInfo GetAppUpdaterInfo(string appPath, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrEmpty(appPath))
                appPath = System.IO.Directory.GetParent(Application.StartupPath).FullName;

            //string mParentPath = System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
            //读取本地程序信息
            string mAppLocalFile = System.IO.Path.Combine(appPath, "AppUpdater.xml");
            if (System.IO.File.Exists(mAppLocalFile) == false)
            {
                error = "未能找到配置:" + mAppLocalFile;
                Logger.Error(error);
                return null;
            }
            _AppUpdaterInfo = new AppUpdaterInfo();
            _AppUpdaterInfo.InitValue(mAppLocalFile);
            return _AppUpdaterInfo;
        }
    }
}
