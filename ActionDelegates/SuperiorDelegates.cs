using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegates
{

    public delegate int Calculate(int x, int y);
    public delegate int Product(int x, int y);



    public class SuperiorDelegates
    {
        public SuperiorDelegates() { }
        static int Add(int a, int b) => a + b;
        static int Mul(int a, int b) => a * b; 



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
        }
    }
}
