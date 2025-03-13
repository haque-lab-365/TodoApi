using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ActionDelegates
{
    public class SuperiorDelegates
    {

        //--Delegate declaration
        public delegate int Calculate(int x, int y);
        public delegate int Product(int x, int y);
        public delegate void GreetDelegate(string message);
        public delegate void OperationDelegate(int x, int y);

        public SuperiorDelegates() { }
        static int Add(int a, int b) => a + b;
        static int Mul(int a, int b) => a * b;

        static void Sum(int x, int y)
        {
            Console.WriteLine($"Sum: {x + y} ");
        }

        //--Passing Delegates As Method Parameters
        static void ExecuteOperation(OperationDelegate operation, int x, int y)
        {
            operation(x, y); // Invoke the delegate
        }

        static void Greet(string message)
        {
            Console.WriteLine(message);
        }

        public static void BasicLevelIntroductiontoDelegates()
        {
            DateTime currentTime = DateTime.Now;
            GreetDelegate greet = Greet;
            if (currentTime.Hour < 12)
                greet("Hello world..Good Morning!!");
            else if (currentTime.Hour < 12 && currentTime.Hour < 17)
                greet("Hello World...Good Afternoon");
            else
                greet("Good evening...");
        }

        public static void PassingDelegatesAsMethodParameters()
        {
            OperationDelegate operation = Sum;
            ExecuteOperation(operation, 100, 200);
        }

        public static void DelegatesDemo()
        {
            //--Assign a method to a delegate:

            Calculate Calc = Add;
            Console.WriteLine("The result is {0}", Calc(100, 200));
            Product Prod = Mul;
            Console.WriteLine("The result is {0}", Prod(100, 200));
        }


        /*
            Once you understand delegates, explore the built-in delegates:
            Action: Encapsulates methods that do not return a value.
            Func: Encapsulates methods that return a value.
        */
        public static void MoveDelegatesActionDemo()
        {
            //--Assign a method to a delegate:
            Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
            greet("Shahidul"); // Output: Hello, Shahidul!

            Func<int, int, int> multiply = (a, b) => a * b;
            Console.WriteLine(multiply(3, 4)); // Output: 12

            //--Understand Lambdas Through Delegates
            //--Learn how lambdas are shorthand for creating delegate instances:
            Calculate calc1 = (x, y) => x * y; // Lambda used here
            Calculate calc2 = (a, b) => a * b; // Lambda used here
            Calculate calc3 = (p, q) => p * q; // Lambda used here

            Console.WriteLine(calc1(2, 5)); // Output: 10
            Console.WriteLine(calc2(5, 5)); // Output: 25
            Console.WriteLine(calc3(6, 6)); // Output: 36

            //--Experiment with LINQ
            //--Apply what you've learned about lambdas by using LINQ, which heavily relies on lambda expressions:
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evens = numbers.Where(x => x % 2 == 0).ToList();
            var odds = numbers.Where(x => x % 2 != 0).ToList();

            Console.WriteLine(string.Join(", ", evens)); // Output: 2, 4,6,8,10
            Console.WriteLine(string.Join(", ", odds)); // Output: 1, 3,5,7,9

            /*
                Summary: 
                Start with basic delegates to grasp the core concept.
                Progress to Action and Func to see how common delegate patterns are simplified.
                Finally, move to lambda expressions, which streamline delegate syntax.
            */
        }

        //--2. Medium Level: Multicast Delegates and Anonymous Methods
        //--3. Multicast delegates allow you to attach multiple methods to a single delegate.

        public delegate void NotifyDelegate();

        static void Notify1()
        {
            Console.WriteLine("Notification 1 triggered");
        }

        static void Notify2()
        {
            Console.WriteLine("Notification 2 triggered");
        }

        //--Example-1
        public static void MulticastDelegateTest()
        {
            NotifyDelegate notify = Notify1;
            notify += Notify2; //--Add another notify 
            notify(); //--Outputs both notificatio.
        }

        //--Example 2: Using Anonymous Methods
        public delegate void MessageDelegate(string message);

        public static void UsingAnonymousMethod()
        {
            // Anonymous method assigned to delegate
            MessageDelegate showMessage = delegate (string msg)
            {
                Console.WriteLine($"Message: {msg}");
            };

            showMessage("This is an anonymous method"); // Output: This is an anonymous method
        }

        //--3. Advanced Level: Generic Delegates and Lambda Expressions
        //-- Generic delegates like Func and Action simplify the use of delegates by avoiding the need for custom delegate types.
        //--Example 1: Using Func Delegate
        //--Func is used for methods that return a value.

        public static void UsingFunc()
        {
            //--Func with two inputs and one output
            Func<int, int, int> multiply = (a, b) => a * b;
            int result = multiply(5, 6);
            Console.WriteLine($"Product: {result}"); // Output: Product: 30 

            //--Func with two inputs and one output
            Func<int, int, int, int> bigMulti = (a, b, c) => a * b * c;
            int answer = bigMulti(2, 3, 4);
            Console.WriteLine($"Product: {answer}"); // Output: Product: 24 
        }

        //--Example 2: Using Action Delegate
        //--Action is used for methods that do not return a value.
        public static void UsingAction()
        {
            // Action with one parameter | Action is a special type of delegate
            Action<string> printMessage = message => Console.WriteLine($"Message: {message}");
            printMessage("This is an Action delegate"); // Output: Message: This is an Action delegate
        }
    }
}


/*

Example 3: Combining Lambda Expressions with Delegates
csharp
using System;

class Program
{
    public delegate bool CompareDelegate(int x, int y);

    static void Main()
    {
        // Lambda expression as a delegate
        CompareDelegate isGreater = (a, b) => a > b;

        Console.WriteLine(isGreater(10, 5)); // Output: True
        Console.WriteLine(isGreater(3, 8)); // Output: False
    }
}
4. Advanced Level: Delegates in Real-World Scenarios
Delegates are often used in event handling and callback mechanisms.

Example 1: Callback Mechanism
csharp
using System;

class Program
{
    public delegate void ProgressDelegate(int percentage);

    static void LongRunningTask(ProgressDelegate progressCallback)
    {
        for (int i = 1; i <= 100; i += 10)
        {
            System.Threading.Thread.Sleep(100); // Simulate work
            progressCallback(i); // Notify progress
        }
    }

    static void Main()
    {
        ProgressDelegate reportProgress = progress => Console.WriteLine($"Progress: {progress}%");
        LongRunningTask(reportProgress);
    }
}
Example 2: Event Handling Using Delegates
csharp
using System;

class Program
{
    public delegate void NotifyDelegate();

    public class EventPublisher
    {
        public event NotifyDelegate NotifyEvent;

        public void TriggerEvent()
        {
            NotifyEvent?.Invoke(); // Trigger the event
        }
    }

    static void Main()
    {
        EventPublisher publisher = new EventPublisher();
        publisher.NotifyEvent += () => Console.WriteLine("Event triggered!");
        publisher.TriggerEvent(); // Output: Event triggered!
    }
} 
  
 */
