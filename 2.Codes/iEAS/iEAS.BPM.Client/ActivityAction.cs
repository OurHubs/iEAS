using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Client
{
    public class ActivityAction
    {
        internal IBPMService Service { get; set; }

        public string Name { get; set; }

        public WorklistItem WorklistItem { get; set; }

        public void Execute()
        {
            //Service.ExecuteWorklistItem(this);
        }
    }
}
