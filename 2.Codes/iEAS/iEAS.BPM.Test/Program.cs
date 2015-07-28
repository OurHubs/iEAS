using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace iEAS.BPM.Test
{

    class Program
    {
        static void Main(string[] args)
        {
            Activity workflow1 = new Workflow1();
            WorkflowApplication instance = new WorkflowApplication(new Workflow1());
            instance.Completed = new Action<WorkflowApplicationCompletedEventArgs>(e =>
            {
                instance = null;
            });
            instance.Run();

            while(true){

                string approver=Console.ReadLine();
                if (approver == "Q")
                    return;

                if (instance!=null)
                {
                    instance.ResumeBookmark("ABC$Approve",approver);
                }
            }
            Console.Read();

        }
    }
}
