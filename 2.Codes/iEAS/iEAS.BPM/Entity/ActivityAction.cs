using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Entity
{
    public class ActivityAction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PassType PassType { get;set;}

        public int PasseNumber { get; set; }
    }

    public enum PassType
    {
        All=0,
        AtLeast
    }
}
