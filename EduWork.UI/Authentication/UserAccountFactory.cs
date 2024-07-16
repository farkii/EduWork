using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;

namespace EduWork.UI.Authentication
{
    public class UserAccountFactory : AccountClaimsPrincipalFactory<UserAccount>
    {
        public UserAccountFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
        {
            
        }
        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(UserAccount account, RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);
            if (initialUser.Identity is not null && initialUser.Identity.IsAuthenticated) 
            {
                var userIdentity = (ClaimsIdentity)initialUser.Identity;

                if (userIdentity is not null)
                {
                    account?.Roles?.ForEach(role =>
                    {
                        userIdentity.AddClaim(new Claim("appRole", role));
                    });
                }
            }

            return initialUser;
        }
    }
}
