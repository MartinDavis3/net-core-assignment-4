using AspNetCoreStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreStore.Services
{
    public interface IShopItemService
    {
        Task<StoreItem[]> GetAllItemsAsync();
        Task<bool> AddItemToCartAsync(Guid id);
    }
}
