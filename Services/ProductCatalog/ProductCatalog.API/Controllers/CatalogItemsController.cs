using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessObjects;
using ProductCatalog.Domain;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemsController : ControllerBase
    {
        private readonly ICatalogItemBO _catalogItemBO;

        public CatalogItemsController(ICatalogItemBO catalogItemBO)
        {
            _catalogItemBO = catalogItemBO;
        }

        // GET: api/CatalogItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItem()
        {
            var items = await this._catalogItemBO.GetItems();
            return Ok(items);
        }

        // GET: api/CatalogItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItem>> GetCatalogItem(int id)
        {
            var catalogItem = await _catalogItemBO.GetItem(id);
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

            try
            {
                await _catalogItemBO.Update(catalogItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/CatalogItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogItem>> PostCatalogItem(CatalogItem catalogItem)
        {

            return CreatedAtAction("GetCatalogItem", new { id = catalogItem.Id }, _catalogItemBO.AddItem(catalogItem));
        }

        // DELETE: api/CatalogItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogItem(int id)
        {
            await _catalogItemBO.Delete(id);
            return NoContent();
        }
    }
}
