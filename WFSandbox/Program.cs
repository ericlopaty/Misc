using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace WFSandbox
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting");
            
            //WorkflowInvoker.Invoke(new Workflow1());

            Workflow1 wf = new Workflow1();

            WorkflowApplication wfApp = new WorkflowApplication(wf);
            wfApp.BeginRun();

            Console.WriteLine("finished");
            Console.ReadLine();
        }
    }
}
