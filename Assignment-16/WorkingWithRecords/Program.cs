namespace WorkingWithRecords
{  
        public record Book(string Title, string Author, string ISBN);
        class Program
        {
        static void Main(string[] args)
        {
            try {
                Book book1 = new Book("KGF-I", "Krishnappa beriya", "1234567890");
                Book book2 = new Book("KGF-II", "Rocky", "0987654321");
                Console.WriteLine("Original Books:");
                DisplayBook(book1);
                DisplayBook(book2);
                Book book3 = new Book("KGF-I", "Krishnappa beriya", "1234567890");
                Console.WriteLine("\nbook1 == book3? " + (book1 == book3)); // True
               //book1.Title = "New Title"; 
               //(record properties are init-only and can only be assigned in an object initializer)
                Book updatedBook = book1 with { Title = "KGF-1951" };
                Console.WriteLine("\nOriginal and Updated Books (with expression):");
                DisplayBook(book1);
                DisplayBook(updatedBook);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
            static void DisplayBook(Book book)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
            }
        }
    }

