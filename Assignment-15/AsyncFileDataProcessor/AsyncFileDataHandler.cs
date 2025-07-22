using System.Diagnostics;
using System.Text;
using Spectre.Console;
namespace AsyncFileDataProcessor
{
    internal class AsyncFileDataHandler
    {
        // Buffer size for chunked reading and writing (4KB)
        private const int ChunkSize = 4 * 1024;

        /// <summary>
        /// Asynchronously converts the contents of a source file to upper case and writes it to a destination file.
        /// </summary>
        public async Task<long> ConvertToUpperCaseAsync(string sourcePath, string destinationPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                await PerformConvertionToUpperCase(sourcePath, destinationPath);
            }
            catch
            {
                Console.WriteLine("More than one user trying to access same file. So the program crashed");
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Processes multiple file pairs concurrently, converting each source file to upper case.
        /// </summary>
        public async Task ProcessMultipleFilesAsync(List<(string sourcePath, string destinationPath)> filePairs)
        {
            List<Task<long>> tasks = new();
            foreach (var (source, dest) in filePairs)
            {
                tasks.Add(ConvertToUpperCaseAsync(source, dest));
            }
            long[] durations = await Task.WhenAll(tasks);
            for (int i = 0; i < filePairs.Count; i++)
            {
                Console.WriteLine($"Processed file {filePairs[i].sourcePath} to {filePairs[i].destinationPath} in {durations[i]} ms");
            }
        }

        /// <summary>
        /// Reads from the source stream, converts each chunk to upper case, and writes to the destination stream asynchronously.
        /// </summary>
        private static async Task PerformConvertionToUpperCase(string sourcePath, string destinationPath)
        {
            using FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None, bufferSize: ChunkSize, useAsync: true);
            using FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: ChunkSize, useAsync: true);
            byte[] buffer = new byte[ChunkSize];
            int bytesRead;
            while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string chunkString = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                string upperChunkString = chunkString.ToUpper();
                byte[] upperChunkBytes = Encoding.ASCII.GetBytes(upperChunkString);
                await destinationStream.WriteAsync(upperChunkBytes, 0, upperChunkBytes.Length);
            }
        }
    }
}
