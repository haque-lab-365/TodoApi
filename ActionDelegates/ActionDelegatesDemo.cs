using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegates
{
    public static class ActionDelegatesDemo
    {
       
        //--Define a delegate type
        public delegate int MathAdditions(int x, int y);
        public delegate T GenericMathOpsDelegate<T>(T xValue, T yValue);
        public static void PrintMessage()
        {
            Console.WriteLine("Hello! I am from action delegate!");
        }

        /// <summary>
        /// Theme: Any lambda expression can be converted to a delegate type. 
        /// </summary>
        public static void ConvertLambdaToDeligate()
        {
            //--Create a lambda expressions
            MathAdditions mathAddition = (x, y) => x + y;

            //--Invoke the delegate using the lambda expression
            int result = mathAddition(20, 30);
            Console.WriteLine($"The result of addition is: {result}");
            result = mathAddition(10000, 10000);
            Console.WriteLine($"The result of addition is: {result}");
        }
        /// <summary>
        ///  Theme: Any lambda expression can be converted to a delegate type. 
        /// </summary>
        public static void ConvertLambdaToDeligate1()
        {
            GenericMathOpsDelegate<int>  intAddition = (x, y) => x + y;
            int iresult = intAddition(20, 30);
            Console.WriteLine($"The result of addition is: {iresult}");

            GenericMathOpsDelegate<float> fltAddition = (x, y) => x + y;
            float fresult = fltAddition(20.50f, 30.20f);
            Console.WriteLine($"The result of addition is: {fresult}");

            GenericMathOpsDelegate<double> dblAddition = (x, y) => x + y;
            double dresult = dblAddition(100.985, 200.352);
            Console.WriteLine($"The result of addition is: {dresult}");
        }


        //
    }
}
