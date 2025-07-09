namespace Collections
{
    internal class GenericCollectionManager
    {
        /// <summary>
        /// Displays menu to choose the generic collection to work with
        /// </summary>
        public void GenericCollectionOperations()
        {
            while (true)
            {
                Console.WriteLine("Choose the generic collection :\n");
                Helper.WriteInColor("1.List\n2.Stack\n3.Queue\n4.Dictionary\n5.Exit\n", ConsoleColor.Yellow);
                int choice = Validator.GetValidInt("Enter the choice :");
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Adding books to the list...");
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        GenericCollection<string> books = new GenericCollection<string>(CollectionType.List);

                        books.Add("Book_1");
                        books.Add("Book_2");
                        books.Add("Book_3");
                        books.Add("Book_4");
                        books.Add("Book_5");

                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nDisplaying books:\n", ConsoleColor.Yellow);
                        books.Display();
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nRemoving books:\n", ConsoleColor.Yellow);
                        books.RemoveAll();
                        break;

                    case 2:
                        Helper.WriteInColor("Adding characters to the stack...", ConsoleColor.Green);
                        GenericCollection<char> characters = new GenericCollection<char>(CollectionType.Stack);

                        characters.Add('G');
                        characters.Add('e');
                        characters.Add('n');
                        characters.Add('e');
                        characters.Add('r');
                        characters.Add('i');
                        characters.Add('c');
                        characters.Add('s');

                        Helper.WriteInColor("\nDisplaying characters:\n", ConsoleColor.Yellow);
                        characters.Display();
                        Thread.Sleep(1000);
                        Helper.WriteInColor("\nRemoving books:\n", ConsoleColor.Yellow);
                        characters.RemoveAll();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding people to the queue...");
                        Console.ResetColor();
                        GenericCollection<string> people = new GenericCollection<string>(CollectionType.Queue);
                        people.Add("Person_1");
                        people.Add("Person_2");
                        people.Add("Person_3");
                        people.Add("Person_4");
                        people.Add("Person_5");

                        Helper.WriteInColor("\nDisplaying people in queue:\n", ConsoleColor.Yellow);
                        people.Display();
                        Helper.WriteInColor("\nDequeuing people:\n", ConsoleColor.Yellow);
                        people.RemoveAll();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adding marks to the dictionary...");
                        Console.ResetColor();
                        GenericDictionary<string, int> marks = new GenericDictionary<string, int>();
                        marks.Add("Student_1", 100);
                        marks.Add("Student_2", 99);
                        marks.Add("Student_3", 98);
                        marks.Add("Student_4", 97);
                        marks.Add("Student_5", 96);
                        Helper.WriteInColor("\nDisplaying marks of students:\n", ConsoleColor.Yellow);
                        marks.Display();
                        marks.Remove(Validator.GetValidString("Enter the student name to be removed :"));
                        marks.Search(Validator.GetValidString("Enter the student name to be searched :"));
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
    }
}
