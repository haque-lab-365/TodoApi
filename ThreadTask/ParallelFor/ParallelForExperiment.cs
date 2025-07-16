using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTask.ParallelFor
{

    //--Source: https://dotnettutorials.net/lesson/parallel-for-method-csharp/
    //--Source: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-cancel-a-parallel-for-or-foreach-loop
    public class ParallelForExperiment
    {

        static int N = 20;

        public static void ParallelFor()
        {
            //--Use a name method with Parallel.For.
            Parallel.For(0, N, DoWork);
            
            //-- Using an anonymous method/Delegate.
            Parallel.For(0, N, delegate (int i)
            {
                // Do Work.
                Console.WriteLine($"Anonymous Method Call: The math is simple {i * i}, Managed thread ID: {Thread.CurrentThread.ManagedThreadId} ");
            });

            // Using a lambda expression.
            Parallel.For(0, N, i =>
            {
                // Do Work.
                Console.WriteLine($"Lambda expression call: The math is simple {i * i}, Managed thread ID: {Thread.CurrentThread.ManagedThreadId} ");
            });

        }
        public static void ParalleForInAction()
        {

            //--This Parallel.For option uses a lamda expression along with parallel count
            Parallel.For(0, 100, n => {
                Console.WriteLine($"Processing number {n} on thread {Environment.CurrentManagedThreadId}");
            });

            //--This is a simple example of using Parallel.For to iterate over a range of numbers and print them.
            //--Parallel.For is used to execute a loop in parallel, which can improve performance for CPU-bound operations.
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"Processing item {i} on thread {Environment.CurrentManagedThreadId}");
                Thread.Sleep(100); // Simulate some work
            });

            Console.ReadLine();

        }


        public static void ParalleForInActionDifference()
        {
            Console.WriteLine("Standard C# For Loop - Sequential(syncrhonous), single threaded");
            int number = 10;
            for (int count = 0; count < number; count++)
            {
                Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            }

            Console.WriteLine("Parallel For Loop - Not sequential(Asnychronous), multi-thread");
            Parallel.For(0, number, count =>
            {
                Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });

            Console.ReadLine();
        }


        public static void ParalleForInActionPerformance()
        {
            //--Experimenting standard for loop
            DateTime startDateTime = DateTime.Now;
            Stopwatch forLoopStopWatch = Stopwatch.StartNew();
            Console.WriteLine("Parallel For Loop Execution start");
            forLoopStopWatch.Start();


            for (int i = 0; i < 10; i++)
            {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1} | Thread ID {2}", i, total, Thread.CurrentThread.ManagedThreadId);
            }
            DateTime endDateTime = DateTime.Now;
            Console.WriteLine("For Loop Execution end ");
            forLoopStopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute the Standard For Loop in miliseconds {forLoopStopWatch.ElapsedMilliseconds}");



            //--Experimenting parallel for loop
            DateTime plStartDateTime = DateTime.Now;
            Stopwatch plStopWatch = Stopwatch.StartNew();
            Console.WriteLine("Parallel For Loop Execution start");
            plStopWatch.Start();

            Parallel.For(0, 10, i => {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1} | Thread ID:{2} ", i, total, Thread.CurrentThread.ManagedThreadId);
            });

            DateTime plEndDateTime = DateTime.Now;
            Console.WriteLine("Parallel For Loop Execution end ");
            plStopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {plStopWatch.ElapsedMilliseconds}");


            Console.ReadLine();
        }

        /// <summary>
        /// ParallelOptions | MaxDegreeOfParallelism, applicabel for Parallel.For and Parallel.ForEach 
        /// </summary>
        public static void ParrellelForInActionDegreeofParallelism()
        {
            //--Experimenting parallel for loop
            DateTime plStartDateTime = DateTime.Now;
            Stopwatch plStopWatch = Stopwatch.StartNew();

            ParallelOptions parallelOptions = new()
            {
                MaxDegreeOfParallelism = 2 //-- Number of threads used to execute the code.
            };


            Console.WriteLine("Parallel For Loop Execution start");
            plStopWatch.Start();

            Parallel.For(0, 10, parallelOptions, i => {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1} | Thread ID:{2} ", i, total, Thread.CurrentThread.ManagedThreadId);
            });

            DateTime plEndDateTime = DateTime.Now;
            Console.WriteLine("Parallel For Loop Execution end ");
            plStopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {plStopWatch.ElapsedMilliseconds}");
            Console.ReadLine();


        }

        /// <summary>
        /// ParallelOptions | MaxDegreeOfParallelism, applicabel for Parallel.For and Parallel.ForEach 
        /// ParallelOptions | CancellationToken  CTS, applicabel for Parallel.For and Parallel.ForEach
        /// ParallelOptions | TaskScheduler = TaskScheduler.Default??
        /// </summary>
        public static void ParrellelForInActionParallelOptions()
        {
            //--Experimenting parallel for loop
            DateTime plStartDateTime = DateTime.Now;
            Stopwatch plStopWatch = Stopwatch.StartNew();

            CancellationTokenSource cts = new();

            ParallelOptions parallelOptions = new()
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = 2, //-- Number of threads used to execute the code.
                TaskScheduler = TaskScheduler.Default
            };


            Console.WriteLine("Parallel For Loop Execution start");
            plStopWatch.Start();

            Parallel.For(0, 10, parallelOptions, i => {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1} | Thread ID:{2} ", i, total, Thread.CurrentThread.ManagedThreadId);
            });

            DateTime plEndDateTime = DateTime.Now;
            Console.WriteLine("Parallel For Loop Execution end ");
            plStopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {plStopWatch.ElapsedMilliseconds}");


            Console.ReadLine();


        }

        //--How to: Cancel a Parallel.For or ForEach Loop | https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-cancel-a-parallel-for-or-foreach-loop
        public static void ParrellelForInActionParallelOptionsCancellation()
        { 
            int[] nums = Enumerable.Range(0, 10_000_000).ToArray();
            CancellationTokenSource cts = new();

            // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions options = new()
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount,
                TaskScheduler = TaskScheduler.Default
            };
            Console.WriteLine("Press any key to start. Press 'c' to cancel.");
            Console.ReadKey();

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar is 'c')
                    cts.Cancel();
                Console.WriteLine("press any key to exit");
            });

            try
            {
                Parallel.ForEach(nums, options, (num) =>
                {
                    double d = Math.Sqrt(num);
                    Console.WriteLine($"{d} on {Environment.CurrentManagedThreadId}");
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }

            Console.ReadKey();

        }


        /// <summary>
        /// This method calculates the total size of all files in a specified directory using parallel processing.
        /// Method signature base on Parallel.For(Int64, Int64, Action<Int64>)
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        public static void GetDirectoryFileSize(string filePath)
        {
            long totalSize = 0;

            ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));

            if (!System.IO.Directory.Exists(filePath))
            {
                throw new System.IO.DirectoryNotFoundException($"The directory '{filePath}' does not exist.");
            }   

            string[] files = Directory.GetFiles(filePath);

            Parallel.For(0, files.Length, index => { FileInfo fileInfo = new FileInfo(files[index]);
                           long fileSize = fileInfo.Length;
                           //--Console.WriteLine($"File: {fileInfo.Name}, Size: {fileSize} bytes");
                           Interlocked.Add(ref totalSize, fileSize); // Safely add to total size
            });

            Console.WriteLine($"Directory '{filePath}':");
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }

        /// <summary>
        /// Suppose to be a long running task. 
        /// </summary>
        /// <returns></returns>
        static long DoSomeIndependentTask()
        {
            //--Do Some Time Consuming Task here
            //--Most Probably some calculation or DB related activity
            
            long total = 0;
            for (int i = 1; i < 100000000; i++)
            {
                total += i;
            }
            return total;
        }

        static void DoWork(int i)
        {
            Console.WriteLine($"The math is simple {i * i}, Managed thread ID: {Thread.CurrentThread.ManagedThreadId} ");
        }
    }
}
