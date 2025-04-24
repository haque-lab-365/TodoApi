using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEvent.RaiseEvent
{
    public class Counter
    {

        private int threshold;
        private int total;
        
        public Counter(int passedThreshold) 
        { 
            threshold = passedThreshold;
        }
        public void Add(int x)
        {
            total += x;
            if (total > threshold)
            {
                //--Raising event based on condition
                ThresholdReached?.Invoke(this, EventArgs.Empty);
            }

            Console.WriteLine($"The total is: {total}");
        }

        public override string ToString()
        {
            return $"The reached value of counter is: {threshold}";
        }

        public event EventHandler ThresholdReached;
    }
}
