using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public interface IProcessInstanceService
    {
        ProcessInstance CreateProcessInstance(string processCode);

        void SubmitProcessInstance();
    }
}
