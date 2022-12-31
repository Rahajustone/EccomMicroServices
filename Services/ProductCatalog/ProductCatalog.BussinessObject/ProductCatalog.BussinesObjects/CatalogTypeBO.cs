using System;
using ProductCatalog.Domain;
using ProductCatalog.Repositories;

namespace ProductCatalog.BusinessObjects
{
	public class CatalogTypeBO : GenericBO<CatalogType>, ICatalogTypeBO
    {
        private readonly ICatalogTypeRepository _repository;

        public CatalogTypeBO(ICatalogTypeRepository repository)
		: base(repository)
		{
			this._repository = repository;
		}
	}

	public interface ICatalogTypeBO : IGenericBO<CatalogType> {
	}

}

