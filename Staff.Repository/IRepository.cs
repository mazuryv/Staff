using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staff.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(Guid id);
        Task InsertAsync(T entity);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}