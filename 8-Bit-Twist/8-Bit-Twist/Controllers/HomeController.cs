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
            return View();
        }

        [Authorize(Policy = "ComputerPolicy")]
        public IActionResult Computer()
        {
            return View();
        }
    }
}
