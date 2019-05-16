using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _8_Bit_Twist.Pages.Admin
{
    [Authorize(Roles = ApplicationRoles.Admin)]
    public class OrderModel : PageModel
    {
        readonly IOrderManager _ordManager;

        public Order Order { get; set; }

        public OrderModel(IOrderManager ordManager)
        {
            _ordManager = ordManager;
        }

        public async Task OnGet(int id)
        {
            Order = await _ordManager.GetOrder(id);
        }
    }
}