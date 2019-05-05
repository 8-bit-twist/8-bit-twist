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
        Task<BasketItem> GetBasketItem(int basketItemId);
        Task<Basket> CreateBasket(string userId);
        Task AddBasketItem(int productId, int basketId);
        Task RemoveBasketItem(int basketItemId);
        Task ClearBasket(int basketId);
        Task UpdateBasketItem(int basketItemId, int quantity);
        bool BasketHasItem(Basket basket, int productId);
    }
}
