using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _8_Bit_Twist.Pages.Admin
{
    [Authorize(Roles = ApplicationRoles.Admin)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}