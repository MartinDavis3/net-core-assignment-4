using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopItemService _shopItemService;

        public ShopController(IShopItemService shopItemService)
        {
            _shopItemService = shopItemService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _shopItemService.GetAllItemsAsync();
            var model = new ShopViewModel()
            {
                Items = items
            };
            return View(model);
        }
        public async Task<IActionResult> AddItemToCart(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _shopItemService.AddItemToCartAsync(id);
            if (!successful)
            {
                return BadRequest("Could not add item to cart.");
            }
            return RedirectToAction("Index");
        }
    }
}
