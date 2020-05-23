using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreStore.Data;
using AspNetCoreStore.Models;
using Microsoft.EntityFrameworkCore;


namespace AspNetCoreStore.Services
{
    public class StoreItemService : IStoreItemService
    {
        private readonly ApplicationDbContext _context;
        public StoreItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<StoreItem[]> GetAllItemsAsync()
        {
            return await _context.Items
            .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(StoreItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            //‘Set any other properties of newItem as required’;
            newItem.InCart = false;
            newItem.Quantity = 1;
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
