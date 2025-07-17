namespace Collections
{
    public class BooksManager
    {
        private List<string> _books = new List<string>();

        /// <summary>
        /// Adds books to the list
        /// </summary>
        public void AddBooks()
        {
            int bookCount = Validator.GetValidInteger("Enter the number of books :");
            for (int i = 0; i < bookCount; i++)
            {
                _books.Add(Validator.GetValidString($"Enter the name of book{i + 1} :"));
            }
            Helper.WriteInColor("\nBooks added successfully", ConsoleColor.Green);
        }

        /// <summary>
        /// Searches for a book in the list
        /// </summary>
        /// <returns>Book name or empty string</returns>
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
                Helper.WriteInColor("\nCould not find the specified book.", ConsoleColor.Red);
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
