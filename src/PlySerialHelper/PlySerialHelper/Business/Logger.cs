using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlyFramework
{
    /// <summary>
    /// 日志存储管理
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// 获取保存目录
        /// </summary>
        /// <returns></returns>
        private static string GetSavePath()
        {
            string mSavePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            return Logger.GetSavePath(mSavePath);
        }

        /// <summary>
        /// 获取保存目录
        /// </summary>
        /// <returns></returns>
        private static string GetSavePath(string mRootPath)
        {
            DateTime now = DateTime.Now;
            //string mRootPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string mSavePath = System.IO.Path.Combine(mRootPath, now.ToString("yyyyMMdd"));
            if (System.IO.Directory.Exists(mSavePath) == false)
                System.IO.Directory.CreateDirectory(mSavePath);

            string[] mOldPaths = System.IO.Directory.GetDirectories(mRootPath);
            foreach (var item in mOldPaths)
            {
                if (item != mSavePath)
                    System.IO.Directory.Delete(item, true);
            }

            return mSavePath;
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg)
        {
            DateTime now = DateTime.Now;
            StringBuilder fileContent = new StringBuilder();
            try
            {
                fileContent.AppendLine(now.ToString("yyyy-MM-dd HH:mm:ss"));
                fileContent.AppendLine(msg);

                string mSavePath = Logger.GetSavePath();
                string mSaveFile = System.IO.Path.Combine(mSavePath, now.ToString("yyyyMMddHH") + "-info.log");
                System.IO.File.AppendAllText(mSaveFile, fileContent.ToString());
            }
            catch (Exception ex)
            {
                fileContent.AppendLine("保存日志异常：" + ex.ToString());
                string mSavePath = Logger.GetSavePath(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Log");
                string mSaveFile = System.IO.Path.Combine(mSavePath, now.ToString("yyyyMMddHH") + "-info.log");
                System.IO.File.AppendAllText(mSaveFile, fileContent.ToString());
            }
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string classify, string msg)
        {
            DateTime now = DateTime.Now;
            StringBuilder fileContent = new StringBuilder();
            try
            {
                fileContent.AppendLine(now.ToString("yyyy-MM-dd HH:mm:ss"));
                fileContent.AppendLine(msg);

                string mSavePath = Logger.GetSavePath();
                string mSaveFile = System.IO.Path.Combine(mSavePath, now.ToString("yyyyMMddHH") + "-" + classify + ".log");
                System.IO.File.AppendAllText(mSaveFile, fileContent.ToString());
            }
            catch (Exception ex)
            {
                fileContent.AppendLine("保存日志异常：" + ex.ToString());
                string mSavePath = Logger.GetSavePath(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Log");
                string mSaveFile = System.IO.Path.Combine(mSavePath, now.ToString("yyyyMMddHH") + "-" + classify + ".log");
                System.IO.File.AppendAllText(mSaveFile, fileContent.ToString());
            }
        }
        /// <summary>
        /// 保存异常
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            DateTime now = DateTime.Now;
            StringBuilder fileContent = new StringBuilder();
            try
            {
                fileContent.AppendLine(now.ToString("yyyy-MM-dd HH:mm:ss"));
                fileContent.AppendLine(msg);

                string mSavePath = Logger.GetSavePath();
                string mSaveFile = System.IO.Path.Combine(mSavePath, now.ToString("yyyyMMddHH") + "-error.log");
                System.IO.File.AppendAllText(mSaveFile, fileContent.ToString());
            }
            catch (Exception ex)
            {
                fileContent.AppendLine("保存日志异常：" + ex.ToString());
                string mSavePath = Logger.GetSavePath(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Log");
                string mSaveFile = System.IO.Path.Combine(mSavePath, now.ToString("yyyyMMddHH") + "-error.log");
                System.IO.File.AppendAllText(mSaveFile, fileContent.ToString());
            }
        }
    }
}
