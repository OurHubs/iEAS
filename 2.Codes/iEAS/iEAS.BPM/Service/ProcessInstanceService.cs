using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class ProcessInstanceService : IProcessInstanceService
    {
        public ProcessInstance CreateProcessInstance(string processCode)
        {
            return new ProcessInstance();
        }
        public void SubmitProcessInstance()
        {
            throw new NotImplementedException();
        }
    }
}
