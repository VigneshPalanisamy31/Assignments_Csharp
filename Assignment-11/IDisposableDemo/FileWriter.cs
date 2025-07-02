namespace IDisposableDemo
{
    public class FileWriter : IDisposable
    {
        private StreamWriter streamWriter;

        /// <summary>
        /// Creates a new stream writer and opens the file to append text
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
        /// Closes and disposes the file stream.
        /// </summary>
        public void Dispose()
        {
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
