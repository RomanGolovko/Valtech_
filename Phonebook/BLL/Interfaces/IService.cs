using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll(string userId);
        T Get(int? id);
        void Save(T item);
        void Delete(int? id);
    }
}
