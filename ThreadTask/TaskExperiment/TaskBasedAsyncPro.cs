using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTask.TaskExperiment
{
    //--https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming
    //--How to handle exceptions in Parallel.Invoke: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/exception-handling-parallel-invoke
    //--How to handle exceptions in tasks: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/exception-handling-task-parallel-library

    public class TaskBasedAsyncPro
    {

        public TaskBasedAsyncPro() { }
        public TaskBasedAsyncPro(Task task) { }

        //--Creating and running Tasks implicitly
        public void CreateAndRunTaskImlicitly() {
            Parallel.Invoke(() => DoSomeWork(), () => DoSomeOtherWork(), () => DoSomeMath(100));
        }

        //--The number of Task instances that are created behind the scenes by Invoke isn't necessarily equal to the number of delegates that are provided. The TPL might employ various optimizations, especially with large numbers of delegates.

        private void DoSomeWork() 
        {
            Console.WriteLine("Some work started....");
            Console.WriteLine("Doing some work implicitly inside a task..");
            Console.WriteLine("Some task ended");
            Console.WriteLine("--------------------------------INTENTIONAL LINE---------------------");
        }
        private void DoSomeOtherWork() 
        {
            Console.WriteLine("Some Other work started....");
            Console.WriteLine("Doing some other work implicitly inside a task..");
            Console.WriteLine("Some other task ended");
            Console.WriteLine("--------------------------------INTENTIONAL LINE---------------------");
        }

        private void DoSomeMath(int x)
        {
            Console.WriteLine("Started doing math....");
            int mathResult = 0;

            for (int i = 0; i < x; i++)
            {
                mathResult += i;
            }
            Console.WriteLine("Math is done successfully, the reslut is: {0}", mathResult);
            Console.WriteLine("Math Completed");
            Console.WriteLine("--------------------------------INTENTIONAL LINE---------------------");
        }
    }
}
