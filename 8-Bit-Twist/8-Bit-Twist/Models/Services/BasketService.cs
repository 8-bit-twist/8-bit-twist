﻿using _8_Bit_Twist.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _8_Bit_Twist.Data;
using Microsoft.EntityFrameworkCore;

namespace _8_Bit_Twist.Models.Services
{
    public class BasketService : IBasketManager
    {
        readonly _8BitDbContext _context;

        // Inject context
        public BasketService(_8BitDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new BasketItem.
        /// </summary>
        /// <param name="productId">The Product's Id.</param>
        /// <param name="basketId">The Basket's Id.</param>
        /// <returns>Void</returns>
        public async Task AddBasketItem(int productId, int basketId)
        {
            BasketItem item = new BasketItem()
            {
                BasketID = basketId,
                ProductID = productId,
                Quantity = 1
            };

            await _context.BasketItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Check if Basket has Product.
        /// </summary>
        /// <param name="basket">Basket ID.</param>
        /// <param name="productId">Product ID.</param>
        /// <returns>True if Basket has Product.</returns>
        public bool BasketHasItem(Basket basket, int productId)
        {
            return basket.BasketItems.Where(i => i.ProductID == productId).FirstOrDefault() != null;
        }

        /// <summary>
        /// Removes all BasketItems from a Basket.
        /// </summary>
        /// <param name="basketId">The Basket's Id.</param>
        /// <returns>Void</returns>
        public async Task ClearBasket(int basketId)
        {
            List<BasketItem> items = await GetBasketItems(basketId);
            _context.BasketItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a new Basket.
        /// </summary>
        /// <param name="email">The user's ID.</param>
        /// <returns>The new Basket.</returns>
        public async Task<Basket> CreateBasket(string userId)
        {
            Basket basket = new Basket { ApplicationUserID = userId };
            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();
            return basket;
        }

        /// <summary>
        /// Gets a user's Basket.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <returns>A Basket.</returns>
        public async Task<Basket> GetBasket(string userId)
        {
            return await _context.Baskets.Where(b => b.ApplicationUserID == userId)
                .Include("BasketItems.Product")
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets a BasketItem.
        /// </summary>
        /// <param name="productId">The product's ID.</param>
        /// <param name="basketId">The basket's ID.</param>
        /// <returns>A BasketItem.</returns>
        public async Task<BasketItem> GetBasketItem(int productId, int basketId)
        {
            return await _context.BasketItems.Where(i => i.ProductID == productId && i.BasketID == basketId)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets all BasketItems in a Basket. 
        /// </summary>
        /// <param name="basketId">The Basket's Id.</param>
        /// <returns>A List of BasketItems</returns>
        public async Task<List<BasketItem>> GetBasketItems(int basketId)
        {
            return await _context.BasketItems.Where(b => b.BasketID == basketId).ToListAsync();
        }

        /// <summary>
        /// Removes a BasketItem.
        /// </summary>
        /// <param name="productId">The product's ID.</param>
        /// <param name="basketId">The basket's ID.</param>
        /// <returns>Void</returns>
        public async Task RemoveBasketItem(int productId, int basketId)
        {
            BasketItem item = await GetBasketItem(productId, basketId);
            _context.BasketItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a BasketItem's quantity.
        /// </summary>
        /// <param name="item">The BasketItem being updated.</param>
        /// <param name="quantity">The updated quantity.</param>
        /// <returns>Void</returns>
        public async Task UpdateBasketItem(BasketItem item, int quantity)
        {
            item.Quantity = quantity;
            _context.BasketItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
