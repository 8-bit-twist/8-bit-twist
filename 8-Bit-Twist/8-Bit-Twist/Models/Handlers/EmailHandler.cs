using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Handlers
{
    public class EmailHandler : AuthorizationHandler<EmailRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirements requirement)
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
