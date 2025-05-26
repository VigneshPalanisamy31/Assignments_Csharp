using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Working with Lists\n2.Using Stacks\n3.Working with Queues\n4.Understanding Dictionaries\n5.Generics\n6.IEnumerable & IReadOnlyDictionary\n7.Exit\n");
                int _choice = Validator.GetValidInt("choice");
                switch (_choice)
                {
                    case 1:
                        Task1 task1 = new Task1();
                        task1.WorkingWithLists();
                        break;
                    case 2:
                        Task2 task2 = new Task2();
                        task2.UsingStacks(); break;
                    case 3:
                        Task3 task3 = new Task3();
                        task3.WorkingWithQueues(); break;
                    case 4:
                        Task4 task4 = new Task4();
                        task4.UnderstandingDictionaries(); break;
                    case 5:
                        Task5 task5 = new Task5();
                        task5.GenericCollectionOperations(); break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Testing sum of elements..\n");
                        Console.ResetColor();
                        Task6.TestSumOfElements();
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Generate Dictionary...\n");
                        Console.ResetColor();
                        IReadOnlyDictionary<string, int> dict = Task6.GenerateDictionary();
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Print Dictionary...\n");
                        Console.ResetColor();
                        Task6.PrintDictionary(dict);
                        Thread.Sleep(2000);
                        Task6.AttemptToModifyDictionary(dict);
                        break;
                        
                    case 7:return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }



        }
    }
}
