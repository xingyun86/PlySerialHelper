using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace PlyFramework
{
    /// <summary>
    /// 基础实体信息
    /// </summary>
    public class BasicEntity
    {
        private Dictionary<string, string> _FieldValue = new Dictionary<string, string>();
        /// <summary>
        /// 获取所有字段值
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetFields()
        {
            return this._FieldValue;
        }
        /// <summary>
        /// 设置字段值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue(string name, string value)
        {
            name = name.ToLower();
            if (this._FieldValue.ContainsKey(name))
                this._FieldValue[name] = value;
            else
                this._FieldValue.Add(name, value);
        }
        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValue(string name)
        {
            name = name.ToLower();
            if (this._FieldValue.ContainsKey(name))
                return this._FieldValue[name];
            return string.Empty;
        }
        /// <summary>
        /// 初始字段值
        /// </summary>
        /// <param name="fileName"></param>
        public void InitValue(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            this.InitValue(doc);
        }
        /// <summary>
        /// 初始字段值
        /// </summary>
        /// <param name="drData"></param>
        public void InitValue(DataRow drData)
        {
            foreach (DataColumn dc in drData.Table.Columns)
            {
                if (drData[dc.ColumnName] != DBNull.Value)
                    this.SetValue(dc.ColumnName, drData[dc.ColumnName].ToString());
                else
                    this.SetValue(dc.ColumnName, "");
            }
        }
        /// <summary>
        /// 初始字段值
        /// </summary>
        /// <param name="doc"></param>
        public void InitValue(XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;
            foreach (XmlElement item in root.ChildNodes)
            {
                this.SetValue(item.Name, item.InnerText);
            }
        }
        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="rootName"></param>
        /// <returns></returns>
        public string OuterXml(string rootName = "entity")
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "yes"));
            XmlElement root = doc.CreateElement(rootName);
            foreach (var item in this._FieldValue)
            {
                XmlElement node = doc.CreateElement(item.Key);
                node.InnerText = item.Value;
                root.AppendChild(node);
            }
            doc.AppendChild(root);
            return doc.OuterXml;
        }
    }
}
