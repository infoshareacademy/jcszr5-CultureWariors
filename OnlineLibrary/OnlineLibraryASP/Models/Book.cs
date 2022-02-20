
using OnlineLibraryASP.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryASP.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [Display(Name = "Book type")]
        public BookType BookType { get; set; }
        [Display(Name = "Publication Date")]
        
        public int PublicationDate { get; set; }
    }
}
