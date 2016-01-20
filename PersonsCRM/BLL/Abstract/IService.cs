using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface IService<T> where T : class
    {
        T GetCurrent(int? id);
        IEnumerable<T> GetAll();
        void Save(T item);
        void Delete(int? id);
    }
}
