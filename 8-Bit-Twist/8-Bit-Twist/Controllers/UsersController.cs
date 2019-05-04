using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                    Claim nameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);
                    Claim computerClaim = new Claim("Computer", user.Computer.ToString());

                    List<Claim> claims = new List<Claim> { nameClaim, emailClaim, computerClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    // Sign user in
                    await _signInManager.SignInAsync(user, false);

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
