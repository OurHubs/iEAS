using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace iEAS.Caching
{
    public class HttpCacheProvider:ICacheProvider
    {
        private Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }
        public void Insert(string key, object value)
        {
            Cache.Insert(key, value);
        }
        public void Insert(string key, object value, int seconds)
        {
            Cache.Insert(key, value, null, DateTime.Now.AddSeconds(seconds), TimeSpan.Zero);
        }
        public void Insert(string key, object value, string[] filePaths)
        {
            Cache.Insert(key, value, new CacheDependency(filePaths));
        }
        public object Get(string key)
        {
            return Cache.Get(key);
        }
        public void Remove(string key)
        {
            Cache.Remove(key);
        }
    }
}
