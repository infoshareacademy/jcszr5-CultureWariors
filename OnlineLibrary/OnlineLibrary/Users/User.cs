namespace OnlineLibrary
{
    public abstract class User
    {

        public string Username { get; set; }
        public string Password { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
