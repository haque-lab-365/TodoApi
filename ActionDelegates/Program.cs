// See https://aka.ms/new-console-template for more information
using ActionDelegates;

Console.WriteLine("Hello, World!");

Action action = ActionDelegatesDemo.PrintMessage;
action();

Console.ReadLine();

