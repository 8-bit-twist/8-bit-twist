﻿using _8_Bit_Twist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Interfaces
{
    public interface IOrderManager
    {
        Task<Order> GetOrder(int orderId);
        Task<List<Order>> GetOrders(string userId, int num);
        Task<List<Order>> GetOrders(int num);
        Task<List<OrderItem>> GetOrderItems(int orderId);
        Task<OrderItem> GetOrderItem(int productId, int orderId);
        Task<Order> CreateOrder(Basket basket, CheckoutViewModel cvm);
        Task DeleteOrder(int orderId);
        Task DeleteOrderItem(int productId, int orderId);
        Task UpdateOrderItem(OrderItem updated, int productId, int orderId);
        Task<Order> UpdateOrder(Order updated, int orderId);
    }
}
