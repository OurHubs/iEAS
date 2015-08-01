using System;
using System.Activities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class WorkflowEngine
    {
        private static WorkflowEngine _Current;
        private Dictionary<Guid, WorkflowApplication> Applications = new Dictionary<Guid, WorkflowApplication>();

        private WorkflowEngine()
        {

        }

        public static WorkflowEngine Current
        {
            get
            {
                if (_Current == null)
                {
                    lock (typeof(WorkflowEngine))
                    {
                        if(_Current==null)
                        {
                            _Current = new WorkflowEngine();
                        }
                    }
                }
                return _Current;
            }
        }

        public Guid StartFlow()
        {
            System.Activities.Activity activity = new Test();
            WorkflowApplication application = new WorkflowApplication(activity);
            RegisterEvents(application);
            this.Applications.Add(application.Id, application);
            application.Run();
            return application.Id;
        }

        public void ExecuteFlow(Guid id,string activity)
        {
            string activityAction = activity + "$Action";
            Applications[id].ResumeBookmark(activityAction,null);
        }

        private void RegisterEvents(WorkflowApplication application)
        {
            application.Completed += OnCompleted;
        }

        private void OnCompleted(WorkflowApplicationCompletedEventArgs args)
        {
            using (var rep = new BPMRepository())
            {
                var instance=rep.ProcessInstance.FirstOrDefault(m => m.ApplicationId == args.InstanceId);
                instance.State = 2;
                rep.SaveChanges();
            }

            Console.WriteLine("============================Begin===================================");

            Console.WriteLine("完成:");
            Console.WriteLine("Id:{0}", args.InstanceId);
            Console.WriteLine("完成状态:{0}", args.CompletionState);

            Console.WriteLine("============================End===================================");
        }
    }
}
