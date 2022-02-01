using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class LoginMenu : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("Witaj w bibliotece online\n");
            Console.WriteLine("1 Zaloguj się");
            Console.WriteLine("2 Zarejestruj się");
            Console.WriteLine("3 Administrator");
            Console.WriteLine("4 Wyjdź");
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
