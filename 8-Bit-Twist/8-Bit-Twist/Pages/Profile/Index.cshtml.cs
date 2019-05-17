using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
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

        public IOrderManager _orderManager { get; }
        public ProfileViewModel PVM { get; set; } = new ProfileViewModel();
        public string Message { get; set; }

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderManager = orderManager;
        }

        public async Task OnGet(string message)
        {
            Message = message;
            ApplicationUser appUser = await _userManager.GetUserAsync(User);
            PVM.EmailAddress = appUser.UserName;
            PVM.FirstName = appUser.FirstName;
            PVM.LastName = appUser.LastName;
            PVM.Orders = await _orderManager.GetOrders(appUser.Id, 5);
        }

        public async Task<IActionResult> OnPost(ProfileViewModel pvm)
        {
            bool changed = false;
            StringBuilder messageBuilder = new StringBuilder();

            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await _userManager.GetUserAsync(User);

                var claims = await _userManager.GetClaimsAsync(appUser);
                Claim claim = claims.First(c => c.Type == "FullName");
                Claim newClaim = new Claim("FullName", $"{pvm.FirstName} {pvm.LastName}");

                if (claim.Value != newClaim.Value)
                {
                    appUser.FirstName = pvm.FirstName;
                    appUser.LastName = pvm.LastName;

                    await _userManager.ReplaceClaimAsync(appUser, claim, newClaim);
                    changed = true;
                    messageBuilder.AppendLine("Name was successfully changed");
                }

                if (pvm.Password != null)
                {
                    if (pvm.NewPassword != null && pvm.ConfirmPassword != null)
                    {
                        if (pvm.ConfirmPassword == pvm.NewPassword)
                        {
                            IdentityResult response = await _userManager
                                .ChangePasswordAsync(appUser, pvm.Password, pvm.NewPassword);

                            if (response.Succeeded)
                            {
                                changed = true;
                                messageBuilder.AppendLine("Password was successfully changed");
                            }

                            else messageBuilder.AppendLine("Incorrect Password");
                        }

                        else messageBuilder.AppendLine("Passwords do not match");
                    }

                    else messageBuilder.AppendLine("All password fields must be filled");
                }

                else if (pvm.NewPassword != null || pvm.ConfirmPassword != null)
                {
                    messageBuilder.AppendLine("All password fields must be filled");
                }

                if (messageBuilder.Length == 0)
                {
                    messageBuilder.AppendLine("No changes were made");
                }

                Message = messageBuilder.ToString();

                if (changed)
                {
                    await _userManager.UpdateAsync(appUser);

                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(appUser, false);

                    return RedirectToPage("/Profile/Index", new { message = Message });
                }
            }
            return Page();
        }
    }
}