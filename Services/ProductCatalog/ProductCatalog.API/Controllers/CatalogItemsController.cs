using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Domain;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemsController : ControllerBase
    {
        private readonly ProductCatalogContext _context;

        public CatalogItemsController(ProductCatalogContext context)
        {
            _context = context;
        }

        // GET: api/CatalogItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItem()
        {
          if (_context.CatalogItem == null)
          {
              return NotFound();
          }

            return await _context.CatalogItem.Include("CatalogType").Include("CatalogBrand").ToListAsync();
        }

        // GET: api/CatalogItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItem>> GetCatalogItem(int id)
        {
          if (_context.CatalogItem == null)
          {
              return NotFound();
          }
            var catalogItem = await _context.CatalogItem.Include("CatalogType").Include("CatalogBrand")
                .Where(item => item.Id == id).FirstOrDefaultAsync();

            if (catalogItem == null)
            {
                return NotFound();
            }

            return catalogItem;
        }

        // PUT: api/CatalogItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogItem(int id, CatalogItem catalogItem)
        {
            if (id != catalogItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CatalogItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogItem>> PostCatalogItem(CatalogItem catalogItem)
        {
          if (_context.CatalogItem == null)
          {
              return Problem("Entity set 'ProductCatalogContext.CatalogItem'  is null.");
          }
            _context.CatalogItem.Add(catalogItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogItem", new { id = catalogItem.Id }, catalogItem);
        }

        // DELETE: api/CatalogItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogItem(int id)
        {
            if (_context.CatalogItem == null)
            {
                return NotFound();
            }
            var catalogItem = await _context.CatalogItem.FindAsync(id);
            if (catalogItem == null)
            {
                return NotFound();
            }

            _context.CatalogItem.Remove(catalogItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogItemExists(int id)
        {
            return (_context.CatalogItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
