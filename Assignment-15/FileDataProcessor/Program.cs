using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileDataHandler fileHandler = new FileDataHandler();
            string sourceFile = ValidateFilePath(GetFilePath());
            fileHandler.CreateLargeFile(1, sourceFile);
            Console.WriteLine("File created successfully!!!");

            Console.WriteLine("File reading started for chunks method");
            Console.WriteLine("TimeTaken to read file as chunks: "
                + (double)fileHandler.ReadFileUsingFileStream(sourceFile) / 1000 + "sec");

            Console.WriteLine("File reading started for bufferStream method");
            Console.WriteLine("TimeTaken to read file using BufferStream: "
                + (double)fileHandler.ReadFileUsingBufferedStream(sourceFile) / 1000 + "sec");

            bool exit = false;
            while (!exit)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Please select an option (use arrows):[/]")
                        .PageSize(10)
                        .AddChoices(new[] {
                        "Convert text to uppercase using File stream",
                        "Convert text to uppercase using Buffered stream",
                        "Convert text to uppercase using Memory stream",
                        "Exit"
                        }));

                switch (choice)
                {
                    case "Convert text to uppercase using File stream":
                        AnsiConsole.MarkupLine("[blue]Converting text to uppercase using File stream[/]");
                        Console.WriteLine("TimeTaken to convert strings to uppercase using chunks: "
                            + (double)fileHandler.ConvertToUpperCaseUsingChunks(sourceFile, "uppercase.txt") / 1000 + "sec");
                        break;
                    case "Convert text to uppercase using Buffered stream":
                        AnsiConsole.MarkupLine("[blue]Converting text to uppercase using Buffered stream[/]");
                        Console.WriteLine("TimeTaken to convert strings to uppercase using BufferedStream: "
                            + (double)fileHandler.ConvertToUpperCaseUsingBufferStream(sourceFile, "uppercase.txt") / 1000 + "sec");
                        break;
                    case "Convert text to uppercase using Memory stream":
                        AnsiConsole.MarkupLine("[blue]Converting text to uppercase using Memory stream[/]");
                        Console.WriteLine("TimeTaken to convert strings to uppercase using Memory Stream: "
                            + (double)fileHandler.ConvertToUpperCaseUsingMemoryStream(sourceFile, "uppercase.txt") / 1000 + "sec");
                        break;
                    case "Exit":
                        exit = true;
                        AnsiConsole.MarkupLine("[bold]Exiting...[/]");
                        break;
                }
                AnsiConsole.WriteLine();
            }


        }

        private static string GetFilePath()
        {
            Console.WriteLine("Enter relative file path (Eg: 'largeTextFile.txt'): ");
            return Console.ReadLine();
        }
        private static string ValidateFilePath(string filePath)
        {
            if (filePath.Contains(".txt"))
            {
                return filePath;
            }
            return filePath + ".txt";
        }
    }
}
