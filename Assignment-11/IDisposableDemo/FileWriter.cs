using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableDemo
{
    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _streamWriter;

        /// <summary>
        /// Create a new stream writer for the specific file
        /// </summary>
        /// <param name="filePath"></param>
        public FileWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath, true);
        }

        /// <summary>
        /// Writes the given text to the file
        /// </summary>
        /// <param name="text"> Represents the content to be written to the file </param>
        public void Write(string text)
        {
            _streamWriter.WriteLine(text);
            _streamWriter.Flush();
        }

        /// <summary>
        /// Releases the file
        /// </summary>
        public void Dispose()
        {
            _streamWriter.Close();
            _streamWriter.Dispose();
        }
    }
}
