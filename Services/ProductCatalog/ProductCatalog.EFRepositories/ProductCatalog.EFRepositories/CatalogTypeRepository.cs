using System;
using ProductCatalog.Domain;
using ProductCatalog.Repositories;

namespace ProductCatalog.EFRepositories
{
	public class CatalogTypeRepository:GenericRepository<CatalogType>, ICatalogTypeRepository
    {
        private readonly ProductCatalogContext _context;

        public CatalogTypeRepository(ProductCatalogContext context)
        : base(context)
        {
            this._context = context;
        }
    }
}

