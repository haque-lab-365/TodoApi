using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEvent.RaiseEvent
{
    public class EventDemo
    {
        public static void ShowEventDemo()
        {
            Counter c = new Counter(new Random().Next(10));
            
            //--Subscription of the event method.
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        /// <summary>
        /// Action when event is raised - the routin shuts down the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param na`me="e"></param>
        static void c_ThresholdReached(object sender, EventArgs e)
        {
            var tempSender = sender as Counter;
            Console.WriteLine($"The threshold was reached. The threshold is: {tempSender.ToString()}");
            //--Environment.Exit(0);
        }
    }
}
