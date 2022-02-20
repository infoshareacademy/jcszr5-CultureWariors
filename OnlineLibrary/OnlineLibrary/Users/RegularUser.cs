namespace OnlineLibrary
{
    public class RegularUser : User
    {
        private List<Book> favouriteBooks = new List<Book>();

        public RegularUser(string username, string password) : base(username, password)
        {

        }
        public void AddBookToFavourites(Book book)
        {
            Console.Clear();
            if (book == null)
            {
                return;
            }
            favouriteBooks.Add(book);
            ConsoleMessages.SuccesMessage("dodano");
            Console.Clear();
        }

        public void ShowFavouritesBooks()
        {
            Console.Clear();
            Console.WriteLine("Wypożyczane książki: ");
            int a = 0;
            foreach (var book in favouriteBooks)
            {
                a++;
                Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
            }
            Console.WriteLine("Naciśnij dowolny przycisk by kontynuować");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
