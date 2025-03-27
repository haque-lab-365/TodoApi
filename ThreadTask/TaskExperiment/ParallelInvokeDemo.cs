using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTask.TaskExperiment
{
    public static class ParallelInvokeDemo
    {


        //--Background: his example demonstrates how to use the Invoke method with other methods, anonymous delegates, and lambda expressions.
        //-- Invoke(Action[]) | Executes each of the provided actions, possibly in parallel.
        //-- Signature: public static void Invoke(params Action[] actions); 

        public static void ExecuteParallelInvoke()
        {
            try
            {
                Parallel.Invoke(
                    BasicAction,	// Param #0 - static method
                    BasicThreadSummary, //// Param #0 - static method
                    () =>			// Param #1 - lambda expression
                    {
                        Console.WriteLine("Method=beta, Thread={0}", Thread.CurrentThread.ManagedThreadId);
                    },
                    delegate ()		// Param #2 - in-line delegate | anonymous delegates?
                    {
                        Console.WriteLine("Method=gamma, Thread={0}", Thread.CurrentThread.ManagedThreadId);
                    }
                );
            }
            // No exception is expected in this example, but if one is still thrown from a task,
            // it will be wrapped in AggregateException and propagated to the main thread.
            catch (AggregateException e)
            {
                //--The exception that is thrown when any action in the actions array throws an exception.
                Console.WriteLine("An action has thrown an exception. THIS WAS UNEXPECTED.\n{0}", e.InnerException?.ToString());
            }

        }

        static void BasicAction()
        {
            Console.WriteLine("Method=alpha, Thread={0}", Thread.CurrentThread.ManagedThreadId);            
        }

        static void BasicThreadSummary()
        {
            string threadSummary = Thread.CurrentThread.ManagedThreadId.ToString() + " \n " + Thread.CurrentThread.Name;        
            Console.WriteLine("The Thread ummary is" + threadSummary);
        }
    }
}
