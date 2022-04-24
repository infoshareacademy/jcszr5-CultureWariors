using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibrary.BLL.Models;


namespace OnlineLibraryASP.ViewModels
{
    public class BookCreateViewModel
    {
        public Book Book { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AuthorsList { get; set; }
        
    }
}
