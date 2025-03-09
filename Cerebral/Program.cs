// See https://aka.ms/new-console-template for more information

using Cerebral;
using Cerebral.AwaitAsync;
using Cerebral.Delegates;
Console.WriteLine("Hello, World!");

/*
Console.WriteLine("Executing synchronous operations....");
SyncPro sp = new SyncPro();
sp.Presentation();

Console.WriteLine("Executing asynchronous operations[Part-1]....");
AsyncPro1 asp1 = new AsyncPro1();
sp.Presentation();
*/

/**
TriggerEvent<int> ints = new TriggerEvent<int>();   
ints.OnAdd += new EventHandler(TriggerEvent.)
ints.Add(1);
**/

DelegatesExplained delegates = new DelegatesExplained();
delegates.ShowDelegateMagic();
delegates.printToConsole("I am printing in console");

delegates.ConnectToDatabase(delegates.printToConsole);
delegates.ConnectToDatabase(delegates.printToFile);

//ConnectToDatabase(printToFile);
//ConnectToDatabase(printToConsole);

Console.ReadLine();

