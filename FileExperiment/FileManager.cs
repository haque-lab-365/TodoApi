using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExperiment
{
    public class FileManager
    {
        private static Dictionary<string, string> wordData;
        public FileManager() { }    
        public static void ReadFile(string filePath)
        {
            try
            {
                wordData = new Dictionary<string, string>();
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    int lcpv = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        wordData.Add(line.Split('-')[0].Trim() + lcpv.ToString(), line.Split("-")[1].Trim());
                        lcpv++;
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

