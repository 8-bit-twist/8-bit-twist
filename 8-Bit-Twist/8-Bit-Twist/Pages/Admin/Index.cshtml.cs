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
    public class IndexModel : PageModel
    {
        readonly IOrderManager _ordManager;

        public List<Order> RecentOrders { get; set; }

        /// <summary>
        /// Creates the page model using dependency injection.
        /// </summary>
        /// <param name="ordManager">The injected order manager.</param>
        public IndexModel(IOrderManager ordManager)
        {
            _ordManager = ordManager;
        }

        /// <summary>
        /// Gets the 10 most recent orders.
        /// </summary>
        /// <returns>Void</returns>
        public async Task OnGet()
        {
            RecentOrders = await _ordManager.GetOrders(10);
        }
    }
}