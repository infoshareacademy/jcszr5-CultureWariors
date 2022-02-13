using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace OnlineLibrary
{
    public static class WriteData
    {
        public static void WriteLibraryToFile(Library library)
        {
            string jsonLibrary = JsonSerializer.Serialize(library.library);
            File.WriteAllText(@"..\path123.json", jsonLibrary);
            
        }
        public static void WriteUsersToFile(UsersList userslist)
        {
            string jsonUsers = JsonSerializer.Serialize(userslist.Users);
            File.WriteAllText(@"..\path123.json", jsonUsers);
        }
    }
}
