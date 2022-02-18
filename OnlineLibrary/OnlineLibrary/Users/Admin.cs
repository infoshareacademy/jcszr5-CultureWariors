using System.Security;
namespace OnlineLibrary
{
    public class Admin : User
    {

        public Admin(string username = "Admin", string password = "12345") : base(username, password)
        {

        }
        public bool AdminLogin()
        {
            string username = Helper.GetUsername();
            string password = Helper.GetPassword();
            Console.Clear();
            if (username == Username && password == Password)
            {
                return true;
            }
            return false;
        }
    }
}
