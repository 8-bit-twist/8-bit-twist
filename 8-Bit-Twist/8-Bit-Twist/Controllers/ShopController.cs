﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _8_Bit_Twist.Controllers
{
    public class ShopController : Controller
    {
        readonly IInventoryManager _invManager;

        /// <summary>
        /// Creates a new ShopController instance.
        /// </summary>
        /// <param name="invManager">The controller's inventory manager.</param>
        public ShopController(IInventoryManager invManager)
        {
            _invManager = invManager;
        }

        /// <summary>
        /// Displays the shop index view with a list of all products.
        /// </summary>
        /// <returns>A ViewResult</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _invManager.GetAllProducts();
            return View(products);
        }
    }
}