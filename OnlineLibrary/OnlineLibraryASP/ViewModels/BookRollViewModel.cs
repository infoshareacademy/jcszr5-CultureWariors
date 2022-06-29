using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineLibraryASP.ViewModels
{
    public class BookRollViewModel
    {
        public List<string>? BookType { get; set; }
        public SelectList? Types { get; set; }

    }
}
