using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreStore.Data;
using AspNetCoreStore.Models;


namespace AspNetCoreStore.Services
{
    public class ShopItemService : IShopItemService
    {
        private readonly ApplicationDbContext _context;
        public ShopItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<StoreItem[]> GetAllItemsAsync()
        {
            return await _context.Items
            .ToArrayAsync();
        }
        public async Task<bool> AddItemToCartAsync(Guid id)
        {
            var item = await _context.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.InCart = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
