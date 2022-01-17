using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class Book
    {
        private string title;
        private string author;
        private string type;

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string Author{
            get
            {
                return this.author;
            }
            set { this.author = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public Book()
        {

        }
        public int ChooseType()
        {
            int choose;
            string chooseCheck;
            while (true)
            {
                chooseCheck = Console.ReadLine();
                if (!int.TryParse(chooseCheck, out choose))
                {
                    Console.WriteLine("Proszę wybrać kategorie wpisując jej numer");
                }

                else if (choose <= 0 || choose >= 8)
                {
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
                    return this.type = "Fantastyka";
                case 2:
                   return this.type = "Kryminał";
                case 3:
                    return this.type = "Romans";
                case 4:
                    return this.type = "Naukowa";
                case 5:
                    return this.type = "Dramat";
                case 6:
                    return this.type = "Dziecięca";
                case 7:
                    return this.type = "Obyczajowa";
            }

            return this.type;
        }
    }
}
