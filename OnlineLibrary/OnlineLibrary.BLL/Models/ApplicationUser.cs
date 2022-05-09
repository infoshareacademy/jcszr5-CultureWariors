using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
                RentedBooks = new List<Book>();
        }
        [Required]
        public string Name { get; set; }

        public string? Surname { get; set; }

        public string? StreetAdress { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }
        public List<Book> RentedBooks { get; set; }
    }
}
