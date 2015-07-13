using iEAS.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Config
{
    public class SiteConfig
    {
        private static SiteConfig _Instance;

        public static SiteConfig Instance
        {
            get
            {
                if(_Instance==null)
                {
                    string path=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config/Site.Config");
                    _Instance = XmlHelper.Deserialize<SiteConfig>(path);
                }
                return _Instance;
            }
        }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Template { get; set; }

        public string WeiBoUrl { get; set; }

        public string Administrator { get; set; }

        public string Password { get; set; }
    }
}
