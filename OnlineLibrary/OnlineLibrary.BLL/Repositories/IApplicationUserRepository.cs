using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IApplicationUserRepository :IRepository<ApplicationUser>
    {
        public List<ApplicationUser> GetAll();

        public void Create(ApplicationUser user);

    }
}