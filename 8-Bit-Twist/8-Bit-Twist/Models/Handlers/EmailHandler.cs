using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Handlers
{
    public class EmailHandler : AuthorizationHandler<EmailRequirement>
    {
        /// <summary>
        /// Handler for determining if the current user has an email domain of "codefellows.com".  Takes in the authorization information and the Claim requirement and returns a success response if the user has the appropriate claim.
        /// </summary>
        /// <param name="context">Authorization Information.</param>
        /// <param name="requirement">Claim Requirements.</param>
        /// <returns>Success code if User has appropriate Claim.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Email"))
            {
                return Task.CompletedTask;
            }

            var email = context.User.FindFirst(c => c.Type == "Email").Value;

            if (email.Contains("@codefellows.com"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
