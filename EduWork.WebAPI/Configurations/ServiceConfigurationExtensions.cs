using EduWork.Data;
using EduWork.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Build.Framework;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace EduWork.WebAPI.Configurations
{
    public static class ServiceConfigurationExtensions
    {
        private const string MICROSOFT_GRAPH_SECTION = "MicrosoftGraph";
        private const string EDUWORK_API_NAME = "EduWorkApi";
        private const string EDUWORK_API_VERSION = "v1";
        private const string AUTHENTICATION_ID = "oauth2";
        public static void AllServiceConfigurations(this WebApplicationBuilder builder) {
            var azureAdOptions = new AzureAdOptions();
            var swaggerAzureAdOptions = new SwaggerAzureAdOptions();

            builder.Configuration.GetSection(AzureAdOptions.Section).Bind(azureAdOptions);
            builder.Configuration.GetSection(SwaggerAzureAdOptions.Section).Bind(swaggerAzureAdOptions);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection(AzureAdOptions.Section))
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddMicrosoftGraph(builder.Configuration.GetSection(MICROSOFT_GRAPH_SECTION))
            .AddInMemoryTokenCaches();

            builder.Services.AddControllers();

            builder.Services.AddScoped<UserProfileService>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(EDUWORK_API_VERSION, new OpenApiInfo { Title = EDUWORK_API_NAME, Version = EDUWORK_API_VERSION });
                options.AddSecurityDefinition(AUTHENTICATION_ID, new OpenApiSecurityScheme
                {
                    Description = "Oauth2.0",
                    Name = "oauth2.0",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(swaggerAzureAdOptions.AuthorizationUrl),
                            TokenUrl = new Uri(swaggerAzureAdOptions.TokenUrl),
                            Scopes = new Dictionary<string, string>
                {
                    { swaggerAzureAdOptions.Scope, "Access API" }
                }
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = AUTHENTICATION_ID
                }
            },
            new[] { swaggerAzureAdOptions.Scope }
        }
    });
            });



            builder.Services.AddDbContext<AppDbContext>();
        }
    }
}
