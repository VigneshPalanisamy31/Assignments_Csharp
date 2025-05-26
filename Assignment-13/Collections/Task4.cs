using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Collections
{
    internal class Task4
    {
        Dictionary<string,int> markList = new Dictionary<string,int>();
        public void UnderstandingDictionaries()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============Marks of Students============");
                Console.WriteLine("\n1.Add\n2.Remove\n3.Display\n4.Exit");
                Console.ResetColor();
                int _choice = Validator.GetValidInt("choice");
                switch (_choice)
                {
                    case 1: AddStudentMark(); break;
                    case 2: RemoveStudent(); break;
                    case 3: DisplayMarks(); break;
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
        /// <summary>
        /// Function to add student marks to the mark list dictionary.
        /// </summary>
        public void AddStudentMark()
        {
            int bookCount = Validator.GetValidInt("number of students");
            for (int i = 0; i < bookCount; i++)
            {
                markList.Add(Validator.GetValidString($"name of student {i + 1}"),Validator.GetValidInt("mark"));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nStudents added successfully");
            Console.ResetColor();
        }
        /// <summary>
        /// Function to remove student marks from the mark list dictionary.
        /// </summary>
        public void RemoveStudent()
        {
            string nameToBeRemoved = Validator.GetValidString("name to be removed");
            if (markList.TryGetValue(nameToBeRemoved,out int mark))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{nameToBeRemoved}  :  {mark}");
                Console.WriteLine("\nStudent deleted from List successfully..");
                Console.ResetColor();
                markList.Remove(nameToBeRemoved);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nStudent not found\nDelete failed...");
                Console.ResetColor();
            }

        }
        /// <summary>
        /// Function to display student marks from the mark list dictionary.
        /// </summary>
        public void DisplayMarks()
        {
            if (markList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo marks available");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Marks of students\n");
                Console.WriteLine("\nStudent name :  Mark");
                Console.ResetColor();
                foreach (var mark in markList)
                {
                    Console.WriteLine($"{mark.Key}  :  {mark.Value}");
                }
            }
        }
    }
}
