using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//--https://learn.microsoft.com/en-us/dotnet/standard/collections/thread-safe/blockingcollection-overview
namespace ThreadSafeCollections
{
    public class BlockingCollectionExample
    {
        public static void BCDemos()
        {
            BlockingCollection<int> bc = new BlockingCollection<int>(boundedCapacity: 5);
            
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    bc.Add(i);
                    Console.WriteLine($"Produced {i}");
                }
                bc.CompleteAdding();
            });

            Task.Run(() =>
            {
                while (!bc.IsCompleted)
                {
                    int item = 0;
                    if (bc.TryTake(out item))
                    {
                        Console.WriteLine($"Consumed {item}");
                    }
                }
            });

            Task.Run(() =>
            {
                while (!bc.IsCompleted)
                {
                    int item = bc.Take();
                    Console.WriteLine($"Consumed {item}");
                }
            });

            Task.Run(() =>
            {
                foreach (var item in bc.GetConsumingEnumerable())
                {
                    Console.WriteLine($"Consumed {item}");
                }
            });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
