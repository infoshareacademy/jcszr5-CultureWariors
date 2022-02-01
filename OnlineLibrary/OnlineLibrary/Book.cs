using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public string ChooseType()
        {
            string choose;
            string type;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Proszę dokonać wyboru kategorii z poniższej listy:\n");
                Console.WriteLine("1 Fantastyka");
                Console.WriteLine("2 Kryminał");
                Console.WriteLine("3 Romans");
                Console.WriteLine("4 Naukowa");
                Console.WriteLine("5 Dramat");
                Console.WriteLine("6 Dziecięca");
                Console.WriteLine("7 Obyczajowa");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        return type = "Fantastyka";
                    case "2":
                        return type = "Kryminał";
                    case "3":
                        return type = "Romans";
                    case "4":
                        return type = "Naukowa";
                    case "5":
                        return type = "Dramat";
                    case "6":
                        return type = "Dziecięca";
                    case "7":
                        return type = "Obyczajowa";
                    default:
                        Console.WriteLine("Proszę wybrać właściwą kategorię");
                        continue;

                }


            }
        }
    }
}
