// See https://aka.ms/new-console-template for more information
//-https://learn.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
using ThreadSafeCollections;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ConcurrentQueueExample.CQDemos();
        Console.ReadLine();
    }
}