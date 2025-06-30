using System.Text;
using Spectre.Console;
namespace AsyncFileDataProcessor
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AsyncFileDataHandler handler = new AsyncFileDataHandler();
            List<(string, string)> filesToProcess = new();
            Console.Write("Enter how many files you want to access asynchronously: ");
            int numberOfFiles = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfFiles; i++)
            {
                AnsiConsole.MarkupLine($"[cyan]Getting details of file {i + 1}[/]");
                Console.WriteLine();
                string sourcePath = GetFilePath(FileEndPoint.source);
                string destinationPath = GetFilePath(FileEndPoint.destination);
                if (File.Exists(sourcePath))
                    filesToProcess.Add((sourcePath, destinationPath));
                else
                    HandleMissingFile(sourcePath, destinationPath, filesToProcess);
            }
            Console.WriteLine("Starting asynchronous file processing...");
            await handler.ProcessMultipleFilesAsync(filesToProcess);
            Console.WriteLine("All files processed.");
            Console.ReadKey();
        }

        /// <summary>
        /// Gets file path
        /// </summary>
        /// <param name="fileEndPoint">end point of the file [source or destination]</param>
        /// <returns></returns>
        private static string GetFilePath(FileEndPoint fileEndPoint)
        {
            Console.Write($"Enter relative file path of {fileEndPoint.ToString()} file (Ex: MainFile.txt): ");
            string filePath = Console.ReadLine();
            if (filePath.Contains(".txt"))
                return filePath;
            return filePath + ".txt";
        }

        /// <summary>
        /// Handles missing file by creating new file.
        /// </summary>
        /// <param name="sourceFile">source file</param>
        /// <param name="destinationFile">destination file</param>
        /// <param name="filesToProcess">list of files to process</param>
        private static void HandleMissingFile(string sourceFile, string destinationFile, List<(string, string)> filesToProcess)
        {
            AnsiConsole.MarkupLine($"[red] File not found:[/] [blue]{sourceFile}[/]");
            bool create = AnsiConsole.Confirm("Would you like to [green]create[/] this file?");
            if (create)
            {
                CreateNewFileWithRandomData(sourceFile);
                filesToProcess.Add((sourceFile, destinationFile));
            }
            else
            {
                string sourcePath = GetFilePath(FileEndPoint.source);
                string destinationPath = GetFilePath(FileEndPoint.destination);
                if (File.Exists(sourcePath))
                    filesToProcess.Add((sourcePath, destinationPath));
                else
                    HandleMissingFile(sourcePath, destinationPath, filesToProcess);
            }
        }
        /// <summary>
        /// Creates a 1MB of file. 
        /// </summary>
        /// <param name="filePath">path of the file</param>
        public static void CreateNewFileWithRandomData(string filePath)
        {
            long fileSize = 1L * 1024 * 1024;
            string textToWrite = GetTextFromUser();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fileStream, Encoding.ASCII))
            {
                long totalWritten = 0;
                while (totalWritten < fileSize)
                {
                    writer.Write(textToWrite);
                    totalWritten += textToWrite.Length;
                }
            }
        }
        /// <summary>
        /// Gets a string from the user.
        /// </summary>
        /// <returns>user entered string</returns>
        private static string GetTextFromUser()
        {
            Console.Write("Enter a string to write in the file: ");
            return Console.ReadLine();
        }
    }
}
