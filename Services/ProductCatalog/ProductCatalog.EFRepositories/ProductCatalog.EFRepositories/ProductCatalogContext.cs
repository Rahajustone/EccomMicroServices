using System;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;

namespace ProductCatalog.EFRepositories
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

