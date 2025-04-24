using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTask.TaskRaceExperiment
{
    public class TaskRace
    {
        static int sharedCounter = 0;
        static readonly object lockObject = new object();
        public static void BunchofTasks()
        {
            Task t1 = new Task(() => Console.WriteLine("I am Task 1"));
            Task t2 = new Task(() => Console.WriteLine("I am Task 2"));
            Task t3 = new Task(() => Console.WriteLine("I am Task 3"));
            Task t4 = new Task(() => Console.WriteLine("I am Task 4"));
            Task t5 = new Task(() => Console.WriteLine("I am Task 5"));
            Task t6 = new Task(() => Console.WriteLine("I am Task 6"));
            Task t7 = new Task(() => Console.WriteLine("I am Task 7"));
            Task t8 = new Task(() => Console.WriteLine("I am Task 8"));
            Task t9 = new Task(() => Console.WriteLine("I am Task 9"));
            Task t10 = new Task(() => Console.WriteLine("I am Task 10"));
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();
            t8.Start();
            t9.Start();
            t10.Start();
            Task.WaitAll(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        }
        /// <summary>
        /// We can use delegagte method inside the invoke if we don't have to depend on any results.
        /// </summary>
        public void InvokeDifferently()
        {
            Parallel.Invoke(
                
                delegate ()
                {
                    Console.WriteLine("All is well - Going to collect 30 rows");
                    Console.WriteLine($"The tick is {DateTime.Now.Ticks}");
                    Thread.Sleep(1000);
                },

                delegate ()
                {
                    Console.WriteLine("All is well - Going to collect 50K rows");
                    Console.WriteLine($"The tick is {DateTime.Now.Ticks}");
                    Thread.Sleep(1000);
                },

                delegate ()
                {
                    Console.WriteLine("All is well - Going to collect 60K rows");
                    Console.WriteLine($"The tick is {DateTime.Now.Ticks}");
                    Thread.Sleep(1000);
                }
            ); 
        
        
        }
        public static async Task RaceTask()
        { 
           Task task1 = Task.Run(() => IncrementCounter1());
           Task task2 = Task.Run(() => IncrementCounter1());     
           
           await Task.WhenAll(task1, task2);    

           Console.WriteLine($"Final counter value: {sharedCounter}");
            // Output may vary due to race conditions

        }
        /// <summary>
        /// Increment the shared counter by 1000
        /// Call this function if want to see the race condition
        /// </summary>
        private static void IncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                sharedCounter++; // No synchronization, leads to race condition               
            }
        }

        private static void IncrementCounter1()
        {
            for (int i = 0; i < 10; i++)
            {                
                lock (lockObject)
                {
                    //--Thread.Sleep(1000);
                    sharedCounter++; // No synchronization, leads to race condition               
                }
                
            }
        }
    }
}
