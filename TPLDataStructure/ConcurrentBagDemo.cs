using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLDataStructure
{
    public class ConcurrentBagDemo
    {
        public ConcurrentBagDemo() { } 
        public ConcurrentBagDemo(int capacity) { }

        // Demonstrates:
        //      ConcurrentBag<T>.Add333333333333333
        //      ConcurrentBag<T>.IsEmpty
        //      ConcurrentBag<T>.T/'ryTake()
        //      ConcurrentBag<T>.TryPeek()

        static void Main()
        {
            // Add to ConcurrentBag concurrently
            ConcurrentBag<int> cbag = new ConcurrentBag<int>();
            List<Task> bagAddTasks = new List<Task>();

            for (int i = 0; i < 500; i++)
            {
                var numberToAdd = i;
                bagAddTasks.Add(Task.Run(() => cbag.Add(numberToAdd)));
            }

            // Wait for all tasks to complete
            Task.WaitAll(bagAddTasks.ToArray());

            // Consume the items in the bag
            List<Task> bagConsumeTasks = new List<Task>();
            int itemsInBag = 0;
            while (!cbag.IsEmpty)
            {
                bagConsumeTasks.Add(Task.Run(() =>
                {
                    int item;
                    if (cbag.TryTake(out item))
                    {
                        Console.WriteLine(item);
                        Interlocked.Increment(ref itemsInBag);
                    }
                }));
            }
            Task.WaitAll(bagConsumeTasks.ToArray());

            Console.WriteLine($"There were {itemsInBag} items in the bag");

            // Checks the bag for an item
            // The bag should be empty and this should not print anything
            int unexpectedItem;

            if (cbag.TryPeek(out unexpectedItem))
                Console.WriteLine("Found an item in the bag when it should be empty");
        }
    }
}
