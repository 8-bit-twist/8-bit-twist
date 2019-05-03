using _8_Bit_Twist.Data;
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
        private readonly ApplicationDbContext _context;

        public CurrentBasket(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var basket = await _context.Users.Include(x => x.Basket)
                                       .ThenInclude(x => x.BasketItems)
                                       .Where(x => x.Id == userId)
                                       .ToListAsync();

            return View(basket);
        }
    }
}
