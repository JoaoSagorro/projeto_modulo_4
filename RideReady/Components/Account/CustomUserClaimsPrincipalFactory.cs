using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SharedLibrary;
using System.Security.Claims;

namespace RideReady.Components.Account
{
    public class CustomUserClaimsPrincipalFactory
    : UserClaimsPrincipalFactory<EMUser, IdentityRole>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<EMUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(EMUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            if (!string.IsNullOrEmpty(user.FirstName))
            {
                identity.AddClaim(new Claim("FirstName", user.FirstName));
            }

            if (!string.IsNullOrEmpty(user.LastName))
            {
                identity.AddClaim(new Claim("LastName", user.LastName));
            }

            return identity;
        }
    }
}
