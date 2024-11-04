using System.Collections.Generic;

namespace poo_tp_29559.Interfaces
{
    public interface IRepo<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
