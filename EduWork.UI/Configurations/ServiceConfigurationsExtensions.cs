using EduWork.UI.Authentication;
using EduWork.UI.Layout;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace EduWork.UI.Configurations
{
    public static class ServiceConfigurationsExtensions
    {
        private const string LOGIN_MODE = "popup";
        private const string ROLE_CLAIM = "appRole";
        public static void ApplyServiceConfigurations(this WebAssemblyHostBuilder builder) {
            var azureAdOptions = new AzureAdOptions();
            var downstreamApiOptions = new DownstreamApiOptions();

            builder.Configuration.GetSection(AzureAdOptions.Section).Bind(azureAdOptions);
            builder.Configuration.GetSection(DownstreamApiOptions.Section).Bind(downstreamApiOptions);

            builder.Services.AddScoped(sp =>
            {
                var authorizationMessageHandler = sp.GetRequiredService<AuthorizationMessageHandler>();
                authorizationMessageHandler.InnerHandler = new HttpClientHandler();
                authorizationMessageHandler = authorizationMessageHandler.ConfigureHandler(
                    authorizedUrls: new[] { downstreamApiOptions.BaseUrl },
                    scopes: new[] { downstreamApiOptions.Scope });
                return new HttpClient(authorizationMessageHandler)
                {
                    BaseAddress = new Uri(downstreamApiOptions.BaseUrl ?? string.Empty)
                };
            });

            builder.Services.AddMsalAuthentication<RemoteAuthenticationState, UserAccount>(options =>
            {
                builder.Configuration.Bind(AzureAdOptions.Section, options.ProviderOptions.Authentication);
                options.ProviderOptions.LoginMode = LOGIN_MODE;
                options.ProviderOptions.DefaultAccessTokenScopes.Add(downstreamApiOptions.Scope);
                options.UserOptions.RoleClaim = ROLE_CLAIM;
            })
                .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, UserAccount, UserAccountFactory>();

            builder.Services.AddCascadingValue(cv => new CascadingAppState());
        }

       
        public static void AddRootComponents(this WebAssemblyHostBuilder builder) {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
        }
    }
}
