using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace QuestionClient
{
    /// <summary>
    ///DotNetToHtm 的摘要说明
    /// </summary>
    public static class DotNetToHtm
    {
        /// <summary>
        /// 静态页面生成函数
        /// 传入模板文件和目标文件的相对路径
        /// 传入模板文件中的模板区域和区域值
        /// </summary>
        /// <remarks>
        /// 模板区域和区域值须一一对应
        /// 路径从站点根目录写起
        /// 已反斜线'/'分割
        /// </remarks>
        /// <param name="templateURL">模板文件路径</param>
        /// <param name="targetURL">要创建文件的保存路径</param>
        /// <param name="templateArea">模板区域</param>
        /// <param name="targetValue">替换的区域值</param>
        /// <returns>返回操作成功标识:trueORfalse</returns>
        public static bool CreateHtml(string templateURL, string targetURL, string[] templateArea, string[] targetValue)
        {
            bool flag = false;
            StringBuilder htmltext = new StringBuilder();
            try
            {
                //读取模板文件
                using (StreamReader sr = new StreamReader(templateURL))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        htmltext.Append(line);
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write("<script>alert('模板文件读取错误')</script>" + ex.ToString());
                return flag;
            }
            //替换模板中的标记文本
            for (int i = 0; i < templateArea.Length; i++)
            {
                htmltext.Replace(templateArea[i], targetValue[i]);
            }
            
            //--------------生成html文件-------
            try
            {
                using (StreamWriter sw = new StreamWriter(targetURL, false, System.Text.Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(htmltext);
                    sw.Flush();
                    sw.Close();
                    flag = true;
                    return flag;
                }
            }
            catch(Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write("＜Script＞alert('file cann't be writen')＜/Script＞");
                return flag;
            }

        }
    }
}
