using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Interfaces
{
    public interface IOrderManager
    {
        Task<Order> GetOrder(int orderId);
        Task<List<Order>> GetOrders(string userId);
        Task<List<OrderItem>> GetOrderItems(int orderId);
        Task<OrderItem> GetOrderItem(int productId, int orderId);
        Task<Order> CreateOrder(string userId, Basket basket);
        Task DeleteOrder(int orderId);
        Task DeleteOrderItem(int productId, int orderId);
        Task UpdateOrderItem(OrderItem updated, int productId, int orderId);
        Task UpdateOrder(Order updated, int orderId);
    }
}
