using _8_Bit_Twist.Data;
using _8_Bit_Twist.Models.Interfaces;
using _8_Bit_Twist.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Services
{
    public class OrderService : IOrderManager
    {
        readonly _8BitDbContext _context;

        /// <summary>
        /// Initializes the service with the provided DbContext.
        /// </summary>
        /// <param name="context">The DbContext for the service.</param>
        public OrderService(_8BitDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="userId">The user's Id.</param>
        /// <param name="basket">The user's basket.</param>
        /// <returns>The new order.</returns>
        public async Task<Order> CreateOrder(Basket basket, CheckoutViewModel cvm)
        {
            List<OrderItem> oItems = new List<OrderItem>();

            decimal total = 0;
            foreach (BasketItem item in basket.BasketItems)
            {
                total += item.Quantity * item.Product.Price;
            }

            Order order = new Order()
            {
                ApplicationUserID = basket.ApplicationUserID,
                CardNumber = cvm.CardNumber,
                City = cvm.City,
                TotalPrice = total,
                ShippingAddress = cvm.ShippingAddress,
                Zip = cvm.Zip
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (BasketItem bItem in basket.BasketItems)
            {
                oItems.Add(new OrderItem
                {
                    Quantity = bItem.Quantity,
                    ProductID = bItem.ProductID,
                    Price = bItem.Product.Price,
                    OrderID = order.ID
                });
            }

            await _context.OrderItems.AddRangeAsync(oItems);
            await _context.SaveChangesAsync();

            order.OrderItems = oItems;

            return order;
        }

        /// <summary>
        /// Deletes an Order.
        /// </summary>
        /// <param name="orderId">The order's Id.</param>
        /// <returns>Void</returns>
        public async Task DeleteOrder(int orderId)
        {
            Order order = await GetOrder(orderId);

            _context.OrderItems.RemoveRange(order.OrderItems);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task DeleteOrderItem(int productId, int orderId)
        {
            OrderItem item = await GetOrderItem(productId, orderId);

            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Order> GetOrder(int orderId)
        {
            return await _context.Orders.Where(o => o.ID == orderId)
                .Include("OrderItems.Product")
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<OrderItem> GetOrderItem(int productId, int orderId)
        {
            return await _context.OrderItems.Where(i => i.ProductID == productId && i.OrderID == orderId)
                .Include("Product")
                .Include("Order")
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            return await _context.OrderItems.Where(i => i.OrderID == orderId)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetOrders(string userId)
        {
            return await _context.Orders.Where(o => o.ApplicationUserID == userId)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updated"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Order> UpdateOrder(Order updated, int orderId)
        {
            Order order = await GetOrder(orderId);
            order.ApplicationUserID = updated.ApplicationUserID;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updated"></param>
        /// <param name="productId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task UpdateOrderItem(OrderItem updated, int productId, int orderId)
        {
            OrderItem item = await GetOrderItem(productId, orderId);
            item.Quantity = updated.Quantity;
            _context.OrderItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
