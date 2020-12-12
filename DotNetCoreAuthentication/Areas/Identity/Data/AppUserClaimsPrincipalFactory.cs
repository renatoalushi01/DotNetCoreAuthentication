using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace DotNetCoreAuthentication.Areas.Identity.Data
{
    public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager,
            options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));
            return identity;
        }
    }
}