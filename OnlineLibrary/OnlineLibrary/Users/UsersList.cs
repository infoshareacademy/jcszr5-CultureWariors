namespace OnlineLibrary
{
    public class UsersList
    {
        public List<RegularUser> Users { get; set; }
        public UsersList()
        {
            Users = new List<RegularUser>();
        }
        public void AddUser()
        {
            RegularUser user = CreateUser();
            if (user != null)
            {
                Users.Add(user);
                Console.WriteLine("Pomyślnie dodano użytkownika, naciśnij dowolny przycisk aby kontynuować");
                Console.ReadKey();
                Console.Clear();
            }
            else return;

        }
        public RegularUser GetRegularUser(string username, string password)
        {

            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;

        }

        public RegularUser CreateUser()
        {
            string username;
            string password;
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Wprowadź nazwę użytkownika: ");
                username = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Wprowadź hasło: ");
                password = Console.ReadLine();
                if (Helper.CreateUserValidation(username, password, Users))
                {
                    RegularUser user = new RegularUser(username, password);
                    Console.Clear();
                    return user;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
