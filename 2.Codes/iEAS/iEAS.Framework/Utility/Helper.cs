using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
    }
}
