using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Let’s consider a real-world use case: a file processing system in which multiple files need to be processed concurrently. 
    For example, imagine a system where you’re tasked with analyzing 5 large files, and each file requires a different type of 
    processing, such as compression, encryption, format conversion, data validation, and checksum calculation.
    Here’s how you can implement this scenario using 5 threads, each assigned to a specific job
*/



namespace TheThread
{
    public class ThreadInAction
    {
        public static void ThreadActionDemo()
        { 
            Thread compressFileThread = new Thread(CompressFile);
            Thread encryptFileThread = new Thread(EncryptFile);
            Thread convertFileThread = new Thread(ConvertFile);
            Thread validateFileThread = new Thread(ValidateFile);
            Thread calculateChecksumThread = new Thread(CalculateChecksum); 

            compressFileThread.Start("file1.txt");
            encryptFileThread.Start("file2.txt");
            convertFileThread.Start("file3.txt");
            validateFileThread.Start("file4.txt");
            calculateChecksumThread.Start("file5.txt");

            compressFileThread.Join();
            encryptFileThread.Join();
            convertFileThread.Join();   
            validateFileThread.Join();
            calculateChecksumThread.Join();

            Console.WriteLine("All threads have completed their tasks.");   


        }

        static void CompressFile(object? fileName)
        {
            Console.WriteLine($"Starting compression for {fileName}...");
            Thread.Sleep(2000); // Simulate file compression
            Console.WriteLine($"Compression complete for {fileName}.");
        }

        static void EncryptFile(object fileName)
        {
            Console.WriteLine($"Starting encryption for {fileName}...");
            Thread.Sleep(2000); // Simulate file encryption
            Console.WriteLine($"Encryption complete for {fileName}.");
        }

        static void ConvertFile(object fileName)
        {
            Console.WriteLine($"Starting format conversion for {fileName}...");
            Thread.Sleep(2000); // Simulate file format conversion
            Console.WriteLine($"Format conversion complete for {fileName}.");
        }

        static void ValidateFile(object fileName)
        {
            Console.WriteLine($"Starting data validation for {fileName}...");
            Thread.Sleep(2000); // Simulate data validation
            Console.WriteLine($"Data validation complete for {fileName}.");
        }

        static void CalculateChecksum(object fileName)
        {
            Console.WriteLine($"Starting checksum calculation for {fileName}...");
            Thread.Sleep(2000); // Simulate checksum calculation
            Console.WriteLine($"Checksum calculation complete for {fileName}.");
        }


        //--These are the methods that will be used in the second version of the file processing system.
        //--They are smart enough to handle exceptions and perform cleanup operations.
        static void CompressFileV2(object fileName)
        {
            try
            {
                Console.WriteLine($"Starting compression for {fileName}...");
                // Simulate an error
                throw new Exception("Compression failed due to insufficient disk space.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during compression: {ex.Message}");
                // Optional: Log the error, retry, or perform cleanup
            }
            finally
            {
                Console.WriteLine($"Cleanup after compression for {fileName}.");
            }
        }

        static void EncryptFileV2(object fileName)
        {
            try
            {
                Console.WriteLine($"Starting encryption for {fileName}...");
                Thread.Sleep(2000); // Simulate file encryption
                Console.WriteLine($"Encryption complete for {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during encryption: {ex.Message}");
            }
        }

        static void ConvertFileV2(object fileName)
        {
            try
            {
                Console.WriteLine($"Starting format conversion for {fileName}...");
                Thread.Sleep(2000); // Simulate file format conversion
                Console.WriteLine($"Format conversion complete for {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during format conversion: {ex.Message}");
            }
        }

        static void ValidateFileV2(object fileName)
        {
            try
            {
                Console.WriteLine($"Starting data validation for {fileName}...");
                Thread.Sleep(2000); // Simulate data validation
                Console.WriteLine($"Data validation complete for {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during data validation: {ex.Message}");
            }
        }

        static void CalculateChecksumV2(object fileName)
        {
            try
            {
                Console.WriteLine($"Starting checksum calculation for {fileName}...");
                Thread.Sleep(2000); // Simulate checksum calculation
                Console.WriteLine($"Checksum calculation complete for {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during checksum calculation: {ex.Message}");
            }
        }
    }
}
