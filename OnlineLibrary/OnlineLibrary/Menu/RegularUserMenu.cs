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
                        library.ShowMeWhatYouGot();
                        break;
                    case 5:
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
                    ConsoleMessages.UserAndLoginWrongCommand();
                }
                else
                {
                    if (navigate >= 1 && navigate <= 5)
                    {
                        break;
                    }
                    ConsoleMessages.UserAndLoginWrongCommand();
                }
            }
            return navigate;
        }
    }
}
