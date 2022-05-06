using OnlineLibrary;

Console.WriteLine("Witaj w bibliotece online\n");
Admin admin = new Admin();
AdminMenu adminMenu = new AdminMenu();
UsersList usersList = new UsersList();
usersList.Users = ReadData.ReadUsersFromFile();
LoginMenu loginMenu = new LoginMenu();
RegularUserMenu regularUserMenu = new RegularUserMenu();
Library library = new Library();
library.library = ReadData.ReadLibraryFromFile();
loginMenu.Login(adminMenu, regularUserMenu, admin, library, usersList);










