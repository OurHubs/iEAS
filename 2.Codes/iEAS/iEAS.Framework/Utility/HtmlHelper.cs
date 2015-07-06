using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS
{   
    /// 读取、写入html 文件
    /// <summary>
    /// 读取、写入html 文件
    /// </summary>
    public class HtmlHelper
    {
        public HtmlHelper() { }

        //读取模板
        /// <summary>
        /// 读取模板页面
        /// </summary>
        /// <param name="FileName">文件名称：例如 Template.html</param>
        /// <param name="HtmlPath">模板路径：例如 Server.MapPath("../../template/")</param>
        /// <returns></returns>
        public static string ReadTemplate(string FileName, string HtmlPath)
        {
            string re = string.Empty;
            using (StreamReader sr = new StreamReader(HtmlPath + "/" + FileName, Encoding.UTF8))
            {             
                re = sr.ReadToEnd();
            }
            return re;
        }

        ///创建Html
        /// <summary>
        /// 创建html
        /// </summary>
        /// <param name="HtmlStr">html字符串</param>
        /// <param name="HtmlPath">要生成html路径</param>
        /// <param name="FileName">要生成的件名称 例如index.html</param>
        public static void CreateHtml(string HtmlStr, string HtmlPath, string FileName)
        {
            bool append = false;//设置为False 直接替换

            if (!Directory.Exists(HtmlPath))
            {
                Directory.CreateDirectory(HtmlPath);
            }
            Encoding encoding1 = Encoding.GetEncoding("UTF-8");

            using (StreamWriter sw = new StreamWriter(HtmlPath + "/" + FileName, append, encoding1))
            {
                try
                {
                    sw.Write(HtmlStr);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }

    }
}
