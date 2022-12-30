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
    public class CatalogTypesController : ControllerBase
    {
        private readonly ProductCatalogContext _context;

        public CatalogTypesController(ProductCatalogContext context)
        {
            _context = context;
        }

        // GET: api/CatalogTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogType>>> GetCatalogTypes()
        {
          if (_context.CatalogType == null)
          {
              return NotFound();
          }
            return await _context.CatalogType.ToListAsync();
        }

        // GET: api/CatalogTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogType>> GetCatalogType(int id)
        {
          if (_context.CatalogType == null)
          {
              return NotFound();
          }
            var catalogType = await _context.CatalogType.FindAsync(id);

            if (catalogType == null)
            {
                return NotFound();
            }

            return catalogType;
        }

        // PUT: api/CatalogTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogType(int id, CatalogType catalogType)
        {
            if (id != catalogType.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogTypeExists(id))
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

        // POST: api/CatalogTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogType>> PostCatalogType(CatalogType catalogType)
        {
          if (_context.CatalogType == null)
          {
              return Problem("Entity set 'ProductCatalogContext.CatalogType'  is null.");
          }
            _context.CatalogType.Add(catalogType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogType", new { id = catalogType.Id }, catalogType);
        }

        // DELETE: api/CatalogTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogType(int id)
        {
            if (_context.CatalogType == null)
            {
                return NotFound();
            }
            var catalogType = await _context.CatalogType.FindAsync(id);
            if (catalogType == null)
            {
                return NotFound();
            }

            _context.CatalogType.Remove(catalogType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogTypeExists(int id)
        {
            return (_context.CatalogType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
