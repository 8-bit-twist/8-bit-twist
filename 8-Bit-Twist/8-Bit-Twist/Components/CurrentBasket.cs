using _8_Bit_Twist.Data;
using _8_Bit_Twist.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Components
{
    public class CurrentBasket : ViewComponent
    {
        private readonly _8BitDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CurrentBasket(_8BitDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var basket =  _context.Baskets.Where(x => x.ApplicationUserID == user.Id)
                                               .Include(b => b.BasketItems)
                                               .ThenInclude(p => p.Product).FirstOrDefault();

            return View(basket);
        }
    }
}
