using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Log
{
    public class LogInfo
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public string ModuleCode { get; set; }

        public string ModuleName { get; set; }

        public string Message { get; set; }

        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
