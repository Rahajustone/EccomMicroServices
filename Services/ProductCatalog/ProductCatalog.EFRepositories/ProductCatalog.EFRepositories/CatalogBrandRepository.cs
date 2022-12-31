using System;
using ProductCatalog.Domain;
using ProductCatalog.Repositories;

namespace ProductCatalog.EFRepositories
{
	public class CatalogBrandRepository: GenericRepository<CatalogBrand>, ICatalogBrandRepository
    {
        private readonly ProductCatalogContext _context;

        public CatalogBrandRepository(ProductCatalogContext context)
        : base(context)
        {
            this._context = context;
        }
    }
}

