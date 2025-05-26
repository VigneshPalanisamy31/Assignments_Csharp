using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Collections
{
    public  class Task1
    {
        List<string> books = new List<string>();
        public void WorkingWithLists()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============List of Books============");
                Console.WriteLine("\n1.Add\n2.Remove\n3.Search\n4.Display\n5.Exit");
                Console.ResetColor();
                int _choice = Validator.GetValidInt("choice");
                switch (_choice)
                {
                    case 1: AddBooks(); break;
                    case 2: RemoveBook(); break;
                    case 3: SearchBook(); break;
                    case 4: DisplayBooks(); break;
                    case 5: exit = true; 
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
        public void AddBooks()
        {
            int bookCount = Validator.GetValidInt("number of books");
            for (int i = 0; i < bookCount; i++)
            {
                books.Add(Validator.GetValidString($"name of book{i + 1}"));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBooks added successfully");
            Console.ResetColor();
        }
        public string SearchBook()
        {
            string bookToSearch = Validator.GetValidString("name of the book");
            if (books.Contains(bookToSearch))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nBook name available in the list");
                Console.ResetColor();
                return bookToSearch;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBook name is not available in the list");
                Console.ResetColor();
                return "";
            }
        }
        public void RemoveBook()
        {
            if (!SearchBook().Equals(""))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nBook deleted from List successfully..");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDelete failed..");
                Console.ResetColor();
            }

        }

        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo Books Available");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("List Of Books\n");
                Console.ResetColor();
                for(int i=0;i<books.Count;i++) 
                {
                    Console.WriteLine($"{i+1}. {books[i]}");
                }
            }
        }
    }
}
