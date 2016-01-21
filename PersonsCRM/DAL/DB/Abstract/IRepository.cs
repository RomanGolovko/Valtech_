using System.Collections.Generic;

namespace DAL.DB.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Delete(int id);
    }
}
