using System;
using ProductCatalog.Domain;

namespace ProductCatalog.Repositories
{
    public interface ICatalogItemRepository:IGenericRepository<CatalogItem> 
	{
		//Task<IEnumerable<CatalogItem>> GetItems();
		//Task<CatalogItem> GetItem(int id);
		//Task<CatalogItem> AddItem(CatalogItem item);
		//Task Update(CatalogItem item);
		//Task Delete(int id);
	}
}

