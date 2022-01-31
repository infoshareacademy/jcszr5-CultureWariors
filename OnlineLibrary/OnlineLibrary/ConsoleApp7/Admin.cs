using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Admin:User, IMenu
    {

        public Admin(string username="Admin",string password="12345"):base(username,password)
        {

        }
        public bool AdminLogin()
        {
            string usernameCheck;
            string passwordCheck;
            Console.Clear();
            Console.WriteLine("Username:");
            usernameCheck = Console.ReadLine();
            Console.WriteLine("Password:");
            passwordCheck = Console.ReadLine();
            if (usernameCheck == Username && passwordCheck == Password)
            {
                return true;
            }
            return false;
        }

        public void ShowMenu()
        {
            Console.WriteLine("MENU GŁÓWNE\n");
            Console.WriteLine("1: Dodaj książki");
            Console.WriteLine("2: Przeglądaj książki");
            Console.WriteLine("3: Usuń książki");
            Console.WriteLine("4: Edytuj książki");
            Console.WriteLine("5: Zapisz listę");
            Console.WriteLine("6: Wczytaj listę");
            Console.WriteLine("7: Zamknij program");
            Console.WriteLine("\nCo chcesz zrobić? :");
        }
        public int NavigateMenu()
        {
            int navigate;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-7:");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 7)
                    {
                        break;
                    }
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-7:");
                }
            }
            return navigate;
        }
    }
}
