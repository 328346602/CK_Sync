using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CM.Map
{
    public class Config
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private static string sPath = System.Threading.Thread.GetDomain().BaseDirectory + "\\service.config";

        private static XmlDataDocument xDoc;

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <returns></returns>
        private static XmlDataDocument GetConfigPath()
        {
            try
            {
                //获取程序启动文件路径
                //string sStartPath = System.Windows.Forms.Application.ExecutablePath;
                //sStartPath = sStartPath.Substring(0, sStartPath.LastIndexOf('\\'));

                //string sPath = System.Threading.Thread.GetDomain().BaseDirectory + "\\service.config";

                xDoc = new XmlDataDocument();
                xDoc.Load(sPath);

                return xDoc;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 读取配置文件中相关的值
        /// </summary>
        public static string GetConfigValue(string key)
        {
            if (xDoc == null)
            {
                GetConfigPath();
            }
            //找出名称为“add”的所有元素
            XmlNodeList xNodes = xDoc.GetElementsByTagName("add");
            for (int i = 0; i < xNodes.Count; i++)
            {
                //获得将当前元素的key属性
                XmlAttribute att = xNodes[i].Attributes["key"];
                if (att != null)
                {
                    if (att.Value == key)
                    {
                        return xNodes[i].Attributes["value"].Value;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 设置配置文件中相关的值
        /// </summary>
        public static void SetConfigValue(string key, string value)
        {
            if (xDoc == null)
            {
                GetConfigPath();
            }
            //找出名称为“add”的所有元素
            XmlNodeList xNodes = xDoc.GetElementsByTagName("add");
            for (int i = 0; i < xNodes.Count; i++)
            {
                //获得将当前元素的key属性
                XmlAttribute att = xNodes[i].Attributes["key"];
                if (att != null)
                {
                    if (att.Value == key)
                    {
                        xNodes[i].Attributes["value"].Value = value;
                        xDoc.Save(sPath);
                    }
                }
            }
        }
    }
}