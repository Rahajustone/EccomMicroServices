using ProductCatalog.Domain;
using ProductCatalog.Repositories;

namespace ProductCatalog.BusinessObjects
{
    public class CatalogItemBO : ICatalogItemBO
    {
        private readonly ICatalogItemRepository _repository;

        public CatalogItemBO(ICatalogItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<CatalogItem> AddItem(CatalogItem item)
        {
            return await _repository.AddItem(item);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<CatalogItem> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<IEnumerable<CatalogItem>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task Update(CatalogItem item)
        {
            await _repository.Update(item);
        }
    }
}
