using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Task t = new Task(() => { Console.WriteLine("I am a single task! I am created by Task Action lambda constructor"); });
            t.Start();
        }

        public static void TaskHero1()
        {
            Task t = new Task(() => doSomeTask());
        
        }


        //--The following example uses the Task(Action) constructor to create tasks that retrieve the filenames in specified directories. 
        public static async Task DoTasks()
        {
            string[] dirNames = { ".", ".." };
            //-All tasks write the file names to a single ConcurrentBag<T> object. 
            var cblist = new ConcurrentBag<string>();
            List<Task> tasks = new List<Task>();
            foreach (var dirName in dirNames) 
            {
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
