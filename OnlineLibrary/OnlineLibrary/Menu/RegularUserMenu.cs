namespace OnlineLibrary
{
    public class RegularUserMenu : IMenu
    {
        public void RegularUser(RegularUser regularUser, Library library)
        {

            Console.Clear();
            while (true)
            {
                ShowMenu();
                switch (NavigateMenu())
                {
                    case 1:
                        library.ShowFoundBooks(library.ChooseTypeToFind());
                        break;
                    case 2:
                        regularUser.AddBookToFavourites(library.MoveFromLibraryToFavourites());
                        break;
                    case 3:
                        regularUser.ShowFavouritesBooks();
                        break;
                    case 4:
                        Console.Clear();
                        return;
                }
            }
        }
        public void ShowMenu()
        {
            ConsoleMessages.RegularUserMenu();
        }
        public int NavigateMenu()
        {
            int navigate;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    ConsoleMessages.WrongCommand("4");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 4)
                    {
                        break;
                    }
                    ConsoleMessages.WrongCommand("4");
                }
            }
            return navigate;
        }
    }
}
