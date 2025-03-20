using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThread
{
    public class ThreadMaster
    {
        public static void ThreadMethod()
        {
           

        }

        //--The following code example shows how to create a thread that executes a static method.

        public static void ThreadDemo()
        { 
            Thread newThread = new Thread(new ThreadStart(doWork));
            newThread.Name = "Worker Thread";
            ShowThreadMeta(newThread);
            //--A thread does not begin executing when it is created. To schedule the thread for execution, call the Start method.
            newThread.Start();
            //--ShowThreadMeta(newThread);

            //--The following code example shows how to create a thread that executes an instance method.
            ForceWorker forceWorker = new ForceWorker();
            Thread newThread2 = new Thread(new ThreadStart(forceWorker.DoMoreWork));
            newThread2.Name = "Force Worker Thread";
            newThread2.Start();
            //--ShowThreadMeta(newThread2);


        }

        public static void doWork()
        {
            Console.WriteLine("Working thread...");
            for(int i = 0; i < 100; i++)
            {
                //--Console.WriteLine("Working thread...{0}", i);
                Console.WriteLine($"Working thread...{i:c2}");
                Thread.Sleep(1000);
            }
        }

        public static void ShowThreadMeta(Thread threadInstance)
        {
            var threadId = threadInstance.ManagedThreadId;
            var threadName = threadInstance.Name;
            var threadPriority = threadInstance.Priority;
            var threadState = threadInstance.ThreadState;   
            var threadIsBackground = threadInstance.IsBackground;
            var threadIsThreadPoolThread = threadInstance.IsThreadPoolThread;
            var threadApartmentState = threadInstance.GetApartmentState();
            //--var threadCurrentCulture = threadInstance.CurrentCulture;
            //--var threadCurrentUICulture = threadInstance.CurrentUICulture;
            var threadExecutionContext = threadInstance.ExecutionContext;

            string threadMeta = $"Thread name is: {threadName}. \n Managed Thread Id is: {threadId}.";
            Console.WriteLine(threadMeta);
            //--var thredMeta = new StringBuilder();
        }
    }

    class ForceWorker
    {
        public void DoMoreWork()
        {
            Console.WriteLine("Working thread...");
            for (int i = 0; i < 100; i++)
            {
                //--Console.WriteLine("Working thread...{0}", i);
                Console.WriteLine($"Forced to work thread...{i:c}");
                Thread.Sleep(1000);
            }
        }
    }
}
