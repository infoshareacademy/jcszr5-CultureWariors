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
                        library.ShowFoundBooksByType(library.ChooseTypeToFind());
                        break;
                    case 2:
                        library.ShowFoundBooksByString(library.EnterStringToFind());
                        break;
                    case 3:
                        regularUser.AddBookToFavourites(library.MoveFromLibraryToFavourites());
                        break;
                    case 4:
                        regularUser.ShowFavouritesBooks();
                        break;
                    case 5:
                        library.ShowMeWhatYouGot();
                        break;
                    case 6:
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
                    ConsoleMessages.WrongCommand("6");

                }
                else
                {
                    if (navigate >= 1 && navigate <= 6)
                    {
                        break;
                    }
                    ConsoleMessages.WrongCommand("6");
                }
            }
            return navigate;
        }
    }
}
