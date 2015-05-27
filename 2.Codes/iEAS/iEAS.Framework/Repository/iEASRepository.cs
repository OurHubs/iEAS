using iEAS.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace iEAS.Repository
{
    public class iEASRepository:BaseRepsitory
    {
        public iEASRepository()
        {

        }

        public DbSet<LogInfo> LogInfos { get; set; }
    }
}
