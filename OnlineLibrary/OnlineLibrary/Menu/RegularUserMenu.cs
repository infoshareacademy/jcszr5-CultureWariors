using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class RegularUserMenu:IMenu
    {
        public void RegularUser(RegularUser regularUser,Library library)
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
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 4)
                    {
                        break;
                    }
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
            }
            return navigate;
        }
    }
}
