using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineLibrary.BLL.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.BLL.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide book title")]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [ValidateNever]
        public virtual Author Author { get; set; }

        [Display(Name = "Book type")]
        [Required(ErrorMessage = "Please provide book type")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string BookType { get; set; }
        [Required(ErrorMessage = "Please provide epoch")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Epoch { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }



        //public List<Review> Reviews { get; set; }
    }

    //public class Review
    //{
    //    public string BookId { get; set; }
    //    public string UserId { get; set; }
    //    public int Score { get; set; } // 1-10
    //    public string Comment { get; set; }
    //}

    //public class BookRent
    //{
    //    public string UserId { get; set; }
    //    public string BookId { get; set; }
    //    public DateTime From { get; set; }
    //    public DateTime To { get; set; }
    //}
}