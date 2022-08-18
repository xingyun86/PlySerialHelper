using PlyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlySerialHelper
{
    /// <summary>
    /// 程序本地信息
    /// </summary>
    public class AppUpdaterInfo : BasicEntity
    {
        /// <summary>
        /// 程序编号
        /// </summary>
        public string Code
        {
            get { return this.GetValue("Code"); }
            set { this.SetValue("Code", value); }
        }
        /// <summary>
        /// 程序名称
        /// </summary>
        public string Name
        {
            get { return this.GetValue("Name"); }
            set { this.SetValue("Name", value); }
        }
        /// <summary>
        /// 程序版本
        /// </summary>
        public string Version
        {
            get { return this.GetValue("Version"); }
            set { this.SetValue("Version", value); }
        }

        /// <summary>
        /// 程序服务器地址
        /// </summary>
        public string ServerUrl
        {
            get { return this.GetValue("ServerUrl"); }
            set { this.SetValue("ServerUrl", value); }
        }

        /// <summary>
        /// 程序描述
        /// </summary>
        public string Desc
        {
            get { return this.GetValue("Desc"); }
            set { this.SetValue("Desc", value); }
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        public string KillProcess
        {
            get { return this.GetValue("KillProcess"); }
            set { this.SetValue("KillProcess", value); }
        }

        /// <summary>
        /// 关闭服务程序
        /// </summary>
        public string StopServices
        {
            get { return this.GetValue("StopServices"); }
            set { this.SetValue("StopServices", value); }
        }

        /// <summary>
        /// 启动程序
        /// </summary>
        public string StartProcess
        {
            get { return this.GetValue("StartProcess"); }
            set { this.SetValue("StartProcess", value); }
        }

        /// <summary>
        /// 需要启动服务
        /// </summary>
        public string StartServices
        {
            get { return this.GetValue("StartServices"); }
            set { this.SetValue("StartServices", value); }
        }
    }
}
