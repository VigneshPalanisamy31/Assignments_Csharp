using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
namespace FileUsageIssues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = GetFilePath();
                string data = GetTextFromUser();
                Console.WriteLine("=== Inefficient File Write and Read ===");
                Console.WriteLine("Time taken for inefficient file operation: " + InefficientFileWriteAndRead(path, data) + "milliseconds");
                Console.WriteLine("\n=== Optimized File Write and Read ===");
                Console.WriteLine("Time taken for optimized file operation: " + OptimizedFileWriteAndRead(path, data) + "milliseconds");
            }
            catch (Exception e)
            {
                Console.WriteLine("Execution interrupted!!!\n"+e.Message);
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Function that perform read and write inefficiently.
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <param name="data">Data to write to the file</param>
        /// <returns>Time taken</returns>
        static long InefficientFileWriteAndRead(string path, string data)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Write using MemoryStream unnecessarily
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            // Read using overly large buffer and inefficient printing
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.Write((char)buffer[i]);
                    }
                    Console.WriteLine();
                }
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        /// <summary>
        /// Function to perform read and write efficiently.
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <param name="data">Data to write to the file</param>
        /// <returns>Time taken</returns>
        static long OptimizedFileWriteAndRead(string path, string data)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.Write(buffer, 0, buffer.Length);
            }
            // Read the file using exact-sized buffer and convert directly to string
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] readBuffer = new byte[fileStream.Length];
                int bytesRead = fileStream.Read(readBuffer, 0, readBuffer.Length);
                string result = Encoding.ASCII.GetString(readBuffer, 0, bytesRead);
                Console.WriteLine(result);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        /// <summary>
        /// Function to get text from user.
        /// </summary>
        /// <returns>User entered string</returns>
        private static string? GetTextFromUser()
        {
            Console.Write("Enter a string to write in the file: ");
            return Console.ReadLine();
        }
        /// <summary>
        /// Function to get file path from user.
        /// </summary>
        /// <returns>valid file_path(.txt)</returns>
        private static string GetFilePath()
        {
            Console.Write($"Enter relative file path (Ex: MainFile.txt): ");
            string filePath = Console.ReadLine();
            if (filePath.Contains(".txt"))
                return filePath;
            else
                return filePath + ".txt";
        }

    }
}
