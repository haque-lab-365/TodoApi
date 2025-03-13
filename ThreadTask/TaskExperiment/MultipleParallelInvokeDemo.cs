using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace ThreadTask.TaskExperiment
{



    /*
    Each Parallel.Invoke call executes multiple actions concurrently.
    Task.Delay is used to simulate time-consuming operations in each action.
    Both Parallel.Invoke calls are independent, and you can see the console logs confirming the execution.
    */
    public static class MultipleParallelInvokeDemo
    {
        public static void ExecuteMultipleParallelInvoke()
        {

            //--Parallel.Invoke(action1, action2, .......actionn)
            try
            {
                Parallel.Invoke(

                    () => //--// Param #1 - lambda expression | Tips: Eacch task should be independent, let's bring mulitple methods.
                    {
                        Console.WriteLine("Action-1 in first parallel");
                        MonitorPorcess();
                        PerformCalculation1();
                    },

                    () =>
                    {
                        Console.WriteLine("Action-2 in first parallel");
                        PerformDataProcessing();
                    }
                );
            }
            catch (AggregateException e) //-- it will be wrapped in AggregateException and propagated to the main thread.
            {
                //--The exception that is thrown when any action in the actions array throws an exception.
                Console.WriteLine("An action has thrown an exception. THIS WAS UNEXPECTED.\n{0}", e.InnerException?.ToString());
            }

            //--Goinng for second Paralle.Invoke method
            try
            {
                Parallel.Invoke(

                    () => //--// Param #1 - lambda expression | Tips: Eacch task should be independent, let's bring mulitple methods.
                    {
                        Console.WriteLine("Action-1 in Second parallel");
                        PerformNetworkRequest();
                    },

                    () =>
                    {
                        Console.WriteLine("Action-2 in Second parallel");
                        PerformFileProcessing();
                    },

                    () =>
                    {
                        Console.WriteLine("Action-3 in Second parallel");
                        PerformLogging();
                    }
                );
            }
            catch (AggregateException e) //-- it will be wrapped in AggregateException and propagated to the main thread.
            {
                //--The exception that is thrown when any action in the actions array throws an exception.
                Console.WriteLine("An action has thrown an exception. THIS WAS UNEXPECTED.\n{0}", e.InnerException?.ToString());
            }


            static void MonitorPorcess()
            {
                //-Get the current process.
                Process currentProcess = Process.GetCurrentProcess();
                Console.WriteLine("The current process is: " + currentProcess.ProcessName);

                //-Get all processes running on the local computer.
                Process[] localAll = Process.GetProcesses();
                Console.WriteLine("The total process running is: " + localAll.Length);

                foreach (Process process in localAll)
                {
                    Console.WriteLine("Process id is:{0}, process name is: {1} ", process.Id, process.ProcessName);
                }
            }

        }

        static void PerformCalculation1()
        {
            Console.WriteLine("Performing calculation...");
            Task.Delay(1000).Wait();
        }
        static void PerformDataProcessing()
        {
            Console.WriteLine("Processing data...");
            Task.Delay(800).Wait();
        }

        static void PerformNetworkRequest()
        {
            Console.WriteLine("Performing network request...");
            Task.Delay(1200).Wait();
        }

        static void PerformFileProcessing()
        {
            Console.WriteLine("Processing file...");
            Task.Delay(700).Wait();
        }

        static void PerformLogging()
        {
            Console.WriteLine("Logging details...");
            Task.Delay(500).Wait();

        }
    }

    //--Parallel.Invoke does not wait for async methods to complete
    //--https://stackoverflow.com/questions/24306620/parallel-invoke-does-not-wait-for-async-methods-to-complete

    /*  A COMPLETE BAD APPROACH  
     
    spinner.IsBusy = true;

     Parallel.Invoke(
        async () => dataX = await Task.Run(() => { return loadX(); }),
        async () => dataY = await Task.Run(() => { return loadY(); }),
        async () => dataZ = await Task.Run(() => { return loadZ(); })
     );

    spinner.isBusy = false;
    ------------------------------------- + ----------------------------------
    //-- A COMPLETE GOOD APPROACH
    spinner.IsBusy = true;
    try
    {
        Task t1 = Task.Run(() => dataX = loadX());
        Task t2 = Task.Run(() => dataY = loadY());
        Task t3 = Task.Run(() => dataZ = loadZ());

        await Task.WhenAll(t1, t2, t3);
    }
    finally
    {
        spinner.IsBusy = false;
    }

    //--Give a deep dive on this.
    //--https://learn.microsoft.com/en-us/archive/blogs/benwilli/tasks-are-still-not-threads-and-async-is-not-parallel
    */
}