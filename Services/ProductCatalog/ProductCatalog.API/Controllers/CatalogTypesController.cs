using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessObjects;
using ProductCatalog.Domain;
using ProductCatalog.EFRepositories;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogTypesController : ControllerBase
    {
        private readonly ICatalogTypeBO _catalogTypeBO;

        public CatalogTypesController(ICatalogTypeBO catalogTypeBO)
        {
            _catalogTypeBO = catalogTypeBO;
        }

        // GET: api/CatalogTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogType>>> GetCatalogTypes()
        {
            var res = await _catalogTypeBO.GetAll();
            return Ok(res);
        }

        // GET: api/CatalogTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogType>> GetCatalogType(int id)
        {
            var catalogType = await _catalogTypeBO.Get(id);

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


            try
            {
                await _catalogTypeBO.Update(catalogType);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/CatalogTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogType>> PostCatalogType(CatalogType catalogType)
        {
            var res = await _catalogTypeBO.Add(catalogType);

            return CreatedAtAction("GetCatalogType", new { id = catalogType.Id }, res);
        }

        // DELETE: api/CatalogTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogType(int id)
        {
            await _catalogTypeBO.Delete(id);

            return NoContent();
        }
    }
}
