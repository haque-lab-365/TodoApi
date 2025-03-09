using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebral.AwaitAsync
{
    public class SyncPro
    {

        public void Presentation()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            
            TheIntroduction();
            TheCoreMessage();
            TheConclusion();
            
            watch.Stop();
            Console.WriteLine($"Execution Time: { watch.ElapsedMilliseconds} ms"); 
        }


        public void TheIntroduction()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Presentation Introduction Starts here:");
        }


        public  void TheCoreMessage()
        {
            Thread.Sleep(5000);
            Console.WriteLine("The Core Message of the Presentation starts here:");

        }

        public static void TheConclusion()
        {
            Thread.Sleep(3000);
            Console.WriteLine("The conclusion of the presentation goes here:");

        }

    }
}
