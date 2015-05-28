using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Caching
{
    public interface ICacheProvider
    {
        void Insert(string key, object value);

        void Insert(string key, object value, int seconds);

        void Insert(string key, object value, string[] filePaths);

        object Get(string key);
    }
}
