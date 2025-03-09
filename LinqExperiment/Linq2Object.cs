using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExperiment
{
    public class Linq2Object
    {
        public void QueryInMemory()
        {

            Console.WriteLine("The in memory linq experiment...");
            
            List<int> numbers = [1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20];
            IEnumerable<int> qryFactorsFour = from num in numbers
                                              where num % 4 == 0
                                              select num;

            //--Store the results in a new variable(qryFactorsFour) without executing a foreach loop.
            var factorsofFourList = qryFactorsFour.ToList();
            //--Read and write from the newly created list to demonstrate that it holds data.
            Console.WriteLine(factorsofFourList[2]);
            factorsofFourList[2] = 0;
            Console.WriteLine(factorsofFourList[2]);
            //--Source: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries#classification-of-standard-query-operators-by-manner-of-execution
        }

        //--Creates a List<T> from an IEnumerable<T>.
        public void EnumerableToList()
        {
            Console.WriteLine("Enumerable to List experiment...");
            string[] fruits = { "apple", "passionfruit", "banana", "mango",
                      "orange", "blueberry", "grape", "strawberry" };

            List<int> lengths = fruits.Select(fruit => fruit.Length).ToList(); 

            foreach (int length in lengths)
            {
                Console.WriteLine(length);
            }
        }
    }
}
