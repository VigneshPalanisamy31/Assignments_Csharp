using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFileDataProcessor
{
    internal class UI
    {
        static async Task Main(string[] args)
        {
            AsynchronousFileHandler handler = new AsynchronousFileHandler();

            var filesToProcess = new List<(string, string)>
            {
                ("file1.txt", "file1_output.txt"),
                ("file2.txt", "file2_output.txt"),
                ("file3.txt", "file3_output.txt")
            };

            Console.WriteLine("Starting asynchronous file processing...");
            await handler.ProcessMultipleFilesAsync(filesToProcess);
            Console.WriteLine("All files processed.");
        }

    }
}
