using System.Collections.Generic;

namespace Series.Interfaces
{
    public interface IRepository<T> //generic type
    {
        List<T> List();

        T ReturnById (int id);
        void Insert(T entity);
        void Exclude (int id);
        void Update(int id, T entity);
        int NextId();

    }
}