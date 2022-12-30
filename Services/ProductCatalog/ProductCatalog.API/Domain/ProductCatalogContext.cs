using System;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.API.Domain
{
	public class ProductCatalogContext : DbContext
	{
		public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
		: base(options)
		{
		}

        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogType { get; set; }
        public DbSet<CatalogItem> CatalogItem { get; set; }
    }
}

