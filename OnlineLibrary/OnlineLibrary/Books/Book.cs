namespace OnlineLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookType Type { get; set; }

        public Book(BookType type, string title, string author)
        {
            Title = title;
            Author = author;
            Type = type;
        }
        public static Book CreateBook()
        {
            Console.Clear();
            Book book = new Book(ChooseType(), Helper.GetTitle(), Helper.GetAuthor()); ;
            Console.Clear();
            return book;
        }

        public static BookType ChooseType()
        {
            Console.Clear();
            while (true)
            {
                ConsoleMessages.ChooseCategoryMessage();
                switch (Console.ReadLine())
                {
                    case "1":
                        return BookType.Fantastyka; ;
                    case "2":
                        return BookType.Kryminał;
                    case "3":
                        return BookType.Romans;
                    case "4":
                        return BookType.Naukowa;
                    case "5":
                        return BookType.Dramat;
                    case "6":
                        return BookType.Dziecięca;
                    case "7":
                        return BookType.Obyczajowa;
                    default:
                        ConsoleMessages.ChooseTheRightCategory();
                        continue;
                }
            }
        }
    }
}
