using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Task5
    {
        public void GenericCollectionOperations()
        {
            while (true)
            {
                Console.WriteLine("Choose the generic collection :\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1.List\n2.Stack\n3.Queue\n4.Dictionary\n5.Exit\n");
                Console.ResetColor();
                int _choice = Validator.GetValidInt("choice");
                switch (_choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Adding books to the generic list");
                        for(int i=0;i<3;i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        GenericCollection<string> list = new GenericCollection<string>("list");
                        list.Add("Book_1");
                        list.Add("Book_2");
                        list.Add("Book_3");
                        list.Add("Book_4");
                        list.Add("Book_5");
                        Thread.Sleep(1000);
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.WriteLine("\nDisplaying books:\n");
                        Console.ResetColor ();
                        list.Display();
                        Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nRemoving books:\n");
                        Console.ResetColor();
                        list.Remove();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine("Adding characters to the generic stack");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                            GenericCollection<char> stack = new GenericCollection<char>("stack");
                        stack.Add('G'); stack.Add('e'); stack.Add('n'); stack.Add('e'); stack.Add('r'); stack.Add('i'); stack.Add('c'); stack.Add('s');
                        Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nDisplaying characters:\n");
                        Console.ResetColor();
                        stack.Display();
                        Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nRemoving books:\n");
                        Console.ResetColor();
                        stack.Remove();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding people to the generic queue");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.ResetColor();
                        GenericCollection<string> queue = new GenericCollection<string>("queue");
                        queue.Add("Person_1");
                        queue.Add("Person_2");
                        queue.Add("Person_3");
                        queue.Add("Person_4");
                        queue.Add("Person_5");
                        Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nDisplaying people in queue:\n");
                        Console.ResetColor();
                        queue.Display();
                        Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nDequeuing people:\n");
                        Console.ResetColor();
                        queue.Remove();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding marks to the generic dictionary");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.ResetColor();
                        GenericDictionary<string, int> dict = new GenericDictionary<string, int>();
                        dict.Add("Student_1", 100);
                        dict.Add("Student_2", 99);
                        dict.Add("Student_3", 98);
                        dict.Add("Student_4", 97);
                        dict.Add("Student_5", 96);
                        Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nDisplaying marks of students:\n");
                        Console.ResetColor();
                        dict.Display();
                        Thread.Sleep(1000);
                        dict.Remove(Validator.GetValidString("student name to be removed.."));
                        dict.Search(Validator.GetValidString("student name to be searched.."));
                        break;
                    case 5:return;
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
