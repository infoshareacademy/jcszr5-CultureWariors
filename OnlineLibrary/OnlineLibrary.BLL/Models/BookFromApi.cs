using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Models
{
    public class BookFromApi
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string cover { get; set; }
        public string epoch { get; set; }
        public string genre { get; set; }
        public string simple_thumb { get; set; }
        public Author bookAuthor { get; set; }

    }
}