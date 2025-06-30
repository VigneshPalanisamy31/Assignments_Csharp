namespace IDisposableDemo
{
    public class FileWriter : IDisposable
    {
        StreamWriter streamWriter;

        /// <summary>
        /// Create a new stream writer for the specific file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        public FileWriter(string filePath)
        {
            streamWriter = new StreamWriter(filePath, true);
        }

        /// <summary>
        /// Writes the given text to the file
        /// </summary>
        /// <param name="text"> Represents the content to be written to the file </param>
        public void Write(string text)
        {
            streamWriter.WriteLine(text);
            streamWriter.Flush();
        }

        /// <summary>
        /// Releases the file
        /// </summary>
        public void Dispose()
        {
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
