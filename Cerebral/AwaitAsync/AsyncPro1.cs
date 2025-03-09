using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebral.AwaitAsync
{
    public class AsyncPro1
    {
        public void Presentation() { 
            
            var watch = new System.Diagnostics.Stopwatch(); 
            watch.Start(); 
  
            var task1 = TheIntroduction(); 
            var task2 = TheCoreMessage(); 
            var task3 = TheConclusion(); 
  
  
            Task.WaitAll(task1, task2, task3); 

            watch.Stop(); 
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms"); 
              
        } 
          
          
        public static async Task TheIntroduction() 
        { 
            await Task.Run(() => 
            { 
                Thread.Sleep(4000); 
                Console.WriteLine("School Started"); 
            }); 
        } 
  
  
        public static async Task TheCoreMessage() 
        { 
            await Task.Run(() => 
            { 
                Thread.Sleep(5000); 
                Console.WriteLine("Taught class 12"); 
            }); 
              
  
        } 
  
        public static async Task TheConclusion() 
        { 
            await Task.Run(() => 
            { 
                Thread.Sleep(3000); 
                Console.WriteLine("Taught class 11"); 
            }); 
              
  
        } 
    }
}
