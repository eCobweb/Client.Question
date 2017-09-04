using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuestionClient.Helper
{
    public class XMLHelper
    {
        public XMLHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }       

        #region xmlDoc
        /// <summary>
        /// 创建一个XmlDocument对象
        /// </summary>
        /// <param name="PathOrString">文件名称或XML字符串</param>
        public static XmlDocument xmlDoc(string PathOrString)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                if (System.IO.File.Exists(PathOrString))
                {
                    xDoc.Load(PathOrString);
                }
                else
                {
                    xDoc.LoadXml(PathOrString);
                }
                return xDoc;
            }
            catch
            {
                return null;
            }
        }
        #endregion  
        

        #region GetNode
        /// <summary>
        /// 获取指定节点名称的节点对象
        /// </summary>
        /// <param name="fileFullName">文件名称，包括完整路径</param>
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public static XmlNode GetNode(string fileFullName, string nodeName)
        {
            XmlDocument xDoc = xmlDoc(fileFullName);
            if (xDoc.DocumentElement.Name == nodeName) return (XmlNode)xDoc.DocumentElement;
            XmlNodeList nlst = xDoc.DocumentElement.ChildNodes;
            foreach (XmlNode xns in nlst)  // 遍历所有子节点
            {
                if (xns.Name.ToLower() == nodeName.ToLower()) return xns;
                else
                {
                    XmlNode xn = GetNode(xns, nodeName);
                    if (xn != null) return xn;  /// V1.0.0.3添加节点判断
                }
            }
            return null;
        }
        /// <summary>
        /// 获取指定节点名称的节点对象
        /// </summary>
        /// <param name="node">节点对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public static XmlNode GetNode(XmlNode node, string nodeName)
        {
            foreach (XmlNode xn in node)
            {
                if (xn.Name.ToLower() == nodeName.ToLower()) return xn;
                else
                {
                    XmlNode tmp = GetNode(xn, nodeName);
                    if (tmp != null) return tmp;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取指定节点名称的节点对象
        /// </summary>
        /// <param name="xDoc">XmlDocument对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public static XmlNode GetNode(XmlDocument xDoc, string nodeName)
        {
            if (xDoc.DocumentElement.Name == nodeName) return (XmlNode)xDoc.DocumentElement;
            XmlNodeList nlst = xDoc.DocumentElement.ChildNodes;
            foreach (XmlNode xns in nlst)  // 遍历所有子节点
            {
                if (xns.Name.ToLower() == nodeName.ToLower()) return xns;
                else
                {
                    XmlNode xn = GetNode(xns, nodeName);
                    if (xn != null) return xn;   /// 添加节点判断, 避免只查询一个节点
                }
            }
            return null;
        }
        /// <summary>
        /// 获取指定节点名称的节点对象
        /// </summary>
        /// <param name="xDoc">XmlDocument对象</param>
        /// <param name="Index">节点索引</param>
        /// <param name="nodeName">节点名称</param>
        public static XmlNode GetNode(XmlDocument xDoc, int Index, string nodeName)
        {
            XmlNodeList nlst = xDoc.DocumentElement.ChildNodes;
            if (nlst.Count <= Index) return null;
            if (nlst[Index].Name.ToLower() == nodeName.ToLower()) return (XmlNode)nlst[Index];
            foreach (XmlNode xn in nlst[Index])
            {
                return GetNode(xn, nodeName);
            }
            return null;
        }
        /// <summary>
        /// 获取指定节点名称的节点对象
        /// </summary>
        /// <param name="fileFullName">文件名称，包括完整路径</param>
        /// <param name="Index">节点索引</param>
        /// <param name="nodeName">节点名称</param>
        public static XmlNode GetNode(string fileFullName, int Index, string nodeName)
        {
            XmlDocument xDoc = xmlDoc(fileFullName);
            XmlNodeList nlst = xDoc.DocumentElement.ChildNodes;
            if (nlst.Count <= Index) return null;
            if (nlst[Index].Name.ToLower() == nodeName.ToLower()) return (XmlNode)nlst[Index];
            foreach (XmlNode xn in nlst[Index])
            {
                return GetNode(xn, nodeName);
            }
            return null;
        }
        /// <summary>
        /// 获取指定节点名称的节点对象
        /// </summary>
        /// <param name="node">节点对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="innerText">节点内容</param>
        public static XmlNode GetNode(XmlNode node, string nodeName, string innerText)
        {
            foreach (XmlNode xn in node)
            {
                if (xn.Name.ToLower() == nodeName.ToLower() && xn.InnerText == innerText) return xn;
                else
                {
                    XmlNode tmp = GetNode(xn, nodeName, innerText);
                    if (tmp != null) return tmp;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取指定节点名称的节点对象
        /// </summary>
        /// <param name="xDoc">XmlDocument对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="innerText">节点内容</param>
        public static XmlNode GetNode(XmlDocument xDoc, string nodeName, string innerText)
        {
            XmlNodeList nlst = xDoc.DocumentElement.ChildNodes;
            foreach (XmlNode xns in nlst)  // 遍历所有子节点
            {
                if (xns.Name.ToLower() == nodeName.ToLower() && xns.InnerText == innerText) return xns;
                XmlNode tmp = GetNode(xns, nodeName, innerText);
                if (tmp != null) return tmp;
            }
            return null;
        }
        
        #endregion

        
    }
}
