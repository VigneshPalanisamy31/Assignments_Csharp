namespace Collections
{
    public class BookListManager
    {
        private List<string> _books = new List<string>();
        /// <summary>
        /// Displays menu to work with lists
        /// </summary>
        public void WorkingWithLists()
        {
            bool canExit = false;
            while (!canExit)
            {
                Console.Clear();
                Helper.WriteInColor("============List of Books============", ConsoleColor.Yellow);
                Helper.WriteInColor("\n1.Add\n2.Remove\n3.Search\n4.Display\n5.Exit", ConsoleColor.Yellow);
                int choice = Validator.GetValidInt("Enter the choice :");
                switch (choice)
                {
                    case 1:
                        AddBooks();
                        break;

                    case 2:
                        RemoveBook();
                        break;

                    case 3:
                        SearchBook();
                        break;

                    case 4:
                        DisplayBooks();
                        break;

                    case 5:
                        canExit = true;
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Helper.WriteInColor("\nInvalid choice", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Adds books to the list
        /// </summary>
        public void AddBooks()
        {
            int bookCount = Validator.GetValidInt("Enter the number of books :");
            for (int i = 0; i < bookCount; i++)
            {
                _books.Add(Validator.GetValidString($"Enter the name of book{i + 1} :"));
            }
            Helper.WriteInColor("\nBooks added successfully", ConsoleColor.Green);
        }

        /// <summary>
        /// Searches for a book in the list
        /// </summary>
        /// <returns></returns>
        public string SearchBook()
        {
            string bookToSearch = Validator.GetValidString("Enter the name of the book :");
            if (_books.Contains(bookToSearch))
            {
                Helper.WriteInColor("\nBook name is available in the list", ConsoleColor.Green);
                return bookToSearch;
            }
            else
            {
                Helper.WriteInColor("\nBook name is not available in the list", ConsoleColor.Red);
                return string.Empty;
            }
        }

        /// <summary>
        /// Removes a book from the list.
        /// </summary>
        public void RemoveBook()
        {
            if (_books.Remove(SearchBook()))
            {
                Helper.WriteInColor("\nBook deleted from List successfully..", ConsoleColor.Green);
            }
            else
            {
                Helper.WriteInColor("\nDelete failed..", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Displays all books in the list
        /// </summary>
        public void DisplayBooks()
        {
            if (!_books.Any())
            {
                Helper.WriteInColor("\nBook list is empty", ConsoleColor.Yellow);
            }
            else
            {
                Helper.WriteInColor("List Of Books\n", ConsoleColor.Yellow);
                for (int i = 0; i < _books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_books[i]}");
                }
            }
        }
    }
}
