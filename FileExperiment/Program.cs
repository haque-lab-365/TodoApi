// See https://aka.ms/new-console-template for more information
using FileExperiment;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");
//--string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

//--string filePathe = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
//--FileManager.ReadFile("C:\\Users\\User\\Documents\\test.txt");   

//--string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleData.txt");

string currentDirectory = Directory.GetCurrentDirectory();
string? parentDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;

if (parentDirectory == null)
{
    Console.WriteLine("Error: Unable to determine the project directory.");
    return;
}

// Define the file path inside the project directory
string filePath = Path.Combine(parentDirectory, "SampleData.txt");

FileManager.ReadFile(filePath);
Console.ReadLine();