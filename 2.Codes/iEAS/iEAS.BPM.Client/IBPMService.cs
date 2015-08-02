using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace iEAS.BPM.Client
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IBPMService”。
    [ServiceContract]
    public interface IBPMService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        ProcessInstance CreateProcessInstance(string processCode);

        [OperationContract]
        ProcessInstance SubmitProcessInstance(ProcessInstance instance);

        [OperationContract]
        void ExecuteWorklistItem(WorklistItem worklistItem);

        [OperationContract]
        Process GetProcess(string processCode);
        [OperationContract]
        WorklistItem OpenWorklistItem(string sn, string impersonator);

        [OperationContract]
        Worklist OpenWorklist(string impersonator);
    }
}
