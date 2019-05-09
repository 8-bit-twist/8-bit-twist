using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _8_Bit_Twist.Controllers
{
    public class CheckoutController : Controller
    {
        readonly IOrderManager _ordManager;
        readonly IBasketManager _bsktManager;
        readonly UserManager<ApplicationUser> _userManager;
        readonly IEmailSender _emailSender;

        /// <summary>
        /// Initializes the controller with the required services.
        /// </summary>
        /// <param name="ordManager">The order service</param>
        /// <param name="bsktManager">The basket service</param>
        /// <param name="userManager">The user manager</param>
        public CheckoutController(IOrderManager ordManager, IBasketManager bsktManager,
            UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _ordManager = ordManager;
            _bsktManager = bsktManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Receipt()
        {
            string userId = _userManager.GetUserId(User);
            Basket basket = await _bsktManager.GetBasket(userId);

            Order order = await _ordManager.CreateOrder(userId, basket);

            await _bsktManager.ClearBasket(basket.ID);

            await SendReceipt(order);

            return View(order);
        }

        /// <summary>
        /// Sends the user an order confirmation email.
        /// </summary>
        /// <param name="order">The order being confirmed.</param>
        /// <returns>Void</returns>
        public async Task SendReceipt(Order order)
        {
            StringBuilder html = new StringBuilder($@"<h1>8-Bit-Twist</h1>
                <h2>Thank you for your purchase, {User.Claims.First(c => c.Type == "FullName").Value}!</h2>
                <h3>Order Summary</h3><hr/>");

            foreach (OrderItem oItem in order.OrderItems)
            {
                html.Append($@"<h4>{oItem.Product.Name}</h4>
                    <p>Unit Cost: ${oItem.Price}, Quantity: {oItem.Quantity}, Total: ${oItem.Price * oItem.Quantity}</p>
                    <hr/>");
            }

            html.Append($"<h4>Order Total: ${order.TotalPrice}</h4>");

            await _emailSender.SendEmailAsync(User.Identity.Name, "Your 8-Bit-Twist Receipt", html.ToString());
        }
    }
}
