using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace iEAS
{
    public static class Helper
    {

        public static StringBuilder Trim(this StringBuilder sb,params char[] trimChars)
        {
            if(trimChars==null)
            {
                trimChars = new char[] {' ','\r','\n' };
            }
            while (sb.Length > 0 && trimChars.Contains(sb[sb.Length -1]))
                sb.Remove(sb.Length-1,1);
            return sb;
        }

        /// <summary>
        /// 确保文件父目录存在
        /// </summary>
        /// <param name="filePath"></param>
        public static void EnsureParentDirectoryExist(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            if(!file.Directory.Exists)
            {
                file.Directory.Create();
            }
        }

        public static int GetInt(this IReadOnlyDictionary<string, object> dict,string name)
        {
            return (int)dict[name];
        }
        public static decimal GetDecimal(this IReadOnlyDictionary<string, object> dict, string name)
        {
            return (decimal)dict[name];
        }
        public static bool GetBoolean(this IReadOnlyDictionary<string, object> dict, string name)
        {
            return (bool)dict[name];
        }
        public static byte GetByte(this IReadOnlyDictionary<string, object> dict, string name)
        {
            return (byte)dict[name];
        }
        public static DateTime GetDateTime(this IReadOnlyDictionary<string, object> dict, string name)
        {
            return (DateTime)dict[name];
        }
        public static string GetStr(this IReadOnlyDictionary<string, object> dict, string name)
        {
            return dict.ContainsKey(name) ? dict[name].ToStr() : String.Empty;
        }
        public static string GetStr(this IReadOnlyDictionary<string, object> dict, string name,string format)
        {
            return String.Format("{0:"+format+"}", dict[name]);
        }

        public static string GetStr(this IReadOnlyDictionary<string, object> dict, string name,int maxLength)
        {
            string value=(dict.ContainsKey(name) ? dict[name].ToStr() : String.Empty);
            if (value.Length > maxLength)
                return value.Substring(0, maxLength) + "...";
            return value;
        }
    }
}
