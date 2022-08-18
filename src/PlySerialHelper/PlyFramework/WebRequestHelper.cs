using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PlyFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class WebRequestHelper
    {
        /// <summary>
        /// 获取返回结果
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            WebRequest request = Create(url);
            return Response(request);
        }
        /// <summary>
        /// 获取返回结果
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string POST(string url,byte[] buffer,string contentType = "application/json;charset:utf-8")
        {
            HttpWebRequest request = (HttpWebRequest)Create(url);
            request.Method = "POST";
            request.ContentType = contentType;
            request.Timeout = 30 * 1000;
            request.CookieContainer = new CookieContainer();
            //写入内容
            WebRequestHelper.Write(request, buffer);
            //读取返回
            return Response(request);
        }
        /// <summary>
        /// 获取返回结果
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WebRequest Create(string url)
        {
            return HttpWebRequest.Create(url);
        }
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="request"></param>
        /// <param name="buffer"></param>
        public static void Write(WebRequest request,byte[] buffer)
        {
            int count = buffer.Length;
            request.ContentLength = count;
            if(count > 0)
            {
                using (Stream stream = request.GetRequestStream())
                    stream.Write(buffer, 0, count);
            }
        }
        /// <summary>
        /// 获取返回结果
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string Response(WebRequest request)
        {
            try
            {
                using (Stream stream = request.GetResponse().GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("请求异常\n" + ex.ToString());
                return string.Empty;
            }
        }
    }
}
