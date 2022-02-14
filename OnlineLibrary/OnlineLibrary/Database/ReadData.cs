using System.Text.Json;

namespace OnlineLibrary
{
    public static class ReadData
    {
        public static List<Book> ReadLibraryFromFile()
        {
            string jsonfromFile = File.ReadAllText(@"..\..\..\Data\path123.json");
            return JsonSerializer.Deserialize<List<Book>>(jsonfromFile);

        }
        public static List<RegularUser> ReadUsersFromFile()
        {
            string jsonfromFile = File.ReadAllText(@"..\..\..\Data\path1234.json");
            return JsonSerializer.Deserialize<List<RegularUser>>(jsonfromFile);
        }
    }
}
