using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThread
{

    //--Write me a c# code for the following Example:
    //--Processing large datasets where one thread splits the data and spawns child threads to handle smaller chunks.
    public class ParentChildThread
    {


        public static void ParentChildThreadDemo()
        {
            Console.WriteLine("Processing large dataset using threads...");

            // Example: Large dataset of integers
            List<int> largeDataset = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                largeDataset.Add(i);
            }

            // Split the dataset into chunks
            int chunkSize = 20; // Process 20 items per thread
            int numberOfChunks = (largeDataset.Count + chunkSize - 1) / chunkSize;

            List<Thread> threads = new List<Thread>();

            for (int chunkIndex = 0; chunkIndex < numberOfChunks; chunkIndex++)
            {
                int start = chunkIndex * chunkSize;
                int end = Math.Min(start + chunkSize, largeDataset.Count);

                // Get the chunk for this thread
                List<int> chunk = largeDataset.GetRange(start, end - start);

                // Create a new thread to process this chunk
                Thread thread = new Thread(() => ProcessChunk(chunk));
                threads.Add(thread);
                thread.Start();
            }

            // Wait for all threads to complete
            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("Processing completed.");
        }

        static void ProcessChunk(List<int> chunk)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} processing chunk...");
            foreach (var item in chunk)
            {
                // Simulate work (e.g., heavy computation)
                Thread.Sleep(100); // Simulate delay
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} processed: {item}");
            }
        }
    }
}
