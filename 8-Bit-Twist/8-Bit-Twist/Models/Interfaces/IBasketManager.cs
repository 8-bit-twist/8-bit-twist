using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Interfaces
{
    public interface IBasketManager
    {
        Task<Basket> GetBasket(string userId);
        Task<List<BasketItem>> GetBasketItems(int basketId);
        Task<BasketItem> GetBasketItem(int productId, int basketId);
        Task<Basket> CreateBasket(string userId);
        Task AddBasketItem(int productId, int basketId);
        Task RemoveBasketItem(int productId, int basketId);
        Task ClearBasket(int basketId);
        Task UpdateBasketItem(BasketItem item, int quantity);
        bool BasketHasItem(Basket basket, int productId);
    }
}
