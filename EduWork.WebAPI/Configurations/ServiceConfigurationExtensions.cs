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
        public static void AllServiceConfigurations(this WebApplicationBuilder builder) {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();

            builder.Services.AddControllers();

            builder.Services.AddScoped<UserProfileService>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EduWorkApi", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Oauth2.0",
                    Name = "oauth2.0",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(builder.Configuration["SwaggerAzureAd:AuthorizationUrl"]),
                            TokenUrl = new Uri(builder.Configuration["SwaggerAzureAd:TokenUrl"]),
                            Scopes = new Dictionary<string, string>
                {
                    { builder.Configuration["SwaggerAzureAd:Scope"], "Access API" }
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
                    Id = "oauth2"
                }
            },
            new[] { builder.Configuration["SwaggerAzureAd:Scope"] }
        }
    });
            });



            builder.Services.AddDbContext<AppDbContext>();
        }
    }
}
