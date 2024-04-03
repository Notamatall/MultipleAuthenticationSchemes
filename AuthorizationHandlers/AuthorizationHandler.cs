using Microsoft.AspNetCore.Authorization;

namespace MultipleAuthenticationSchemes.AuthorizationHandlers
{
    public class CustomRequirementClaim : IAuthorizationRequirement
    {
        public CustomRequirementClaim()
        {

        }
    }

    public class CustomAuthorizationHandler : AuthorizationHandler<CustomRequirementClaim>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CustomRequirementClaim requirement)
        {
            var userDisabled = context.User.Claims.FirstOrDefault(x => x.Type == "isEnabled")?.Value?.ToLowerInvariant() == "0";

            //if (userDisabled)
            //    context.Fail();
            //else
            //    context.Succeed(requirement);


            return Task.CompletedTask;
        }
    }
}
