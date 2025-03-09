using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerebral.Delegates
{
    public class DelegatesExplained
    {
        public delegate void PrintDelegate(string text);
        //--https://youtu.be/uAhVpw8zzm4

        public DelegatesExplained() { } 

        

        public void ShowDelegateMagic()
        {

        }

        //--PrintDelegate print = (string text) => Console.WriteLine(text);
        public PrintDelegate printToConsole = (string text) =>
        {
            Console.WriteLine(text);
        };

        public PrintDelegate printToFile = (string text) =>
        {
            Console.WriteLine("Writing to file started...");
            File.AppendAllText("./logs.txt", text);
            Console.WriteLine("Writing to file ended.....");
        };

        public void ConnectToDatabase(PrintDelegate log)
        {
            //--Start insertion into the DB...
            log("Inserting a record into the database....");
            //--End insertion into the DB...
            log("The record got inserted into the database..");
        }
    }
}
