using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Range = (int Minimum, int Maximum);
using BandPass = (int Min, int Max);

//--https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
//--https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct
namespace Deconstruct
{
    public class TupleExperiment
    {

        /// <summary>
        /// Tuple: Group multiple data elements in a lightweight data structure.
        /// </summary>
        public static void TupleDeclaration()
        {

            //Way-1: declare a tuple with implicit variable(Item), initialize it, and access its data members:
            (double, int) t1 = (4.5, 3);
            Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");

            //Way-2: declare a tuple with explicit variable, initialize it, and access its data members:
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");

            //-- We can use the methods provided by .NET, as the following example shows[ToString() and GetHashCode()]:
            (double, int) t = (4.5, 3);
            Console.WriteLine(t.ToString());
            Console.WriteLine($"Hash code of {t} is {t.GetHashCode()}.");

            var tpl = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10,   11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26);
            Console.WriteLine(tpl.Item26);  // output: 26

            //--If you don't specify a field name, it may be inferred from the name of the corresponding variable in a tuple initialization expression, as the following example shows:
            var sum = 4.5;
            var count = 3;
            var tp = (sum, count);
            Console.WriteLine($"Sum of {tp.count} elements is {tp.sum}.");

            //-- The default names of tuple fields are Item1, Item2, Item3 and so on.
            //-- You can always use the default name of a field, even when a field name is specified explicitly or inferred
            var a = 1;
            var tplDuality = (a, b: 2, 3);
            Console.WriteLine($"The 1st element is {tplDuality.Item1} (same as {tplDuality.a}).");
            Console.WriteLine($"The 2nd element is {tplDuality.Item2} (same as {tplDuality.b}).");
            Console.WriteLine($"The 3rd element is {tplDuality.Item3}.");

            //--Aliasing using tuple 
            BandPass bracket = (40, 100);
            Console.WriteLine($"The bandpass filter is {bracket.Min} to {bracket.Max}");

            //--Destructuring alias tuple 
            (int ab, int bb) = bracket;
            Console.WriteLine($"The bracket is {ab} to {bb}");

            //--Assing a using Range tuple wiht BandPass tuple 
            Range r = bracket;
            Console.WriteLine($"The range is {r.Minimum} to {r.Maximum}");

            //--Use case-1: Instead of defining out method parameters, you can group method results in a tuple return type
            int[] xs = new int[] { 4, 7, 9 };
            var limits = FindMinMax(xs);
            Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");
            // Output:
            // Limits of [4 7 9] are 4 and 9

            int[] ys = new int[] { -9, 0, 67, 100 };
            var (minimum, maximum) = FindMinMax(ys);
            Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
            // Output:
            // Limits of [-9 0 67 100] are -9 and 100


        }
        /// <summary>
        /// Tuple assignment and deconstruction
        /// 
        /// </summary>
        public static void TupleAssignmentDeconstruction()
        {
            (int, double) t1 = (17, 3.14);
            (double First, double Second) t2 = (0.0, 1.0);
            t2 = t1;
            Console.WriteLine($"{nameof(t2)}: {t2.First} and {t2.Second}");


            (double A, double B) t3 = (2.0, 3.0);
            t3 = t2;
            Console.WriteLine($"{nameof(t3)}: {t3.A} and {t3.B}");

            //--Deconstruct using var
            var t = ("post office", 3.6);
            var (destination, distance) = t;
            Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            //Output: Distance to post office is 3.6 kilometers.

            //--Deconstruct explicitly, declare the type of each variable inside parentheses:
            var td = ("post office", 3.6);
            (string dest, double dist) = td;
            Console.WriteLine($"Distance to {dest} is {dist} kilometers.");
            //--Output: Distance to post office is 3.6 kilometers.

            //--Deconstruct explicitly, declare some types explicitly and other types implicitly (with var) inside the parentheses:
            var tpld = ("post office", 3.6);
            (var destin, double distan) = tpld;
            Console.WriteLine($"Distance to {destin} is {distan} kilometers.");
            // Output: Distance to post office is 3.6 kilometers.

            //--Deconstruct explicitly, Use existing variables:
            var location = string.Empty;
            var length = 0.0;

            var tplDecons = ("post office", 3.6);
            (location, length) = tplDecons;
            Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            // Output: Distance to post office is 3.6 kilometers.


            //--You can also combine deconstruction with pattern matching to inspect the characteristics of fields in a tuple.
            //--The following example loops through several integers and prints those that are divisible by 3.
            //--It deconstructs the tuple result of Int32.DivRem and matches against a Remainder of 0:
            for (int i = 4; i < 20; i++)
            {
                if (Math.DivRem(i, 3) is (Quotient: var q, Remainder: 0))
                {
                    Console.WriteLine($"{i} is divisible by 3, with quotient {q}");
                }
            }

        }

        public static void TupleOperations()
        {
            //--Tuple types support equality operators
            //--Tuple types are value types
            //--in LINQ queries. For more information, see Choosing between anonymous and tuple types.
            //--Beginning with C# 12, you can specify an alias for a tuple type
            //--Tuples vs System.Tuple
        }

        private static (int min, int max) FindMinMax(int[] input)
        {
            if (input is null || input.Length == 0)
            {
                throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
            }

            // Initialize min to MaxValue so every value in the input
            // is less than this initial value.
            var min = int.MaxValue;
            // Initialize max to MinValue so every value in the input
            // is greater than this initial value.
            var max = int.MinValue;
            foreach (var i in input)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            return (min, max);
        }
    }
}
