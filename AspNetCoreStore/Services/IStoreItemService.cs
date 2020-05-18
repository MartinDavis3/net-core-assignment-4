using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreStore.Models;

namespace AspNetCoreStore.Services
{
    public interface IStoreItemService
    {
        Task<StoreItem[]> GetAllItemsAsync();
        Task<bool> AddItemAsync(StoreItem newItem);
    }
}
