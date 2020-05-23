using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreStore.Models;
using AspNetCoreStore.Services;

namespace AspNetCoreStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreItemService _storeItemService;

        public StoreController(IStoreItemService storeItemService) 
        {
            _storeItemService = storeItemService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _storeItemService.GetAllItemsAsync();
            var model = new StoreViewModel()
            {
                Items = items
            };
            return View(model);
        }
 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(StoreItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _storeItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }

    }
}
