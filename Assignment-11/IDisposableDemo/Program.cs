namespace IDisposableDemo
{
    public class Program
    {
        /// <summary>
        /// Function to display countdown.
        /// </summary>
        /// <param name="displayMessage">Message to display to the console</param>
        public static void CountDown(string displayMessage)
        {
            Console.Write($"\nCount down to complete {displayMessage} : ");
            for (int time = 3; time > 0; time--)
            {
                Thread.Sleep(1000);
                Console.Write($"{time} ");
            }
        }
        /// <summary>
        /// Function to display the completion of the file operation.
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------- Handling File Operations --------");
                Console.ResetColor();
                string filename = "file.txt";
                string text = "File Writing Success!!";
                Console.WriteLine("\nWriting file...");
                CountDown("Writing ");
                using (FileWriter fileWriter = new FileWriter(filename))
                {
                    fileWriter.Write(text);
                }
                DisplaySuccessMessage("Writing");
                Console.WriteLine("\nReading from a file...");
                CountDown("Reading");
                // Display message for the contents read from file
                Console.WriteLine("\nFile Contents: ");
                Console.WriteLine("\n-------- Contents from the file --------\n");
                StreamReader streamReader = new StreamReader(filename);
                Console.WriteLine(streamReader.ReadToEnd());
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