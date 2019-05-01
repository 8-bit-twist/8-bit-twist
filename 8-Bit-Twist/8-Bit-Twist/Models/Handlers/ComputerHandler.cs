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
