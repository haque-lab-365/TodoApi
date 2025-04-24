using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegates
{
    public  class LambdaWorld
    {
        public LambdaWorld() { }
        public static void ExpressionLabdasDemo()
        {
            //-- (input - parameters) => expression
            //--The body of an expression lambda can consist of a method call
            Action line = () => Console.WriteLine("Bare minimum syntax!");
            line();

        }


    }
}
