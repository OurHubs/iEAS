using iEAS.Domain;
using iEAS.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace iEAS.Repository
{
    public class iEASRepository:BaseRepository
    {
        public iEASRepository()
        {

        }

        public DbSet<LogInfo> LogInfos { get; set; }
    }
}
