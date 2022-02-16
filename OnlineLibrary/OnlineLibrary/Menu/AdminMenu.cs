using System.Text.Json;

namespace OnlineLibrary
{
    public class AdminMenu : IMenu
    {
        public void AdminUser(Admin admin, Library library)
        {

            while (true)
            {
                Console.Clear();
                ShowMenu();
                string jsonLibrary = JsonSerializer.Serialize(library.library);
                switch (NavigateMenu())
                {
                    case 1:
                        library.AddBookToLibrary(Book.CreateBook());
                        WriteData.WriteLibraryToFile(library);
                        break;
                    case 2:
                        library.ShowFoundBooks(library.ChooseTypeToFind());
                        break;
                    case 3:
                        library.DeleteBookFromLibrary();
                        WriteData.WriteLibraryToFile(library);
                        break;
                    case 4:
                        library.EditBookFromLibrary();
                        WriteData.WriteLibraryToFile(library);
                        break;
                    case 5:
                        Console.Clear();
                        return;


                }

            }
        }
        public void ShowMenu()
        {
            ConsoleMessages.AdminMenu();
        }

        public int NavigateMenu()
        {
            int navigate;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    ConsoleMessages.WrongCommand("5");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 7)
                    {
                        break;
                    }
                    ConsoleMessages.WrongCommand("5");
                }
            }
            return navigate;
        }
    }
}
