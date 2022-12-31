using System;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;
using ProductCatalog.Repositories;

namespace ProductCatalog.EFRepositories
{
	public class CatalogItemRepository : GenericRepository<CatalogItem>, ICatalogItemRepository
    {
        private readonly ProductCatalogContext _context;

        public CatalogItemRepository(ProductCatalogContext context)
        : base(context)
		{
            this._context = context;
        }

        //public async Task<CatalogItem> AddItem(CatalogItem item)
        //{
        //    _context.CatalogItem.Add(item);
        //    await _context.SaveChangesAsync();
        //    return item;
        //}

        //public async Task Delete(int id)
        //{
        //    var catalogItem = await _context.CatalogItem.FindAsync(id);
        //    if (catalogItem == null)
        //    {
        //        throw new ApplicationException("Catalog item not found");
        //    }

        //    _context.CatalogItem.Remove(catalogItem);
        //    await _context.SaveChangesAsync();
        //}

        public async override Task<CatalogItem> GetItem(int id)
        {
            if (_context.CatalogItem == null)
            {
                throw new ApplicationException("Not catalog item found");
            }
            var catalogItem = await _context.CatalogItem.Include("CatalogType").Include("CatalogBrand")
                .Where(item => item.Id == id).FirstOrDefaultAsync();

            if (catalogItem == null)
            {
                throw new ApplicationException("Catalog Item not found");
            }

            return catalogItem;
        }

        public async override Task<IEnumerable<CatalogItem>> GetItems()
        {

            return await _context.CatalogItem.Include("CatalogType").Include("CatalogBrand").ToListAsync();
        }

        //public async Task Update(CatalogItem catalogItem)
        //{

        //    _context.Entry(catalogItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw new ApplicationException("Not updated because of concurency");
        //    }
        //}
    }
}

