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
                inst.State = 0;
                inst.ApplicationId = application.Id;
                rep.SaveChanges();
                instance.State = 0;
            }
            application.Run();
            return instance;
        }

        public Client.Process GetProcess(string processCode)
        {
            Client.Process result = new Client.Process();

            using (var rep = new BPMRepository())
            {
                var process = rep.Process.Include("Activities").FirstOrDefault(m => m.Code == processCode);
                result.Code = process.Code;
                result.Id = process.Id;
                result.Name = process.Name;
               
                List<Client.Activity> activities = new List<Client.Activity>();
                foreach (var item in process.Activities)
                {
                    var act = new Client.Activity();
                    act.Id = item.Id;
                    act.Name = item.Name;
                    act.DestinationType = (Client.DestinationType)Enum.Parse(typeof(Client.DestinationType), item.DestinationType.ToString());
                    act.Destination = item.Destination;
                    activities.Add(act);
                }
                result.Activities = activities;
            }

            return result;
        }


    }
}
