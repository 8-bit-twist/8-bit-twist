using _8_Bit_Twist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Displays the index view.
        /// </summary>
        /// <returns>The rendered view.</returns>
        public IActionResult Index()
        {
            if (User.IsInRole(ApplicationRoles.Admin))
            {
                return RedirectToPage("/Admin/Index");
            }
            return View();
        }

        /// <summary>
        /// Displays a unique view for "computer" users.
        /// </summary>
        /// <returns>Rendered view.</returns>
        [Authorize(Policy = "ComputerPolicy")]
        public IActionResult Computer()
        {
            return View();
        }
    }
}
