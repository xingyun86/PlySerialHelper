using PlyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlySerialHelper
{
    /// <summary>
    /// 串口设置
    /// </summary>
    public class SerialPortSet : BasicEntity
    {
        public string Id {
            get { return this.GetValue("StopBits"); }
            set { this.SetValue("StopBits", value); }
        }
        public string PortName
        {
            get { return this.GetValue("PortName"); } set { this.SetValue("PortName", value); }
        }
        public string BaudRate
        {
            get { return this.GetValue("BaudRate"); }
            set { this.SetValue("BaudRate", value); }
        }
        public string DataBits
        {
            get { return this.GetValue("DataBits"); }
            set { this.SetValue("DataBits", value); }
        }
        public string Parity
        {
            get { return this.GetValue("Parity"); }
            set { this.SetValue("Parity", value); }
        }
        public string StopBits
        {
            get { return this.GetValue("StopBits"); }
            set { this.SetValue("StopBits", value); }
        }
        public string Handshake
        {
            get { return this.GetValue("Handshake"); }
            set { this.SetValue("Handshake", value); }
        }
    }
}
