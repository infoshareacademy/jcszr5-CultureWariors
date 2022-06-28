using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IRentedBookRepository 
    {
        public List<RentedBook> GetAll();
        public void Create(RentedBook book);
        public RentedBook GetById(int id);
        public void Delete(int id);
        public void UpdateStatus(RentedBook model);

    }
}