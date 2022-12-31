namespace ProductCatalog.BusinessObjects
{
    public interface IGenericBO<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
