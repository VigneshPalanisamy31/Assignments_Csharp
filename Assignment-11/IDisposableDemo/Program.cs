﻿namespace IDisposableDemo
{
    public class Program
    {
        /// <summary>
        /// Displays countdown.
        /// </summary>
        /// <param name="fileOperation">File operation (Reading/Writing)</param>
        public static void CountDown(string fileOperation)
        {
            Console.Write($"\nCount down to complete {fileOperation} : ");
            for (int count = 3; count > 0; count--)
            {
                Thread.Sleep(1000);
                Console.Write($"{count} ");
            }
        }

        /// <summary>
        /// Displays the completion message for the file operation.
        /// </summary>
        /// <param name="fileOperation">File operation (Reading/Writing)</param>
        public static void DisplaySuccessMessage(string fileOperation)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nFile {fileOperation} completed successfully!!");
            Console.ResetColor();
        }

        public static void Main(string[] args)
        {
            try
            {
                string filename = "file.txt";
                string sampleText = "This is a sample text to write to the file.";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------- Handling File Operations --------");
                Console.ResetColor();
                Console.WriteLine("\nWriting sample text to the file...");
                CountDown("Writing ");

                using (FileWriter fileWriter = new FileWriter(filename))
                {
                    fileWriter.Write(sampleText);
                }

                DisplaySuccessMessage("Writing");
                Console.WriteLine("\nReading the contents from a file...");
                CountDown("Reading");
                Console.WriteLine("\nFile Contents: ");
                Console.WriteLine("\n-------- Contents from the file --------\n");
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
                DisplaySuccessMessage("Reading");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:{ex.Message}");
            }
        }
    }
}