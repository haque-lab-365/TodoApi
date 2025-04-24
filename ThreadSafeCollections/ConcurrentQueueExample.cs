using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ThreadSafeCollections
{

    //--The following example shows how to use a ConcurrentQueue<T> to enqueue and dequeue items:
    public class ConcurrentQueueExample
    {
        public ConcurrentQueueExample()
        {
            //--TBD
        }

        public static void CQDemos()
        {
          ConcurrentQueue<int> Cq = new ConcurrentQueue<int>();
          //--Populate the Queu
          for (int i = 0; i < 10000; i++)
          {
                Cq.Enqueue(i);
          }

            // Peek at the first element.
            int result;
            if (!Cq.TryPeek(out result))
            {
                Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
            }
            else if (result != 0)
            {
                Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result);
            }

            int outerSum = 0;
            // An action to consume the ConcurrentQueue.
            Action action = () =>
            {
                int localSum = 0;
                int localValue;
                while (Cq.TryDequeue(out localValue)) localSum += localValue;
                Interlocked.Add(ref outerSum, localSum);
            };

            // Start 4 concurrent consuming actions.
            //--Parallel.Invoke(action, action);
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine("outerSum = {0}, should be 49995000", outerSum);

            //--Peek at the first element

            /*
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    cq.Enqueue(i);
                    Console.WriteLine($"Produced {i}");
                }
            });
            Task.Run(() =>
            {
                int item;
                while (!cq.IsEmpty)
                {
                    if (cq.TryDequeue(out item))
                    {
                        Console.WriteLine($"Consumed {item}");
                    }
                }
            });
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            */
        }

    }
}
