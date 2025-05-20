using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExperiment
{
    public class FileManager
    {

        public FileManager() { }    
        public static void ReadFile(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("File read operation completed.");
                //--Go release the garbage.
            }   
        }   
    }
}
