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
    public class ParallelForExperiment
    {


        public static void ParalleForInAction()
        {


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
                Console.WriteLine("{0} - {1}", i, total);
            }
            DateTime endDateTime = DateTime.Now;
            Console.WriteLine("For Loop Execution end ");
            forLoopStopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute the For Loop in miliseconds {forLoopStopWatch.ElapsedMilliseconds}");



            //--Experimenting parallel for loop
            //--Experimenting standard for loop
            DateTime plStartDateTime = DateTime.Now;
            Stopwatch plStopWatch = Stopwatch.StartNew();
            Console.WriteLine("Parallel For Loop Execution start");
            plStopWatch.Start();

            Parallel.For(0, 10, i => {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1}", i, total);
            });

            DateTime plEndDateTime = DateTime.Now;
            Console.WriteLine("Parallel For Loop Execution end ");
            plStopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {plStopWatch.ElapsedMilliseconds}");


            Console.ReadLine();
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
    }
}
