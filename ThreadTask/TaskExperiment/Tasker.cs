using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


//-- Code documentation stuff -  a must read article.
//--https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/?redirectedfrom=MSDN 
//--https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming
//--Creating and running tasks explicitly
//-- 


//--Creating and running tasks explicitly
namespace ThreadTask.TaskExperiment
{
    public  class Tasker
    {

        public static void doSomeTask()
        {
            Console.WriteLine("I am doing some work for Task Hero-1");
        }
        public static void TaskHero()
        {
            Task t = new Task( () => { Console.WriteLine("I am a single task! I am created by Task Action lambda constructor"); });
            t.Start();
        }


        //-- When you create a task, you give it a user delegate that encapsulates the code that the task will execute.
        //-- The delegate can be expressed as a named delegate, an anonymous method, or a lambda expression.
        //-- Lambda expressions can contain a call to a named method (e.g doSomeTask()), as shown in the following example.
        //-- The example includes a call to the Task.Wait method to ensure that the task completes execution before the console mode application ends.
        public static void TaskHero1()
        {
            //--Let's name the current tread
            Thread.CurrentThread.Name = "TaskHero1";

            //--Create a task and supply a user delegate by using a lambda expression.
            //--Task taskHero1 = new Task(() => Console.WriteLine("Task-A starting... going to execute. now"));
            Task taskHero1 = new Task( ()=> doSomeTask());
            //--Start the task.
            taskHero1.Start();

            //--Output a message from the calling thread.
            Console.WriteLine($"Hello from thread '{Thread.CurrentThread.Name}'.");
            taskHero1.Wait();
        }


   
        /// <summary>
        /// The following example uses the Task(Action) constructor to create tasks that retrieve the filenames in specified directories. 
        /// </summary>
        /// <returns>Returns nothong but fills a list with the file names for the given directory</returns>
        public static async Task DoTasks()
        {
            string[] dirNames = { ".", ".." };
            //-All tasks write the file names to a single ConcurrentBag<T> object. 
            var cblist = new ConcurrentBag<string>();
            List<Task> tasks = new List<Task>();
            foreach (var dirName in dirNames) 
            {
                //--Running an anonymous function in a task, storing the task in a list, and then waiting for all tasks to complete.
                Task tsk = new Task( () => {
                    foreach (var path in Directory.GetFiles(dirName))
                    {
                        cblist.Add(path);
                        Console.WriteLine(path); //--expensive
                    }
                });

                tasks.Add(tsk);
                tsk.Start();
            }

            await Task.WhenAll(tasks.ToArray());
            foreach (Task t in tasks)
                Console.WriteLine("Task {0} Status {1}", t.Id, t.Status);

            Console.WriteLine("Number of files read: {0}", cblist.Count);
            //--https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.-ctor?view=net-9.0#system-threading-tasks-task-ctor(system-action)
        }

        //--https://learn.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/
    }
}
