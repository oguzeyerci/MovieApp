using System.Collections.Generic;

namespace filmapp.data.Abstract
{
    public interface IRepo<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}