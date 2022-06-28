using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineLibrary.BLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Models
{
    public class RentedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime? RentedTime { get; set; }

        public DateTime? ReturnTime { get; set; }

        public BookStatus Status { get; set; }

    }
}
