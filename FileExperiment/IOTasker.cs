using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FileExperiment
{
    public static class IOTasker
    {
        //--create a text file with streamwriter.

        public static void CreateFile()
        {

            string filePath = @"c:\temp\MyTest.txt"; //--temp folder must exist first.
            if (!File.Exists(filePath)) {

                //--createa  file to  write to

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Welcome to the file content.");
                    sw.WriteLine("Welcome to the file manager.");
                    sw.WriteLine("Welcome to the file drive!");
                }
            
            }

            //--Open the file to read from.
            using (StreamReader sr = File.OpenText(filePath))
            {
                string fileContent = string.Empty;

                while ((fileContent = sr.ReadLine()) != null)
                {
                    Console.WriteLine(fileContent);
                }
            }

            //--https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file
            //--Read text from a file
        }

        //--Read text from a file
        /// <summary>
        /// Create a StreamReader instance.
        /// Call the StreamReader.ReadToEnd() method and assign the result to a string.
        /// Write the output to the console. Please note that - its not an async io operation.
        /// </summary>
        public static void ReadContentFromFile()
        {

            string filePath = @"c:\temp\MyTest.txt";

            try
            {
                //--StreamReader sr = File.OpenText(filePath);
                using StreamReader reader = new(filePath); 
                //--Read the stream as a string 
                string fileContent = reader.ReadToEnd();
                //--Write the content to the console
                Console.WriteLine(fileContent);

            }
            catch (Exception ex)
            {
                Console.WriteLine("The file couldn't be read..");
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                filePath = string.Empty;
            }

        }

        public static async Task ReadContentFromFile(string filePath, bool readAsync)
        {
            try
            {

                string fileContent = string.Empty;

                //--StreamReader sr = File.OpenText(filePath);
                using StreamReader reader = new(filePath);
                
                //--Read the stream as a string 
                /*
                if (readAsync)
                {
                    fileContent = await reader.ReadToEndAsync();
                }
                else
                {
                    fileContent = reader.ReadToEnd();
                }*/
                
                fileContent = readAsync ? await reader.ReadToEndAsync() : reader.ReadToEnd();
                //--Write the content to the console
                Console.WriteLine(fileContent);


            }
            catch (Exception ex)
            {
                Console.WriteLine("The file couldn't be read..");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                filePath = string.Empty;
            }

        }

        private static async Task<string> ReadFileContentAsync(bool readAsync, TextReader reader)
        {
            return readAsync ? await reader.ReadToEndAsync() : reader.ReadToEnd();
        }

        //--string fileContent = await ReadFileContentAsync(readAsync, reader);

        //--https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file
    }
}
