using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Caching
{
    /// <summary>
    /// 缓存辅助类
    /// </summary>
    public class CacheHelper
    {
        static ICacheProvider Provider
        {
            get { return ObjectContainer.GetService<ICacheProvider>(); }
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Insert(string key,object value)
        {
            Provider.Insert(key,value);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        public void Insert(string key, object value, int seconds)
        {
            Provider.Insert(key, value, seconds);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="filePaths"></param>
        public void Insert(string key, object value, string[] filePaths)
        {
            Provider.Insert(key, value, filePaths);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return Provider.Get(key);
        }

        /// <summary>
        /// 获取缓存实体
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public object Get(string key, Func<object> handler)
        {
            object value = Get(key);
            if (value == null)
            {
                value = handler();
                Insert(key, value);
            }
            return value;
        }

        /// <summary>
        /// 获取缓存实体
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public object Get(string key, Func<object> handler,int seconds)
        {
            object value = Get(key);
            if (value == null)
            {
                value = handler();
                Insert(key, value,seconds);
            }
            return value;
        }

        /// <summary>
        /// 获取缓存实体
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        public object Get(string key,Func<object> handler,string[] filePaths)
        {
            object value = Get(key);
            if (value == null)
            {
                value = handler();
                Insert(key, value,filePaths);
            }
            return value;
        }

        /// <summary>
        /// 获取缓存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)Provider.Get(key);
        }

        /// <summary>
        /// 获取缓存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public T Get<T>(string key, Func<T> handler, int seconds)
        {
            T value = Get<T>(key);
            if (value == null)
            {
                value = handler();
                Insert(key, value, seconds);
            }
            return value;
        }

        /// <summary>
        /// 获取缓存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        public object Get<T>(string key, Func<T> handler, string[] filePaths)
        {
            T value = Get<T>(key);
            if (value == null)
            {
                value = handler();
                Insert(key, value, filePaths);
            }
            return value;
        }
        
    }
}
