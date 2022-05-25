using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Database
{
    // GET
    public class ApiFreeLecture
    {
        public static async Task GetBooksApi()
        {
            var result = await "https://wolnelektury.pl/api/books/"
                .GetAsync()
                .ReceiveJson<List<Book>>();
        }

        public static async Task GetAuthorApi()
        {
            var result = await "https://wolnelektury.pl/api/authors/"
                .GetAsync()
                .ReceiveJson<List<Author>>();
        }

        public static async Task GetBookTypeApi()
        {
            var result = await "https://wolnelektury.pl/api/kinds/"
                .GetAsync()
                .ReceiveJson<List<BookType>>();
        }

    }
}
