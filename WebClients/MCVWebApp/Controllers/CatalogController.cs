using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCVWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MCVWebApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var item = await _service.GetAllCatalogItems();
            return View(item);
        }

        public async Task<IActionResult> Details(int id)
        {
            var res = await _service.GetCatalogItemDetails(id);
            return View(res);
        }
    }
}