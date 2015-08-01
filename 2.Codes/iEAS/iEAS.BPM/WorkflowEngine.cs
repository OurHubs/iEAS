using System;
using System.Activities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities.DurableInstancing;
using System.Configuration;

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
            application.Run();
            return application.Id;
        }

        public void ExecuteFlow(Guid id,string activity)
        {
            System.Activities.Activity act = new Test();
            WorkflowApplication application = new WorkflowApplication(act);
            RegisterEvents(application);
            application.Load(id);

            string activityAction = activity + "$Action";
            application.ResumeBookmark(activityAction, null);
        }

        private void RegisterEvents(WorkflowApplication application)
        {
            application.InstanceStore = InstanceStore;
            application.Completed = OnCompleted;
            application.Idle = OnIdle;
            application.PersistableIdle = OnPersistableIdle;
            application.Unloaded = OnUnloaded;
        }

        private void OnUnloaded(WorkflowApplicationEventArgs args)
        {
            Console.WriteLine("============================Begin===================================");

            Console.WriteLine("Onloaded:");
            Console.WriteLine("Id:{0}", args.InstanceId);
            Console.WriteLine("============================End===================================");
        }

        private PersistableIdleAction OnPersistableIdle(WorkflowApplicationIdleEventArgs args)
        {
            Console.WriteLine("============================Begin===================================");

            Console.WriteLine("PersistableIdle:");
            Console.WriteLine("Id:{0}", args.InstanceId);
            Console.WriteLine("Bookmarks:");
            foreach(var bookmark in args.Bookmarks)
            {
                Console.WriteLine(bookmark.BookmarkName);
            }

            Console.WriteLine("============================End===================================");

            return PersistableIdleAction.Unload;
        }

        private void OnIdle(WorkflowApplicationIdleEventArgs args)
        {
            Console.WriteLine("============================Begin===================================");

            Console.WriteLine("Idle:");
            Console.WriteLine("Id:{0}", args.InstanceId);

            Console.WriteLine("============================End===================================");
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

        private SqlWorkflowInstanceStore _InstanceStore;
        private SqlWorkflowInstanceStore InstanceStore
        {
            get
            {
                if(_InstanceStore==null)
                {
                    lock(this)
                    {
                        if(_InstanceStore==null)
                        {
                            string connStr = ConfigurationManager.ConnectionStrings["iBPMConn"].ConnectionString;
                            _InstanceStore = new SqlWorkflowInstanceStore(connStr);
                            var instanceView = _InstanceStore.Execute(_InstanceStore.CreateInstanceHandle(), new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(30));
                            _InstanceStore.DefaultInstanceOwner = instanceView.InstanceOwner;
                        }
                    }
                }
                return _InstanceStore;
            }
        }
    }
}
