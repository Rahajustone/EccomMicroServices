using ProductCatalog.Repositories;

namespace ProductCatalog.BusinessObjects
{

    public class GenericBO<T> : IGenericBO<T>
    {
        private readonly IGenericRepository<T> _repository;

        public GenericBO(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async virtual Task<T> Add(T item)
        {
            return await _repository.AddItem(item);
        }

        public async virtual Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async virtual Task<T> Get(int id)
        {
            return await _repository.GetItem(id);
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetItems();
        }

        public async virtual Task Update(T item)
        {
            await _repository.Update(item);
        }
    }
}
