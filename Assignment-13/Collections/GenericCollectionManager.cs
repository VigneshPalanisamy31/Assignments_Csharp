namespace Collections
{
    internal class GenericCollectionManager
    {
        /// <summary>
        /// Displays menu to choose the generic collection to work with
        /// </summary>
        public void DisplayGenericCollectionOperations()
        {
            while (true)
            {
                Console.WriteLine("Choose the generic collection :\n");
                Helper.WriteInColor("1.List\n2.Stack\n3.Queue\n4.Dictionary\n5.Exit\n", ConsoleColor.Yellow);
                int choice = Validator.GetValidInteger("Enter the choice :");
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Adding books to the list...");
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        List<string> books = new();

                        books.Add("Book_1");
                        books.Add("Book_2");
                        books.Add("Book_3");
                        books.Add("Book_4");
                        books.Add("Book_5");

                        Helper.WriteInColor("\nDisplaying books:\n", ConsoleColor.Yellow);
                        DisplayCollection(books);
                        break;

                    case 2:
                        Helper.WriteInColor("Adding characters to the stack...", ConsoleColor.Green);
                        Stack<char> characters = new();

                        characters.Push('G');
                        characters.Push('e');
                        characters.Push('n');
                        characters.Push('e');
                        characters.Push('r');
                        characters.Push('i');
                        characters.Push('c');
                        characters.Push('s');

                        Helper.WriteInColor("\nDisplaying characters:\n", ConsoleColor.Yellow);
                        DisplayCollection(characters);
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding people to the queue...");
                        Console.ResetColor();
                        Queue<string> people = new();
                        people.Enqueue("Person_1");
                        people.Enqueue("Person_2");
                        people.Enqueue("Person_3");
                        people.Enqueue("Person_4");
                        people.Enqueue("Person_5");

                        Helper.WriteInColor("\nDisplaying people in queue:\n", ConsoleColor.Yellow);
                        DisplayCollection(people);
                        Helper.WriteInColor("\nDequeuing people:\n", ConsoleColor.Yellow);
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding marks to the dictionary...");
                        Console.ResetColor();
                        Dictionary<string, int> marks = new();
                        marks.Add("Student_1", 100);
                        marks.Add("Student_2", 99);
                        marks.Add("Student_3", 98);
                        marks.Add("Student_4", 97);
                        marks.Add("Student_5", 96);
                        Helper.WriteInColor("\nDisplaying marks of students:\n", ConsoleColor.Yellow);
                        DisplayCollection(marks);
                        if (marks.Remove(Validator.GetValidString("Enter the student name to remove :")))
                        {
                            Console.WriteLine("Removed Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        if(marks.ContainsKey(Validator.GetValidString("Enter the student name to search :")))
                        {
                            Console.WriteLine("Student name is available in the dictionary");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;

                    case 5: return;

                    default:
                        Helper.WriteInColor("\nInvalid choice", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Displays all elements of a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Collection to display</param>
        public void DisplayCollection<T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
