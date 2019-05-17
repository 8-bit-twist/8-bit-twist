using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _8_Bit_Twist.Pages.Profile
{
    public class OrderModel : PageModel
    {
        private IOrderManager _orderManager;

        public Order Order { get; set; }

        public OrderModel(IOrderManager manager)
        {
            _orderManager = manager;

        }

        public async Task OnGet(int id)
        {
            Order = await _orderManager.GetOrder(id);
        }
    }
}