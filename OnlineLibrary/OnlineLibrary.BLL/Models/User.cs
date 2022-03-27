using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<BookRent> Rented { get; set; }
        public List<BookRent> History { get; set; }
        public User()
        {
            Rented = new List<BookRent>();
            History = new List<BookRent>();
        }
        
    }
}
