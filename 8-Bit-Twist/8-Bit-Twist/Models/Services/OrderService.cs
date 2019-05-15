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
        /// Removes an order item from the database.
        /// </summary>
        /// <param name="productId">The order item's product id.</param>
        /// <param name="orderId">The order item's order id.</param>
        /// <returns>Void</returns>
        public async Task DeleteOrderItem(int productId, int orderId)
        {
            OrderItem item = await GetOrderItem(productId, orderId);

            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets an order by its ID.
        /// </summary>
        /// <param name="orderId">The order's ID.</param>
        /// <returns>An Order</returns>
        public async Task<Order> GetOrder(int orderId)
        {
            return await _context.Orders.Where(o => o.ID == orderId)
                .Include("OrderItems.Product")
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets an order item using its composite key.
        /// </summary>
        /// <param name="productId">The order item's product id.</param>
        /// <param name="orderId">The order item's order id.</param>
        /// <returns>An OrderItem</returns>
        public async Task<OrderItem> GetOrderItem(int productId, int orderId)
        {
            return await _context.OrderItems.Where(i => i.ProductID == productId && i.OrderID == orderId)
                .Include("Product")
                .Include("Order")
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets all order items for a given order.
        /// </summary>
        /// <param name="orderId">The order's ID.</param>
        /// <returns>A List of OrderItems.</returns>
        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            return await _context.OrderItems.Where(i => i.OrderID == orderId)
                .Include("Product")
                .ToListAsync();
        }

        /// <summary>
        /// Gets the last n orders for a specified user.
        /// </summary>
        /// <param name="userId">The user whose orders are being retrieved</param>
        /// <param name="num">The number of orders to retrieve.</param>
        /// <returns>A list of orders.</returns>
        public async Task<List<Order>> GetOrders(string userId, int num)
        {
            return await _context.Orders.Where(o => o.ApplicationUserID == userId)
                .TakeLast(num)
                .Include("OrderItems.Product")
                .ToListAsync();
        }

        /// <summary>
        /// Gets the last n orders.
        /// </summary>
        /// <param name="num">The number of orders to retrieve.</param>
        /// <returns>A List of Orders.</returns>
        public async Task<List<Order>> GetOrders(int num)
        {
            return await _context.Orders.TakeLast(num)
                .Include("OrderItems.Product")
                .ToListAsync();
        }

        /// <summary>
        /// Updates an order in the database.
        /// </summary>
        /// <param name="updated">The updated order.</param>
        /// <param name="orderId">The order's ID.</param>
        /// <returns>The updated Order</returns>
        public async Task<Order> UpdateOrder(Order updated, int orderId)
        {
            Order order = await GetOrder(orderId);
            order.ApplicationUserID = updated.ApplicationUserID;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Updates an order item in the database.
        /// </summary>
        /// <param name="updated">The updated order item.</param>
        /// <param name="productId">The order item's product ID.</param>
        /// <param name="orderId">The order item's order ID.</param>
        /// <returns>Void</returns>
        public async Task UpdateOrderItem(OrderItem updated, int productId, int orderId)
        {
            OrderItem item = await GetOrderItem(productId, orderId);
            item.Quantity = updated.Quantity;
            _context.OrderItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
