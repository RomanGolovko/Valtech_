using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int? id);
        IEnumerable<T> Find(Func<T, bool> predicat);
        void Save(T item);
        void Delete(int? id);
    }
}
