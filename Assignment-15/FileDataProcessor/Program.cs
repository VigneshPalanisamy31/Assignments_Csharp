using Spectre.Console;
namespace FileDataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileDataHandler fileHandler = new FileDataHandler();
                string sourceFilePath = GetFilePath();
                fileHandler.CreateLargeFile(1, sourceFilePath);
                Console.WriteLine("File created successfully!!!");
                Console.WriteLine("Reading file contents in chunks...");
                Console.WriteLine("File reading started for bufferStream method");

                bool canExit = false;
                while (!canExit)
                {
                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[green]Please select an option (use arrows):[/]")
                            .PageSize(10)
                            .AddChoices(new[] {
                        "Read text from file using File stream",
                        "Read text from file using Buffered stream",
                        "Convert text to uppercase using File stream",
                        "Convert text to uppercase using Buffered stream",
                        "Convert text to uppercase using Memory stream",
                        "Exit"
                            }));

                    switch (choice)
                    {
                        case "Read text from file using File stream":
                            AnsiConsole.MarkupLine("[blue]Reading text from file using File stream");
                            Console.WriteLine("TimeTaken to read file as chunks: "
                                + (double)fileHandler.ReadFileUsingFileStream(sourceFilePath) / 1000 + "sec");
                            break;
                        case "Read text from file using Buffered stream":
                            AnsiConsole.MarkupLine("[blue]Reading text from file using File stream");
                            Console.WriteLine("TimeTaken to read file using BufferStream: "
                                + (double)fileHandler.ReadFileUsingBufferedStream(sourceFilePath) / 1000 + "sec");
                            break;
                        case "Convert text to uppercase using File stream":
                            AnsiConsole.MarkupLine("[blue]Converting text to uppercase using File stream[/]");
                            Console.WriteLine("TimeTaken to convert strings to uppercase using chunks: "
                                + (double)fileHandler.ConvertToUpperCaseUsingChunks(sourceFilePath, "uppercase.txt") / 1000 + "sec");
                            break;
                        case "Convert text to uppercase using Buffered stream":
                            AnsiConsole.MarkupLine("[blue]Converting text to uppercase using Buffered stream[/]");
                            Console.WriteLine("TimeTaken to convert strings to uppercase using BufferedStream: "
                                + (double)fileHandler.ConvertToUpperCaseUsingBufferStream(sourceFilePath, "uppercase.txt") / 1000 + "sec");
                            break;
                        case "Convert text to uppercase using Memory stream":
                            AnsiConsole.MarkupLine("[blue]Converting text to uppercase using Memory stream[/]");
                            Console.WriteLine("TimeTaken to convert strings to uppercase using Memory Stream: "
                                + (double)fileHandler.ConvertToUpperCaseUsingMemoryStream(sourceFilePath, "uppercase.txt") / 1000 + "sec");
                            break;
                        case "Exit":
                            canExit = true;
                            AnsiConsole.MarkupLine("[bold]Exiting...[/]");
                            break;
                    }
                    AnsiConsole.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Execution interrupted!!!\n" + e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Function to get the file name from user
        /// </summary>
        /// <returns>user-entered file-path</returns>
        private static string GetFilePath()
        {
            while (true)
            {
                Console.WriteLine("Enter relative file path (Ex: MainFile.txt): ");
                string filePath = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    Console.WriteLine("File path cannot be empty. Please try again.");
                    continue;
                }
                string extension = Path.GetExtension(filePath);
                if (string.IsNullOrEmpty(extension))
                {
                    return filePath + ".txt";
                }
                if (extension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    return filePath;
                }
                Console.WriteLine("Invalid file extension. Only .txt files are allowed. Please try again.");
            }
        }
    }
}
