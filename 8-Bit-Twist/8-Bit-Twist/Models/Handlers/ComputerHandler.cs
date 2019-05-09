using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Handlers
{
    public class ComputerHandler : AuthorizationHandler<ComputerRequirement>
    {
        /// <summary>
        /// Handler for determining if the current user is flagged as a "computer".  Takes in the authorization information and the Claim requirement and returns a success response if the user has the appropriate claim.
        /// </summary>
        /// <param name="context">Authorization Information.</param>
        /// <param name="requirement">Claim Requirements.</param>
        /// <returns>Success code if User has appropriate Claim.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ComputerRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Computer"))
            {
                return Task.CompletedTask;
            }

            var isComputer = context.User.FindFirst(c => c.Type == "Computer").Value;

            if (isComputer == "True")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
