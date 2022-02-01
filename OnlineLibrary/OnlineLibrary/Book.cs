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

        public Book()
        {

        }
        public int ChooseType()
        {
            int choose;
            string chooseCheck;
            Console.Clear();
            while (true)
            {
                
                Console.WriteLine("Proszę dokonać wyboru kategorii z poniższej listy:");
                Console.WriteLine("1 Fantastyka");
                Console.WriteLine("2 Kryminał");
                Console.WriteLine("3 Romans");
                Console.WriteLine("4 Naukowa");
                Console.WriteLine("5 Dramat");
                Console.WriteLine("6 Dziecięca");
                Console.WriteLine("7 Obyczajowa");
                chooseCheck = Console.ReadLine();
                if (!int.TryParse(chooseCheck, out choose))
                {
                    Console.Clear();
                    Console.WriteLine("Proszę wybrać właściwą kategorię");
                }

                else if (choose <= 0 || choose >= 8)
                {
                    Console.Clear();
                    Console.WriteLine("Proszę wybrać właściwą kategorię");
                }
                else
                {
                    return choose;
                }
            }
            
        }

        public string Types(int choose)
        {
            switch (choose)
            {
                case 1:
                    return this.Type = "Fantastyka";
                case 2:
                   return this.Type = "Kryminał";
                case 3:
                    return this.Type = "Romans";
                case 4:
                    return this.Type = "Naukowa";
                case 5:
                    return this.Type = "Dramat";
                case 6:
                    return this.Type = "Dziecięca";
                case 7:
                    return this.Type = "Obyczajowa";
            }

            return this.Type;
        }
    }
}
