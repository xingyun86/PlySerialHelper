using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlyFramework
{
    /// <summary>
    /// 程序集信息
    /// </summary>
    public class AssemblyInfo
    {
        private Assembly _Assembly = null;
        public AssemblyInfo()
        {
            this._Assembly = Assembly.GetExecutingAssembly();
        }

        public AssemblyInfo(Assembly assembly)
        {
            this._Assembly = assembly;
        }
        #region 程序集特性访问器
        /// <summary>
        /// 程序集名称
        /// </summary>
        public string Product
        {
            get
            {
                object[] attributes = this._Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        /// <summary>
        /// 程序集标题
        /// </summary>
        public string Title
        {
            get
            {
                object[] attributes = _Assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(this._Assembly.CodeBase);
            }
        }
        /// <summary>
        /// 程序集版本
        /// </summary>
        public string Version
        {
            get
            {
                return this._Assembly.GetName().Version.ToString();
            }
        }
        /// <summary>
        /// 程序集描述
        /// </summary>
        public string Description
        {
            get
            {
                object[] attributes = this._Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// 程序集版权信息
        /// </summary>
        public string Copyright
        {
            get
            {
                object[] attributes = this._Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        /// <summary>
        /// 程序集公司名称
        /// </summary>
        public string Company
        {
            get
            {
                object[] attributes = this._Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
