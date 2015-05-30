using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iEAS
{
    public static class Helper
    {

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
