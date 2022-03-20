using OnlineLibrary.BLL.Models;

namespace OnlineLibraryASP.ViewModels
{
    public class CreateSearchViewModel
    {
        public List<Book> Books { get; set; }
        public List<string> BookType { get; set; }

        public CreateSearchViewModel()
        {
            BookType = new List<string>()
            {
        "Fantastyka",
        "Kryminał",
        "Romans",
        "Naukowa",
        "Dramat",
        "Dziecięca",
        "Obyczajowa"

            };
        }
    }
}
