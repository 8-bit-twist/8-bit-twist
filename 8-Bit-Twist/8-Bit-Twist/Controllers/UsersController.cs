using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
using _8_Bit_Twist.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IBasketManager _bsktManager;
        private readonly IEmailSender _emailSender;

        // Injecting context and managers
        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IBasketManager bsktManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bsktManager = bsktManager;
            _emailSender = emailSender;
        }

        /// <summary>
        /// Displays the registration form.
        /// </summary>
        /// <returns>A ViewResult</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Attempts to register the user using form information.
        /// </summary>
        /// <param name="model">The ViewModel containing the form information.</param>
        /// <returns>A ViewResult</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.EmailAddress,
                    Email = model.EmailAddress,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Computer = model.Computer
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Add custom Claims based on user input
                    Claim nameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);
                    Claim computerClaim = new Claim("Computer", user.Computer.ToString());

                    List<Claim> claims = new List<Claim> { nameClaim, emailClaim, computerClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    // Add Roles to specific users
                    if (user.Email.ToLower().Contains("@codefellows.com") || user.Email.ToLower() == "ntibbals@outlook.com" || user.Email.ToLower() == "andrew.l.roska@gmail.com" || user.Email.ToLower() == "staylor.ben@gmail.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }

                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    // Send user a confirmation email
                    string subject = "Welcome to 8-Bit Twist!";
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("<h1>Welcome to 8-Bit Twist!</h1>");
                    sb.AppendLine($"<p>Dear {user.FirstName}</p>");
                    sb.AppendLine($"<p>Thank you for joining <a href=\"https://8-bit-twist.azurewebsites.net/\">8-Bit Twist</a>!</p>");

                    await _emailSender.SendEmailAsync(user.Email, subject, sb.ToString());

                    // Sign user in
                    await _signInManager.SignInAsync(user, false);

                    // Create a new basket for the user
                    Basket basket = await _bsktManager.CreateBasket(user.Id);
                    user.BasketID = basket.ID;
                    await _userManager.UpdateAsync(user);
                    
                    // If user is Admin, redirect to Admin dashboard
                    if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                    {
                        return RedirectToPage("/Admin/Index");
                    }

                    // Redirect to home page
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        /// <summary>
        /// Displays the login form.
        /// </summary>
        /// <returns>A ViewResult</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Attempts to log in the user using form data.
        /// </summary>
        /// <param name="lvm">The ViewModel containing form data.</param>
        /// <returns>A ViewResult</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    // Redirect to home page
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(lvm);
        }

        /// <summary>
        /// Signs the current user out and redirects to the home view.
        /// </summary>
        /// <returns>A ViewResult</returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
