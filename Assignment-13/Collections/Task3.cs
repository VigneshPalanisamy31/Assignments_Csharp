using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Collections
{
    internal class Task3
    {
        Queue<string> people = new Queue<string>();
        public void WorkingWithQueues()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============Queue of People============");
                Console.WriteLine("\n1.Add\n2.Remove\n3.Display\n4.Exit");
                Console.ResetColor();
                int _choice = Validator.GetValidInt("choice");
                switch (_choice)
                {
                    case 1: Enqueue(); break;
                    case 2: Dequeue(); break;
                    case 3: DisplayPeople(); break;
                    case 4:
                        exit = true;
                        Console.WriteLine("Exiting"); break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();
            }


        }
        public void Enqueue()
        {
            Console.WriteLine("Enter the number of people to be queued...");
            int queueSize = Validator.GetValidInt("size");
            for (int i = 0; i < queueSize; i++)
            {
                people.Enqueue(Validator.GetValidString($"name of person {i+1}"));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nQueue created successfully..");
            Console.ResetColor();
        }

        public void Dequeue()
        {
            if (people.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nQueue is empty..");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Dequeued person : {people.Dequeue().ToString()}");
                Console.WriteLine("\nDequeue successful..");
                Console.ResetColor();
            }

        }

        public void DisplayPeople()
        {
            if (people.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nQueue Empty");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Queue Of People\n");
                Console.ResetColor();
                foreach (var person in people)
                {
                    Console.WriteLine($"\n{person}");
                }
            }
        }
    }
}
