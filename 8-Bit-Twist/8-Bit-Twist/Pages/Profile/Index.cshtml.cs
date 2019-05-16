using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _8_Bit_Twist.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;

        public ProfileViewModel PVM { get; set; } = new ProfileViewModel();

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task OnGet()
        {
            ApplicationUser appUser = await _userManager.GetUserAsync(User);
            PVM.EmailAddress = appUser.UserName;
            PVM.FirstName = appUser.FirstName;
            PVM.LastName = appUser.LastName;
        }

        public async Task<IActionResult> OnPost(ProfileViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await _userManager.GetUserAsync(User);
                appUser.FirstName = pvm.FirstName;
                appUser.LastName = pvm.LastName;

                var claims = await _userManager.GetClaimsAsync(appUser);
                Claim claim = claims.First(c => c.Type == "FullName");
                Claim newClaim = new Claim("FullName", $"{pvm.FirstName} {pvm.LastName}");
                await _userManager.ReplaceClaimAsync(appUser, claim, newClaim);

                await _userManager.UpdateAsync(appUser);

                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(appUser, false);

                return RedirectToPage("/Profile/Index");
            }
            return Page();
        }
    }
}