using System;
using System.Collections.Generic;

namespace Staff.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(Guid id);
        void Insert(T entity);
        void Delete(Guid id);
        void Update(T entity);
    }
}