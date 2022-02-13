using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace OnlineLibrary
{
    public static class ReadData
    {
        public static List<Book> ReadLibraryFromFile()
        {
            string jsonfromFile = File.ReadAllText(@"D:\jcszr5-CultureWariors\jcszr5-CultureWariors\OnlineLibrary\path123.json");
            return JsonSerializer.Deserialize<List<Book>>(jsonfromFile);

        }
        public static List<RegularUser> ReadUsersFromFile()
        {
            string jsonfromFile = File.ReadAllText(@"D:\jcszr5-CultureWariors\jcszr5-CultureWariors\OnlineLibrary\path1234.json");
            return JsonSerializer.Deserialize<List<RegularUser>>(jsonfromFile);
        }
    }
}
