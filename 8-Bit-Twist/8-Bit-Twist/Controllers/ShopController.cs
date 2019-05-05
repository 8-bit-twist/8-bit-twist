﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _8_Bit_Twist.Controllers
{
    public class ShopController : Controller
    {
        readonly IInventoryManager _invManager;
        readonly IBasketManager _bsktManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Creates a new ShopController instance.
        /// </summary>
        /// <param name="invManager">The controller's inventory manager.</param>
        public ShopController(IInventoryManager invManager, UserManager<ApplicationUser> userManager,
            IBasketManager bsktManager, SignInManager<ApplicationUser> signInManager)
        {
            _invManager = invManager;
            _bsktManager = bsktManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Displays the shop index view with a list of all Products.
        /// </summary>
        /// <returns>A ViewResult</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _invManager.GetAllProducts();
            return View(products);
        }

        /// <summary>
        /// Displays a single Product's details page.
        /// </summary>
        /// <param name="id">The Products's ID</param>
        /// <returns>A ViewResult</returns>
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            Product product = await _invManager.GetProductByID(id);
            if (_signInManager.IsSignedIn(User))
            {
                Basket basket = await _bsktManager.GetBasket(_userManager.GetUserId(User));
                ViewData["IsInBasket"] = _bsktManager.BasketHasItem(basket, id);
            }
            return View(product);
        }

        /// <summary>
        /// Adds a Product to the user's Basket.
        /// </summary>
        /// <param name="productId">The Product's Id.</param>
        /// <returns>Void</returns>
        [Authorize]
        [HttpPost]
        public async Task AddToBasket(int productId)
        {
            Basket basket = await _bsktManager.GetBasket(_userManager.GetUserId(User));
            await _bsktManager.AddBasketItem(productId, basket.ID);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Basket()
        {
            Basket basket = await _bsktManager.GetBasket(_userManager.GetUserId(User));
            return View(basket);
        }
    }
}