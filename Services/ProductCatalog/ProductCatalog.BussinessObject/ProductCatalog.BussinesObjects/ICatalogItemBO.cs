using System;
using System.Threading.Tasks;
using ProductCatalog.Domain;

namespace ProductCatalog.BusinessObjects
{
    public interface ICatalogItemBO
    {
        Task<IEnumerable<CatalogItem>> GetItems();
        Task<CatalogItem> GetItem(int id);
        Task<CatalogItem> AddItem(CatalogItem item);
        Task Update(CatalogItem item);
        Task Delete(int id);
    }
}
