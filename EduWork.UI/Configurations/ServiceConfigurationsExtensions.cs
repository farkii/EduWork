using EduWork.UI.Layout;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace EduWork.UI.Configurations
{
    public static class ServiceConfigurationsExtensions
    {
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

            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind(AzureAdOptions.Section, options.ProviderOptions.Authentication);
                options.ProviderOptions.LoginMode = "popup";
                options.ProviderOptions.DefaultAccessTokenScopes.Add(downstreamApiOptions.Scope);
            });

            builder.Services.AddCascadingValue(cv => new CascadingAppState());
        }

       
        public static void AddRootComponents(this WebAssemblyHostBuilder builder) {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
        }
    }
}
