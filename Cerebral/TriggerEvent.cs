using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebral
{
    public class TriggerEvent<T> : List<T>
    {
        public event EventHandler OnAdd;
        public event EventHandler OnRemove;

        public new void Add(T item) //-// "new" to avoid compiler-warnings, because we're hiding a method from base-class
        {

            if (null != OnAdd)
            {
                OnAdd(this, null);
            }
            base.Add(item);
        }

        static void l_OnAdd(object sender, EventArgs e)
        {
            Console.WriteLine("Element added...");
        }

    }
}
