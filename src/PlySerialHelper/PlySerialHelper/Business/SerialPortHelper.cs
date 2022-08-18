using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using PlyFramework;

namespace PlySerialHelper
{
    /// <summary>
    /// 串口辅助对象
    /// </summary>
    public class SerialPortHelper
    {
        private static SerialPort _SerialPort = null;
        private static object _lock = new object();
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public static SerialPort GetSerialPort(out string fail)
        {
            fail = string.Empty;
            SerialPortSet mSerialPortSet = null;
            try
            {
                mSerialPortSet = GetSerialPortSet();
                if (mSerialPortSet == null)
                {
                    fail = "串口配置信息不能空！";
                    return null;
                } 
            }
            catch (Exception ex)
            {
                fail = "读取串口配置信息 失败："+ex.Message;
                return null;
            }
            return GetSerialPort(mSerialPortSet, out fail);
        }
        /// <summary>
        /// 获取串口信息
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="fail"></param>
        /// <returns></returns>
        public static SerialPort GetSerialPort(SerialPortSet setting, out string fail)
        {
            fail = string.Empty;
            try
            {
                _SerialPort = new SerialPort();
                _SerialPort.PortName = setting.PortName;
                _SerialPort.BaudRate = setting.BaudRate.ToInt32();
                _SerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), setting.Parity, true);
                _SerialPort.DataBits = setting.DataBits.ToInt32();
                _SerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), setting.StopBits, true);
                _SerialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), setting.Handshake, true);

                return _SerialPort;
            }
            catch (Exception ex)
            {
                fail = "打开串口 异常：" + ex.Message;
                return null;
            }
        }

        private static string GetSaveFile()
        {
            string mSavePath = AppDomain.CurrentDomain.BaseDirectory;
            return System.IO.Path.Combine(mSavePath, "SerialPortSet.xml");
        }
        /// <summary>
        /// 获取串口设置信息
        /// </summary>
        /// <returns></returns>
        public static SerialPortSet GetSerialPortSet()
        {
            string mSaveFile = GetSaveFile();
            if(System.IO.File.Exists(mSaveFile) == false)
            {
                return null;
            }
            SerialPortSet entity = new SerialPortSet();
            entity.InitValue(mSaveFile);
            return entity;
        }
        /// <summary>
        /// 保存串口设置信息
        /// </summary>
        /// <param name="serialportset"></param>
        public static void Save(SerialPortSet serialportset)
        {
            string xml = serialportset.OuterXml();
            System.IO.File.WriteAllText(GetSaveFile(), xml, Encoding.UTF8);
        }
    }
}
