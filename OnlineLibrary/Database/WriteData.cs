using System.Text.Json;

namespace OnlineLibrary
{
    public static class WriteData
    {
        public static void WriteLibraryToFile(Library library)
        {
            string jsonLibrary = JsonSerializer.Serialize(library.library);
            File.WriteAllText(@"..\..\..\Data\path123.json", jsonLibrary);

        }
        public static void WriteUsersToFile(UsersList userslist)
        {
            string jsonUsers = JsonSerializer.Serialize(userslist.Users);
            File.WriteAllText(@"..\..\..\Data\path1234.json", jsonUsers);
        }
    }
}
