using System;
using ProductCatalog.Domain;

namespace ProductCatalog.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetItems();
        Task<T> GetItem(int id);
        Task<T> AddItem(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}

