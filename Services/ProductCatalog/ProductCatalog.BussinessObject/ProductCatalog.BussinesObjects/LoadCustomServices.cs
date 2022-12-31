using System;
using ProductCatalog.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ProductCatalog.BusinessObjects
{
	public class LoadCustomServices
	{
		public void Initialize(IServiceCollection services)
		{
			services.AddTransient<ICatalogTypeBO, CatalogTypeBO>();
			services.AddTransient<ICatalogItemBO, CatalogItemBO>();
		}
	}
}

