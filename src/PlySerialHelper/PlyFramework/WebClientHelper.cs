
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PlyFramework
{
    /// <summary>
    /// Web 辅助对象
    /// </summary>
    public class WebClientHelper
    {
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="saveFile"></param>
        /// <returns></returns>
        public static bool Download(string url, string saveFile, out string error)
        {
            error = string.Empty;
            try
            {
                Logger.Info("开始下载文件：" + url + " saveFile=" + saveFile);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(url, saveFile);
                return true;
            }
            catch (Exception ex)
            {
                error = "下载文件异常：" + ex.ToString();
                Logger.Error(error);
                return false;
            }
        }
    }
}
