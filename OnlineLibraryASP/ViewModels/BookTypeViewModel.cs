using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibrary.BLL.Models;

namespace OnlineLibraryASP.ViewModels
{
    public class BookTypeViewModel
    {
        public List<Book>? Books { get; set; }
        public SelectList? Types { get; set; }
        public string? BookType { get; set; }
        public string? SearchString { get; set; }
        public string? SearchAuthor { get; set; }
    }
}
