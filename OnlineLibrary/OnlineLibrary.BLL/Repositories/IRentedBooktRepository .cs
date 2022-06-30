using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IRentedBookRepository 
    {
        public List<RentedBook> GetAll();

        public void Create(RentedBook book);

        public RentedBook GetById(int id);

        public void Delete(int id);

        //public void Relasing(RentedBook model);

        public void ToRelasing(RentedBook model);

        public void ToRenting(RentedBook model);

        public void ToReturnig(RentedBook model);



    }
}