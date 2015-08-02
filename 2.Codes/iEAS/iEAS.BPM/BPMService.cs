using iEAS.BPM.Client;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace iEAS.BPM
{
    public class BPMService : IBPMService
    {
        public void DoWork()
        {
            Console.WriteLine("Hello DoWork!");
        }

        public Client.ProcessInstance CreateProcessInstance(string processCode)
        {
            Client.ProcessInstance result = new Client.ProcessInstance();
            result.Process = GetProcess(processCode);
            using(var req=new BPMRepository())
            {
                ProcessInstance inst = new ProcessInstance();
                inst.ProcessId = result.Process.Id;
                req.ProcessInstance.Add(inst);
                req.SaveChanges();

                result.Id = inst.Id;
            }
            return result;
        }

        public Client.ProcessInstance SubmitProcessInstance(Client.ProcessInstance instance)
        {
            WorkflowApplication application = WorkflowEngine.Current.CreateFlow(instance.Process.Code);

            using (var rep = new BPMRepository())
            {
                var inst = rep.ProcessInstance.FirstOrDefault(m => m.Id == instance.Id);
                inst.Folio = instance.Folio;
                inst.Originator = inst.Originator;
                inst.State = 0;
                inst.ApplicationId = application.Id;
                rep.SaveChanges();
                instance.State = 0;
            }
            application.Run();
            return instance;
        }
        public void ExecuteWorklistItem(Client.WorklistItem worklistItem)
        {
            Guid applicationId = worklistItem.ProcessInstance.ApplicationId;
            using(var rep=new BPMRepository())
            {
                var actInst=rep.ActivityInstanceDestination.FirstOrDefault(m => m.ActivityInstanceId == worklistItem.ActivityInstance.Id && m.Approver==worklistItem.Approver);
                actInst.Deleted = true;
                rep.SaveChanges();
            }
            WorkflowEngine.Current.ExecuteFlow(worklistItem);
        }
        public Client.WorklistItem OpenWorklistItem(string sn, string impersonator)
        {
            Client.WorklistItem result = new Client.WorklistItem();
            result.SN = sn;

            string[] strs = sn.Split('_');
            int procInstId = int.Parse(strs[0]);
            int actInstId = int.Parse(strs[1]);
            using(var req=new BPMRepository())
            {
                var aid=req.ActivityInstanceDestination.FirstOrDefault(m => m.ActivityInstanceId == actInstId && m.Approver==impersonator);
                if(aid==null)
                {
                    Console.WriteLine("当前刻录不存在SN={0},Approver={1}", sn, impersonator);
                    return null;
                }
                result.ActivityInstance = GetClientActivityInstance(aid.ActivityInstance);
                result.ProcessInstance = GetClientProcessInstance(aid.ProcessInstance);
                result.Folio = result.ProcessInstance.Folio;
                result.SN = sn;
                result.TargetApprover = aid.TargetApprover;
                result.Approver = aid.Approver;
            }

            return result;
        }


        public Client.Worklist OpenWorklist(string impersonator)
        {
            List<Client.WorklistItem> items = new List<Client.WorklistItem>();
            using(var req=new BPMRepository())
            {
                var destinations=req.ActivityInstanceDestination.Where(m => m.Approver == impersonator && !m.Deleted);
                foreach(var item in destinations)
                {
                    Client.WorklistItem worklistItem = new Client.WorklistItem();
                    worklistItem.ActivityInstance = GetClientActivityInstance(item.ActivityInstance);
                    worklistItem.ProcessInstance = GetClientProcessInstance(item.ProcessInstance);
                    worklistItem.Approver = impersonator;
                    worklistItem.Folio = worklistItem.ProcessInstance.Folio;
                    worklistItem.SN = worklistItem.ProcessInstance.Id + "_" + worklistItem.ActivityInstance.Id;
                    worklistItem.TargetApprover = item.TargetApprover;

                    items.Add(worklistItem);
                }
            }
            return new Worklist(items);
        }

        #region 转化为客户端数据
        public Client.Process GetProcess(string processCode)
        {
            Client.Process result = new Client.Process();

            using (var rep = new BPMRepository())
            {
                var process = rep.Process.Include("Activities").FirstOrDefault(m => m.Code == processCode);
                result = GetClientProcess(process);
            }

            return result;
        }

        private Client.ActivityInstance GetClientActivityInstance(ActivityInstance actInst)
        {
            Client.ActivityInstance result = new Client.ActivityInstance();
            result.Id = actInst.Id;
            result.Name = actInst.ActivityName;
            result.Activity = GetClientActivity(actInst.Activity);

            return result;
        }

        private Client.ProcessInstance GetClientProcessInstance(ProcessInstance procInst)
        {
            Client.ProcessInstance result = new Client.ProcessInstance();
            result.Id = procInst.Id;
            result.Folio = procInst.Folio;
            result.ApplicationId = procInst.ApplicationId;
            result.Process = GetClientProcess(procInst.Process);

            return result;
        }
    
        private Client.Process GetClientProcess(Process process)
        {
            Client.Process result = new Client.Process();
                result.Code = process.Code;
                result.Id = process.Id;
                result.Name = process.Name;

            List<Client.Activity> activities = new List<Client.Activity>();
            foreach (var item in process.Activities)
            {
                var act = GetClientActivity(item);
                activities.Add(act);
            }
            result.Activities = activities;

            return result;
        }

        private Client.Activity GetClientActivity(Activity activity)
        {
            Client.Activity result = new Client.Activity();
            result.Id = activity.Id;
            result.Name = activity.Name;
            result.DestinationType = (Client.DestinationType)Enum.Parse(typeof(Client.DestinationType), activity.DestinationType.ToString());
            result.Destination = activity.Destination;

            return result;
        }
        #endregion
    }
}
