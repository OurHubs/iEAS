using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace iEAS.Utility
{
    public class XmlHelper
    {
        /// <summary>
        /// 将对象序列化到文件中
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        public static void Serialize(object obj,string filePath)
        {
            Helper.EnsureParentDirectoryExist(filePath);

            using (var stream = File.Open(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(stream, obj);
            }
        }

        /// <summary>
        /// 将文件中的数据反序列化为实体对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// 将文件中的数据反序列化为实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string filePath)
        {
            return (T)Deserialize(typeof(T), filePath);
        }
    }
}
