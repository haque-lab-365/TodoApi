using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//--https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
namespace AsyncAwaitExperiment
{

    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }
    internal class ServeBreakFast { }
    internal class CleanTable { }


    //--Enable code that reads like a sequence of statements, but executes in a much more complicated order based on external
    //--resource allocation and when tasks are complete.It's analogous to how people give instructions for processes that include
    //--asynchronous tasks.
    internal class InitAsyncAwat
    {

        public static void PrepareBreakFast()
        {

            

        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("Cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();

        }
        private static Egg FryEggs(int howMnay)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Cracking {howMnay} eggs..");
            Console.WriteLine("Cooking the eggs....");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        private static Coffee PourCoffee() 
        {
            Console.WriteLine("Pouring coffee, be carefull.. its tooo hot.");
            return new Coffee();
        }
    }

    //-- POC Needed(Takeways): Task.Delay(n).Wait() will block the current thread until the task is completed,
    //-- whereas await Task.Delay(n) will be awaited without blocking the thread.

    //--you'll use an example of instructions for making breakfast to see how the async and await keywords make it easier to reason
    //--about code that includes a series of asynchronous instructions. You'd write the instructions something like the following list
    //--to explain how to make a breakfast:
}
